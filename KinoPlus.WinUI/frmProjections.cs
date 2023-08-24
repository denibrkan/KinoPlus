using eProdaja.WinUI;
using KinoPlus.Common.Resources.Strings;
using KinoPlus.Models;
using KinoPlus.WinUI.Projections;
using KinoPlus.WinUI.Utils;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmProjections : Form
    {
        public APIService APIService { get; set; } = new APIService("projections");
        public int PageNumber = 1;
        public int PageSize = 10;
        private bool Loading = false;

        public frmProjections()
        {
            InitializeComponent();

            btnDatumNaprijed.Visible = true;
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

            var queryParams = new ProjectionSearchObject
            {
                Page = PageNumber,
                PageSize = PageSize,
                Date = date,
                LocationId = locationId
            };

            try
            {
                var projections = await APIService.Get<List<ProjectionDto>>(queryParams);
                if (projections == null)
                    return;

                var bindProjections = projections
                    .Select(p => new
                    {
                        Id = p.Id,
                        Slika = p.Movie.ImageId != null ? ImageUtility.resizeImage(ImageUtility.GetImageById((Guid)p.Movie.ImageId!), new Size(50, 70)) : null,
                        Naziv = p.Movie.Title,
                        Vrijeme = $"{p.StartsAt.ToShortTimeString()} - {p.EndsAt.ToShortTimeString()}",
                        Trajanje = p.Movie.Duration,
                        Dvorana = p.Hall?.Name,
                        VrstaProjekcije = p.ProjectionType.Name,
                        Popunjenost = $"{p.TicketCount}/80",
                        Redovna = p.RecurringProjectionId != null ? "DA" : "NE",
                        Otkazana = p.IsCanceled,
                        Cijena = p.Price,
                    })
                    .ToList();

                dgvProjections.DataSource = bindProjections;

                dgvProjections.Columns["Naziv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvProjections.Columns["Id"].Visible = false;
                dgvProjections.Columns["VrstaProjekcije"].HeaderText = "Vrsta projekcije";
                dgvProjections.Columns["Slika"].HeaderText = "";

                lblPaging.Text = "Stranica " + PageNumber;
                if (projections.Count < queryParams.PageSize)
                    btnNaprijed.Enabled = false;
                else
                    btnNaprijed.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show(Strings.LoadingError);
            }

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
            var frmProjekcijaInsert = new frmProjectionInsert(dtpDatum.Value);

            if (frmProjekcijaInsert.ShowDialog() == DialogResult.OK)
            {
                if (frmProjekcijaInsert.InsertedProjectionDate != null)
                {
                    dtpDatum.Value = frmProjekcijaInsert.InsertedProjectionDate.Value;
                }

                await loadProjections();
            }

        }

        private void btnDatumNaprijed_Click(object sender, EventArgs e)
        {
            dtpDatum.Value = dtpDatum.Value.AddDays(1);
        }

        private void btnDatumNazad_Click(object sender, EventArgs e)
        {
            dtpDatum.Value = dtpDatum.Value.AddDays(-1);
        }

        private async void dgvProjections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var projectionId = dgvProjections.Rows[e.RowIndex].Cells["Id"].Value as int?;
            var isCanceled = (bool)dgvProjections.Rows[e.RowIndex].Cells["Otkazana"].Value;

            if (projectionId == null || isCanceled) return;

            var projection = await APIService.GetById<ProjectionDto>(projectionId);
            if (projection == null) return;

            var projectionUpdate = new ProjectionUpdateObject
            {
                Id = projectionId,
                StartsAt = projection.StartsAt,
                HallId = projection.HallId
            };

            var frmProjectionEdit = new frmProjectionEdit(projection.LocationId, projectionUpdate);

            if (frmProjectionEdit.ShowDialog() == DialogResult.OK)
            {
                await loadProjections();
            }
        }

        private void dgvProjections_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  // Exclude header cells
            {
                DataGridViewRow row = dgvProjections.Rows[e.RowIndex];
                DataGridViewColumn col = dgvProjections.Columns[e.ColumnIndex];

                if (col.Name == "Otkazana")
                {
                    bool value = (bool)e.Value;

                    if (value)
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        row.DefaultCellStyle.SelectionBackColor = Color.Tomato;
                    }
                }
            }

        }
    }
}