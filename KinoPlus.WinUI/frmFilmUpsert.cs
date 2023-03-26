using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Properties;
using System.Net.Http.Json;

namespace KinoPlus.WinUI
{
    public partial class frmFilmUpsert : Form
    {
        public APIService MovieService { get; set; } = new APIService("movies");
        public APIService YearService { get; set; } = new APIService("years");
        public APIService StatusService { get; set; } = new APIService("moviestatus");
        public APIService GenreService { get; set; } = new APIService("genres");
        public APIService CategoriesService { get; set; } = new APIService("categories");
        public APIService ActorsService { get; set; } = new APIService("actors");
        public Guid MovieImageId { get; set; }
        public bool isEdit { get; set; }
        public int? EditMovieId { get; set; }

        public frmFilmUpsert(int? movieId = null)
        {
            InitializeComponent();
            if (movieId != null)
            {
                isEdit = true;
                EditMovieId = movieId;
            }
        }

        private async void btnOdaberi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdSlika.ShowDialog() == DialogResult.OK)
                {
                    HttpClient client = new HttpClient();
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
            lbKategorija.SelectedValue = movie.Categories.Select(c => c.Id);
            lbZanr.SelectedValue = movie.Genres.Select(g => g.Id);
            lbUloge.SelectedValue = movie.Actors.Select(a => a.Id);
            rtbOpis.Text = movie.Description;
            pcbSlika.ImageLocation = $"{Settings.Default.ApiUrl}images/{movie.ImageId}";
            MovieImageId = movie.ImageId;
        }

        public async Task loadStatuses()
        {
            List<MovieStatusDto>? statuses;
            if (!Cache.MovieStatuses.Any())
            {
                statuses = await StatusService.Get<List<MovieStatusDto>>();
                if (statuses != null)
                    Cache.MovieStatuses = statuses;
            }
            else
            {
                statuses = Cache.MovieStatuses;
            }
            cmbStatus.ValueMember = "Id";
            cmbStatus.DisplayMember = "Name";
            cmbStatus.DataSource = statuses;
            cmbStatus.SelectedIndex = -1;
        }

        public async Task loadYears()
        {
            List<YearDto>? years;
            if (!Cache.Years.Any())
            {
                years = await YearService.Get<List<YearDto>>();
                if (years != null)
                    Cache.Years = years;
            }
            else
            {
                years = Cache.Years;
            }
            cmbGodina.ValueMember = "Id";
            cmbGodina.DisplayMember = "Name";
            cmbGodina.DataSource = years;
            cmbGodina.SelectedIndex = -1;
        }

        public async Task loadGenres()
        {
            List<GenreDto>? genres;
            if (!Cache.Genres.Any())
            {
                genres = await GenreService.Get<List<GenreDto>>();
                if (genres != null)
                    Cache.Genres = genres;
            }
            else
            {
                genres = Cache.Genres;
            }
            lbZanr.ValueMember = "Id";
            lbZanr.DisplayMember = "Name";
            lbZanr.DataSource = genres;
            lbZanr.SelectedIndex = -1;
        }

        public async Task loadCategories()
        {
            List<CategoryDto>? categories;
            if (!Cache.Categories.Any())
            {
                categories = await CategoriesService.Get<List<CategoryDto>>();
                if (categories != null)
                    Cache.Categories = categories;
            }
            else
            {
                categories = Cache.Categories;
            }
            lbKategorija.ValueMember = "Id";
            lbKategorija.DisplayMember = "Name";
            lbKategorija.DataSource = categories;
            lbKategorija.SelectedIndex = -1;
        }

        public async Task loadActors()
        {
            List<ActorDto>? actors;
            if (!Cache.Actors.Any())
            {
                actors = await ActorsService.Get<List<ActorDto>>();
                if (actors != null)
                    Cache.Actors = actors;
            }
            else
            {
                actors = Cache.Actors;
            }
            lbUloge.ValueMember = "Id";
            lbUloge.DisplayMember = "Name";
            lbUloge.DataSource = actors;
            lbUloge.SelectedIndex = -1;
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            if (checkValidation() == false) return;

            var movie = new MovieUpsertObject();

            movie.Title = txtNaziv.Text;
            movie.Duration = (int)numTrajanje.Value;
            movie.TrailerUrl = txtTrailer.Text;
            movie.StatusId = (int)cmbStatus.SelectedValue!;
            movie.YearId = (int)cmbGodina.SelectedValue!;
            movie.Description = rtbOpis.Text;
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
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void rtbOpis_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(rtbOpis.Text))
            {
                e.Cancel = true;
                rtbOpis.Focus();
                errorProvider.SetError(rtbOpis, "Opis nije unesen");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(rtbOpis, "");
            }
        }

        private bool checkValidation()
        {
            return ValidateChildren(ValidationConstraints.Enabled);
        }

        private void cmbGodina_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbGodina.SelectedValue == null)
            {
                e.Cancel = true;
                cmbGodina.Focus();
                errorProvider.SetError(cmbGodina, "Godina nije odabrana");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbGodina, "");
            }
        }

        private void txtNaziv_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                e.Cancel = true;
                txtNaziv.Focus();
                errorProvider.SetError(txtNaziv, "Naziv nije unesen");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNaziv, "");
            }
        }

        private void cmbStatus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbStatus.SelectedValue == null)
            {
                e.Cancel = true;
                cmbStatus.Focus();
                errorProvider.SetError(cmbStatus, "Status nije odabran");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbStatus, "");
            }
        }

        private void numTrajanje_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numTrajanje.Value == 0)
            {
                e.Cancel = true;
                numTrajanje.Focus();
                errorProvider.SetError(numTrajanje, "Trajanje ne moze biti 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(numTrajanje, "");
            }
        }

        private void pcbSlika_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (pcbSlika.Image == null)
            {
                e.Cancel = true;
                pcbSlika.Focus();
                errorProvider.SetError(pcbSlika, "Slika nije odabrana");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(pcbSlika, "");
            }
        }
    }
}
