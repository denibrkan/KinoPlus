using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;
using Microsoft.Reporting.WinForms;

namespace KinoPlus.WinUI
{
    public partial class frmIzvjestaji : Form
    {
        public APIService APIService { get; set; } = new APIService("projections");
        public frmIzvjestaji()
        {
            InitializeComponent();

        }

        private async void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            dtpDatumOd.Value = DateTime.Now.AddDays(-7);

            await loadLocations();
            await loadMovies();
        }

        public async Task loadLocations()
        {
            await ListControlHelper.loadControlEntity<LocationDto>(cmbLokacija, "Locations", "Name", false);
        }

        public async Task loadMovies()
        {
            await ListControlHelper.loadControlEntity<MovieDto>(cmbFilm, "Movies", "Title", false);
        }

        private async void btnOsvjezi_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dtpDatumOd.Value;
            DateTime dateTo = dtpDatumDo.Value;
            var locationId = (int?)cmbLokacija.SelectedValue;
            var movieId = (int?)cmbFilm.SelectedValue;

            var queryParams = new ProjectionSearchObject { DateFrom = dateFrom, DateTo = dateTo, LocationId = locationId, MovieId = movieId };

            var projections = await APIService.Get<List<ProjectionDto>>(queryParams);

            var groupedProjections = projections!.GroupBy(p => p.MovieId);

            var dataTable = new DataSets.ProjectionDataSet.ProjectionDataTable();

            foreach (var group in groupedProjections)
            {
                foreach (var projection in group)
                {
                    dataTable.AddProjectionRow
                 (
                     projection.StartsAt.ToShortDateString(),
                     projection.StartsAt.ToShortTimeString(),
                     projection.Movie.Title,
                     projection.TicketCount,
                     projection.Location.Name,
                     projection.Price,
                     projection.TicketCount * projection.Price
                 );
                }
            }

            var dataSource = new ReportDataSource();
            dataSource.Name = "DataSet1";
            dataSource.Value = dataTable;

            var paramCollection = new ReportParameterCollection
            {
                new ReportParameter("datumOd", dateFrom.ToShortDateString()),
                new ReportParameter("datumDo", dateTo.ToShortDateString()),
            };

            this.reportViewer1.LocalReport.SetParameters(paramCollection);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
