﻿using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Properties;
using KinoPlus.WinUI.Utils;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace KinoPlus.WinUI
{
    public partial class frmMovieUpsert : Form
    {
        public APIService MovieService { get; set; } = new APIService("movies");
        public Guid? MovieImageId { get; set; }
        public bool isEdit { get; set; }
        public int? EditMovieId { get; set; }

        public frmMovieUpsert(int? movieId = null)
        {
            InitializeComponent();
            if (movieId != null)
            {
                isEdit = true;
                EditMovieId = movieId;
                this.Text = "Uredi Film";
            }
        }

        private async void btnOdaberi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdSlika.ShowDialog() == DialogResult.OK)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIService.Token);

                    var multiForm = new MultipartFormDataContent();

                    var files = ofdSlika.FileNames;
                    foreach (var file in files)
                    {
                        FileStream fs = File.OpenRead(file);
                        multiForm.Add(new StreamContent(fs), "images", Path.GetFileName(file));
                    }
                    var url = Settings.Default.ApiUrl + "images";
                    var response = await client.PostAsync(url, multiForm);
                    if (response.IsSuccessStatusCode)
                    {
                        pcbSlika.ImageLocation = ofdSlika.FileName;
                        var imageIds = await response.Content.ReadFromJsonAsync<List<Guid>>();
                        MovieImageId = imageIds!.First();
                    }
                    else
                    {
                        MessageBox.Show(response.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frmFilmUpsert_Load(object sender, EventArgs e)
        {
            await loadStatuses();
            await loadYears();
            await loadGenres();
            await loadCategories();
            await loadActors();
            if (isEdit)
                await loadMovie(EditMovieId!.Value);

        }

        public async Task loadMovie(int movieId)
        {
            var movie = await MovieService.GetById<MovieDto>(movieId);

            txtNaziv.Text = movie!.Title;
            numTrajanje.Value = movie.Duration;
            txtTrailer.Text = movie.TrailerUrl;
            cmbGodina.SelectedValue = movie.Year.Id;
            cmbStatus.SelectedValue = movie.Status.Id;
            rtbOpis.Text = movie.Description;
            numPopularnost.Value = (decimal)movie.Popularity;
            pcbSlika.Image = movie.ImageId != null ?
                    ImageUtility.GetImageById((Guid)movie.ImageId!)
                    : null;
            MovieImageId = movie.ImageId;
            foreach (var item in movie.Categories)
            {
                lbKategorija.SelectedValue = item.Id;
            }
            foreach (var item in movie.Actors)
            {
                lbUloge.SelectedValue = item.Id;
            }
            foreach (var item in movie.Genres)
            {
                lbZanr.SelectedValue = item.Id;
            }

        }

        public async Task loadStatuses()
        {
            await ListControlHelper.loadControlEntity<MovieStatusDto>(cmbStatus, "MovieStatus", "Name");
        }

        public async Task loadYears()
        {
            await ListControlHelper.loadControlEntity<YearDto>(cmbGodina, "Years", "Name");
        }

        public async Task loadGenres()
        {
            await ListControlHelper.loadControlEntity<GenreDto>(lbZanr, "Genres", "Name");
        }

        public async Task loadCategories()
        {
            await ListControlHelper.loadControlEntity<CategoryDto>(lbKategorija, "Categories", "Name");
        }

        public async Task loadActors()
        {
            await ListControlHelper.loadControlEntity<ActorDto>(lbUloge, "Actors", "Name");
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var movie = new MovieUpsertObject();

            movie.Title = txtNaziv.Text;
            movie.Duration = (int)numTrajanje.Value;
            movie.TrailerUrl = txtTrailer.Text;
            movie.StatusId = (int)cmbStatus.SelectedValue!;
            movie.YearId = (int)cmbGodina.SelectedValue!;
            movie.Description = rtbOpis.Text;
            movie.Popularity = (double)numPopularnost.Value;
            movie.CategoryIds = lbKategorija.SelectedItems.Cast<CategoryDto>().Select(c => c.Id).ToArray();
            movie.GenreIds = lbZanr.SelectedItems.Cast<GenreDto>().Select(g => g.Id).ToArray();
            movie.ActorIds = lbUloge.SelectedItems.Cast<ActorDto>().Select(a => a.Id).ToArray();
            movie.ImageId = MovieImageId;

            MovieDto? movieDto;
            if (isEdit)
            {
                movieDto = await MovieService.Update<MovieDto>(EditMovieId!.Value, movie);
            }
            else
            {
                movieDto = await MovieService.Post<MovieDto>(movie);
            }
            if (movieDto != null)
            {
                Cache.Remove<MovieDto>();
                var message = !isEdit ? "Uspješno dodan novi film" : "Uspješno izmijenjen film";
                MessageBox.Show(message);

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateForm()
        {
            return Validator.ValidateControl(pcbSlika, errorProvider, "Slika nije odabrana") &&
                Validator.ValidateControl(txtNaziv, errorProvider, "Naziv nije unesen") &&
                Validator.ValidateControl(cmbGodina, errorProvider, "Godina nije odabrana") &&
                Validator.ValidateControl(numTrajanje, errorProvider, "Trajanje ne smije biti 0") &&
                Validator.ValidateControl(cmbStatus, errorProvider, "Status nije odabran") &&
                Validator.ValidateControl(rtbOpis, errorProvider, "Opis nije unesen");
        }
    }
}