﻿using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;

namespace KinoPlus.WinUI
{
    public partial class frmLocationUpsert : Form
    {
        public APIService LocationService { get; set; } = new APIService("locations");
        public bool IsEdit { get; set; }
        public int? EditLocationId { get; set; }

        public frmLocationUpsert(int? locationId = null)
        {
            InitializeComponent();

            if (locationId != null)
            {
                IsEdit = true;
                EditLocationId = locationId;
                this.Text = "Uredi Lokaciju";
            }
        }

        private async void frmLokacijaUpsert_Load(object sender, EventArgs e)
        {
            await loadCities();
            await loadProjectionTypes();
            await loadHalls();
            if (IsEdit)
            {
                await loadLocation(EditLocationId!.Value);
            }
        }

        public async Task loadLocation(int locationId)
        {
            var location = await LocationService.GetById<LocationDto>(locationId);
            txtNaziv.Text = location!.Name;
            txtAdresa.Text = location.Address;
            cmbGrad.SelectedValue = location.City.Id;
            foreach (var item in location.Halls)
            {
                lbDvorane.SelectedValue = item.Id;
            }
            foreach (var item in location.ProjectionTypes)
            {
                lbVrstaProjekcije.SelectedValue = item.Id;
            }
        }

        public async Task loadCities()
        {
            await ListControlHelper.loadControlEntity<CityDto>(cmbGrad, "Cities", "Name");
        }

        public async Task loadProjectionTypes()
        {
            await ListControlHelper.loadControlEntity<ProjectionTypeDto>(lbVrstaProjekcije, "ProjectionTypes", "Name");
        }

        public async Task loadHalls()
        {
            await ListControlHelper.loadControlEntity<HallDto>(lbDvorane, "Halls", "Name");
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var location = new LocationUpsertObject();

            location.Name = txtNaziv.Text;
            location.Address = txtAdresa.Text;
            location.CityId = (int)cmbGrad.SelectedValue!;
            location.ProjectionTypeIds = lbVrstaProjekcije.SelectedItems.Cast<ProjectionTypeDto>().Select(pt => pt.Id).ToArray();
            location.HallIds = lbDvorane.SelectedItems.Cast<HallDto>().Select(h => h.Id).ToArray();

            if (!location.ProjectionTypeIds.Any() || !location.HallIds.Any())
            {
                MessageBox.Show("Odaberite dvorane i vrste projekcije", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LocationDto? locationDto;
            if (IsEdit)
            {
                locationDto = await LocationService.Update<LocationDto>(EditLocationId!.Value, location);
            }
            else
            {
                locationDto = await LocationService.Post<LocationDto>(location);
            }
            if (locationDto != null)
            {
                Cache.Remove<LocationDto>();
                var message = !IsEdit ? "Uspješno dodana nova lokacija" : "Uspješno izmijenjena lokacija";
                MessageBox.Show(message);

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateForm()
        {
            return Validator.ValidateControl(txtNaziv, errorProvider, "Naziv nije unesen") &&
                    Validator.ValidateControl(txtAdresa, errorProvider, "Adresa nije unesena") &&
                Validator.ValidateControl(cmbGrad, errorProvider, "Grad nije odabran");
        }
    }
}
