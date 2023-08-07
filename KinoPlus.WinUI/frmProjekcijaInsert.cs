using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;

namespace KinoPlus.WinUI
{
    public partial class frmProjekcijaInsert : Form
    {
        public APIService ProjectionService { get; set; } = new APIService("projections");
        public APIService LocationService { get; set; } = new APIService("locations");
        public List<Tuple<CheckBox, ComboBox>> LocationHalls { get; set; } = new List<Tuple<CheckBox, ComboBox>>();

        public frmProjekcijaInsert()
        {
            InitializeComponent();

            dtpDatumZavrsava.Value = dtpDatumZavrsava.Value.AddMonths(1);
            dtpDatumPocinje.Visible = false;
            dtpDatumZavrsava.Visible = false;
            cmbDan.Visible = false;

            lblDatumPocinje.Visible = false;
            lblDatumZavrsava.Visible = false;
            lblDan.Visible = false;
        }

        private async void frmProjekcijaInsert_Load(object sender, EventArgs e)
        {
            await loadMovies();
            await loadProjectionTypes();
            await loadLocations();
            await loadWeekDays();
        }

        public async Task loadWeekDays()
        {
            await ListControlHelper.loadControlEntity<WeekDayDto>(cmbDan, "WeekDays", "Name", true);
        }

        public async Task loadMovies()
        {
            await ListControlHelper.loadControlEntity<MovieDto>(cmbFilm, "Movies", "Title");
        }

        public async Task loadProjectionTypes()
        {
            await ListControlHelper.loadControlEntity<ProjectionTypeDto>(cmbVrstaProjekcije, "ProjectionTypes", "Name");
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
            var font = new Font("Dubai", 12, FontStyle.Underline);
            var font2 = new Font("Dubai", 11);

            var locationLbl = lblLokacije.Location;
            var hallsLbl = lblDvorane.Location;
            var index = 0;

            foreach (var location in locations!)
            {
                var cmbHalls = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    FlatStyle = FlatStyle.Flat,
                    Font = font2,
                    DataSource = location.Halls,
                    ValueMember = "Id",
                    DisplayMember = "Name",
                    Width = 170
                };

                cmbHalls.DataSource = location.Halls;

                var cbLocation = new CheckBox
                {
                    Text = $"{location.Name} - {location.City.Name}",
                    Font = font,
                    Checked = true,
                    Width = hallsLbl.X - locationLbl.X - 10,
                    Height = cmbHalls.Height,
                };

                var itemYLocation = (index * cmbHalls.Height + index * 10) + 10;

                cbLocation.Location = new Point(10, itemYLocation);
                cmbHalls.Location = new Point(cbLocation.Width + 20, itemYLocation);

                cbLocation.CheckedChanged += cbLokacijaCheckedChange!;

                index += 1;

                var tuple = new Tuple<CheckBox, ComboBox>(cbLocation, cmbHalls);
                LocationHalls.Add(tuple);

                this.panel.Controls.Add(cbLocation);
                this.panel.Controls.Add(cmbHalls);
            }
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                return;

            if (LocationHalls.All(lh => lh.Item1.Checked == false))
            {
                MessageBox.Show("Odaberite barem jednu lokaciju za prikaz projekcije", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var projectionInsert = new ProjectionInsertObject
            {
                Price = numCijena.Value,
                MovieId = (int)cmbFilm.SelectedValue!,
                ProjectionTypeId = (int)cmbVrstaProjekcije.SelectedValue!,
                ProjectionTime = dtpVrijeme.Value,
                ProjectionDate = dtpDatumProjekcije.Value,
                IsRecurring = cbRedovnaProjekcija.Checked,
                StartingDate = dtpDatumPocinje.Value,
                EndingDate = dtpDatumZavrsava.Value,
                WeekDayId = (int?)cmbDan.SelectedValue,
                Locations = new List<LocationHallInsertObject>()
            };

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

        private void cbRedovnaProjekcija_CheckedChanged(object sender, EventArgs e)
        {
            dtpDatumProjekcije.Visible = !dtpDatumProjekcije.Visible;

            dtpDatumPocinje.Visible = !dtpDatumPocinje.Visible;
            dtpDatumZavrsava.Visible = !dtpDatumZavrsava.Visible;
            cmbDan.Visible = !cmbDan.Visible;

            lblDatumProjekcije.Visible = !lblDatumProjekcije.Visible;
            lblDatumPocinje.Visible = !lblDatumPocinje.Visible;
            lblDatumZavrsava.Visible = !lblDatumZavrsava.Visible;
            lblDan.Visible = !lblDan.Visible;
        }

        private void cbLokacijaCheckedChange(object sender, EventArgs e)
        {
            foreach (var locationHall in LocationHalls)
            {
                if (sender == locationHall.Item1)
                {
                    locationHall.Item2.Enabled = !locationHall.Item2.Enabled;
                }
            }
        }
    }
}