using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;

namespace KinoPlus.WinUI.Projections
{
    public partial class frmProjectionEdit : Form
    {
        public APIService APIService { get; set; } = new APIService("projections");
        public ProjectionUpdateObject ProjectionUpdateObject { get; set; }
        public int LocationId { get; set; }
        public frmProjectionEdit(int locationId, ProjectionUpdateObject projection)
        {
            InitializeComponent();

            ProjectionUpdateObject = projection;
            LocationId = locationId;
        }

        private async void frmProjectionEdit_Load(object sender, EventArgs e)
        {
            dtpDatumVrijeme.Value = ProjectionUpdateObject.StartsAt!.Value;

            await loadHalls();

            cmbDvorana.SelectedValue = ProjectionUpdateObject.HallId!.Value;
        }

        public async Task loadHalls()
        {
            var hallSearch = new HallSearchObject
            {
                LocationId = LocationId
            };

            await ListControlHelper.loadControlEntity<HallDto>(cmbDvorana, "Halls", "Name", queryObject: hallSearch);
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            var projectionUpdate = new ProjectionUpdateObject
            {
                Id = ProjectionUpdateObject.Id!.Value,
                HallId = (int)cmbDvorana.SelectedValue!,
                StartsAt = dtpDatumVrijeme.Value,
            };

            var updated = await APIService.Update<ProjectionDto>(projectionUpdate.Id.Value, projectionUpdate);

            if (updated != null)
            {
                MessageBox.Show("Projekcija uspješno izmijenjena", string.Empty);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void btnOtkazi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Otkazivanje projekcije je nepovratna akcija.",
                "Jeste li sigurni?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var apiService = new APIService("projections/cancel");

                var isCanceled = await apiService.Update<bool>(ProjectionUpdateObject.Id!.Value, new { });

                if (isCanceled)
                {
                    MessageBox.Show("Projekcija uspješno otkazana");
                    DialogResult = DialogResult.OK;
                    return;
                }
            }
        }
    }
}