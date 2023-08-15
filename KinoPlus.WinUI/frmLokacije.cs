using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Constants;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmLokacije : Form
    {
        public APIService APIService { get; set; } = new APIService("locations");
        public int PageNumber = 1;
        public int PageSize = 10;

        public frmLokacije()
        {
            InitializeComponent();
        }

        private async void frmLokacije_Load(object sender, EventArgs e)
        {
            btnNazad.Enabled = false;
            await loadLocations();
        }

        public async Task loadLocations()
        {
            var search = txtTrazi.Text;
            object queryParams = new LocationSearchObject
            {
                Page = PageNumber,
                PageSize = PageSize,
                NameFTS = search
            };

            try
            {
                var locations = await APIService.Get<List<LocationDto>>(queryParams);
                var bindLocations = locations?
                    .Select(l => new
                    {
                        Id = l.Id,
                        Naziv = $"{l.Name} - {l.City.Name}",
                        BrojDvorana = l.Halls.Count(),
                        VrsteProjekcije = string.Join(", ", l.ProjectionTypes.Select(g => g.Name)),
                        Adresa = l.Address,
                        Drzava = l.City.Country.Name,
                    })
                    .ToList();

                dgvLocations.DataSource = bindLocations;

                dgvLocations.Columns["Id"].Visible = false;
                dgvLocations.Columns["BrojDvorana"].HeaderText = "Broj dvorana";
                dgvLocations.Columns["BrojDvorana"].Width = 100;
                dgvLocations.Columns["VrsteProjekcije"].HeaderText = "Vrste projekcije";

                lblPaging.Text = "Stranica " + PageNumber;
            }
            catch (Exception)
            {
                MessageBox.Show(ErrorMessages.LoadingError);
            }

        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            await loadLocations();
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
            await loadLocations();
        }

        private async void btnNazad_Click(object sender, EventArgs e)
        {
            PageNumber -= 1;
            if (PageNumber == 1)
            {
                btnNazad.Enabled = false;
            }
            await loadLocations();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            var frmLokacijeUpsert = new frmLokacijaUpsert();

            if (frmLokacijeUpsert.ShowDialog() == DialogResult.OK)
            {
                await loadLocations();
            }
        }

        private async void dgvLocations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var locationId = dgvLocations.Rows[e.RowIndex].Cells["Id"].Value as int?;

            var frmEdit = new frmLokacijaUpsert(locationId);

            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                await loadLocations();
            }
        }
    }
}
