using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Properties;
using KinoPlus.WinUI.Utils;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmProjekcije : Form
    {
        public APIService APIService { get; set; } = new APIService("projections");
        public int PageNumber = 1;
        public int PageSize = 10;
        private bool Loading = false;

        public frmProjekcije()
        {
            InitializeComponent();
        }

        private async void frmProjekcije_Load(object sender, EventArgs e)
        {
            btnNazad.Enabled = false;
            Loading = true;
            await loadLocations();
            await loadProjections();
            Loading = false;
        }

        public async Task loadProjections()
        {
            var locationId = (int?)(cmbLokacija.SelectedValue);
            var date = (DateTime)(dtpDatum.Value);

            object queryParams = new ProjectionSearchObject
            {
                Page = PageNumber,
                PageSize = PageSize,
                Date = date,
                LocationId = locationId
            };

            var projections = await APIService.Get<List<ProjectionDto>>(queryParams);
            var bindProjections = projections?
                .Select(p => new
                {
                    Id = p.Id,
                    Slika = ImageUtility.resizeImage(ImageUtility.GetImageFromUrl(Settings.Default.ApiUrl + "images/" + p.Movie.ImageId), new Size(50, 70)),
                    Naziv = p.Movie.Title,
                    Vrijeme = $"{p.StartsAt.ToShortTimeString()} - {p.EndsAt.ToShortTimeString()}",
                    Trajanje = p.Movie.Duration,
                    Dvorana = p.Hall?.Name,
                    VrstaProjekcije = p.ProjectionType.Name,
                    Popunjenost = $"{p.TicketCount}/80",
                    Redovna = p.RecurringProjectionId != null ? "DA" : "NE",
                    Cijena = p.Price,
                })
                .ToList();

            dgvProjections.DataSource = bindProjections;

            dgvProjections.Columns["Id"].Visible = false;
            dgvProjections.Columns["VrstaProjekcije"].HeaderText = "Vrsta projekcije";
            lblPaging.Text = "Page " + PageNumber;
        }

        public async Task loadLocations()
        {
            await ListControlHelper.loadControlEntity<LocationDto>(cmbLokacija, "Locations", "Name", true);
        }

        private async void btnNaprijed_Click(object sender, EventArgs e)
        {
            PageNumber += 1;
            if (PageNumber == 1)
            {
                btnNazad.Enabled = false;
            }
            else
            {
                btnNazad.Enabled = true;
            }
            await loadProjections();
        }

        private async void btnNazad_Click(object sender, EventArgs e)
        {
            PageNumber -= 1;
            if (PageNumber == 1)
            {
                btnNazad.Enabled = false;
            }
            await loadProjections();
        }

        private async void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
                await loadProjections();
        }

        private async void cmbLokacija_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
                await loadProjections();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            var frmProjekcija = new frmProjekcijaInsert();

            if (frmProjekcija.ShowDialog() == DialogResult.OK)
            {
                await loadProjections();
            }

        }
    }
}
