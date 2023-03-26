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

        public frmFilmUpsert()
        {
            InitializeComponent();
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

            var insertedMovie = await MovieService.Post<MovieDto>(movie);

            if (insertedMovie != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
