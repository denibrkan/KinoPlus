using eProdaja.WinUI;
using KinoPlus.Models;

namespace KinoPlus.WinUI
{
    public partial class frmProjekcijaInsert : Form
    {
        public APIService ProjectionService { get; set; } = new APIService("projections");
        public APIService MovieService { get; set; } = new APIService("movies");
        public APIService ProjectionTypeService { get; set; } = new APIService("projectiontypes");
        public APIService LocationService { get; set; } = new APIService("locations");
        public List<Tuple<CheckBox, ComboBox>> LocationHalls { get; set; } = new List<Tuple<CheckBox, ComboBox>>();

        public frmProjekcijaInsert()
        {
            InitializeComponent();
        }

        private async void frmProjekcijaInsert_Load(object sender, EventArgs e)
        {
            await loadMovies();
            await loadProjectionTypes();
            await loadLocations();
        }

        public async Task loadMovies()
        {
            List<MovieDto>? movies;
            if (!Cache.Movies.Any())
            {
                movies = await MovieService.Get<List<MovieDto>>();
                if (movies != null)
                    Cache.Movies = movies;
            }
            else
            {
                movies = Cache.Movies;
            }
            cmbFilm.ValueMember = "Id";
            cmbFilm.DisplayMember = "Title";
            cmbFilm.DataSource = movies;
            cmbFilm.SelectedIndex = -1;
        }

        public async Task loadProjectionTypes()
        {
            List<ProjectionTypeDto>? types;
            if (!Cache.ProjectionTypes.Any())
            {
                types = await ProjectionTypeService.Get<List<ProjectionTypeDto>>();
                if (types != null)
                    Cache.ProjectionTypes = types;
            }
            else
            {
                types = Cache.ProjectionTypes;
            }
            cmbVrstaProjekcije.ValueMember = "Id";
            cmbVrstaProjekcije.DisplayMember = "Name";
            cmbVrstaProjekcije.DataSource = types;
            cmbVrstaProjekcije.SelectedIndex = -1;

        }

        public async Task loadLocations()
        {
            List<LocationDto>? locations;
            if (!Cache.Locations.Any())
            {
                locations = await LocationService.Get<List<LocationDto>>();
                if (locations != null)
                    Cache.Locations = locations;
            }
            else
            {
                locations = Cache.Locations;
            }
            var font = new Font("Dubai", 14, FontStyle.Underline);
            var font2 = new Font("Dubai", 12);

            var locationLbl = lblLokacije.Location;
            var hallsLbl = lblDvorane.Location;
            var index = 0;

            foreach (var location in locations!)
            {
                var cbLocation = new CheckBox();
                cbLocation.Text = $"{location.Name} - {location.City.Name}";
                cbLocation.Font = font;
                cbLocation.Checked = true;
                cbLocation.AutoSize = true;
                cbLocation.Width = 200;
                cbLocation.Height = 40;
                cbLocation.Location = new Point(locationLbl.X, locationLbl.Y + lblLokacije.Height + (index * cbLocation.Height));

                var cmbHalls = new ComboBox();
                cmbHalls.Font = font2;
                cmbHalls.Margin = new Padding(0, 0, 0, 10);

                cmbHalls.DataSource = location.Halls;

                cmbHalls.ValueMember = "Id";
                cmbHalls.DisplayMember = "Name";
                cmbHalls.DataSource = location.Halls;
                cmbHalls.Height = 25;

                cmbHalls.Location = new Point(hallsLbl.X, hallsLbl.Y + lblDvorane.Height + (index * cmbHalls.Height) + index * 5);

                index += 1;

                var tuple = new Tuple<CheckBox, ComboBox>(cbLocation, cmbHalls);
                LocationHalls.Add(tuple);

                this.Controls.Add(cbLocation);
                this.Controls.Add(cmbHalls);
            }
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                return;

            var projectionInsert = new ProjectionInsertObject();

            projectionInsert.Price = numCijena.Value;
            projectionInsert.MovieId = (int)cmbFilm.SelectedValue!;
            projectionInsert.ProjectionTypeId = (int)cmbVrstaProjekcije.SelectedValue!;
            projectionInsert.StartsAt = dtpVrijeme.Value;
            projectionInsert.ProjectionDate = dtpDatumProjekcije.Value;
            projectionInsert.Locations = new List<LocationHallInsertObject>();

            foreach (var locationHall in LocationHalls)
            {
                if (locationHall.Item1.Checked)
                {
                    var location = Cache.Locations.Single(l => l.Name == locationHall.Item1.Text.Substring(0, locationHall.Item1.Text.IndexOf(" -")));

                    var locationHallInsert = new LocationHallInsertObject
                    {
                        LocationId = location.Id,
                        HallId = (int)locationHall.Item2.SelectedValue!
                    };

                    projectionInsert.Locations.Add(locationHallInsert);
                }
            }
            var projection = await ProjectionService.Post<ProjectionDto>(projectionInsert);

            if (projection != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cmbFilm_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbFilm.SelectedValue == null)
            {
                e.Cancel = true;
                cmbFilm.Focus();
                errorProvider.SetError(cmbFilm, "Film nije odabran");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbFilm, "");
            }
        }

        private void cmbVrstaProjekcije_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbVrstaProjekcije.SelectedValue == null)
            {
                e.Cancel = true;
                cmbVrstaProjekcije.Focus();
                errorProvider.SetError(cmbVrstaProjekcije, "Vrsta projekcije nije odabrana");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbVrstaProjekcije, "");
            }
        }

        private void numCijena_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numCijena.Value == 0)
            {
                e.Cancel = true;
                numCijena.Focus();
                errorProvider.SetError(numCijena, "Cijena ne smije biti 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(numCijena, "");
            }
        }
    }
}
