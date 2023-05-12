using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Properties;
using KinoPlus.WinUI.Utils;
using System.Net.Http.Json;

namespace KinoPlus.WinUI
{
    public partial class frmFilmUpsert : Form
    {
        public APIService MovieService { get; set; } = new APIService("movies");
        public Guid? MovieImageId { get; set; }
        public bool isEdit { get; set; }
        public int? EditMovieId { get; set; }

        public frmFilmUpsert(int? movieId = null)
        {
            InitializeComponent();
            if (movieId != null)
            {
                isEdit = true;
                EditMovieId = movieId;
                this.Text = "Edit Film";
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
            rtbOpis.Text = movie.Description;
            numPopularnost.Value = (decimal)movie.Popularity;
            pcbSlika.ImageLocation = $"{Settings.Default.ApiUrl}images/{movie.ImageId}";
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
            if (checkValidation() == false) return;

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
