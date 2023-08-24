using eProdaja.WinUI;
using KinoPlus.Common.Resources.Strings;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmMovies : Form
    {
        public APIService APIService { get; set; } = new APIService("movies");
        private bool Loading = false;
        public int PageNumber = 1;
        public int PageSize = 10;

        public frmMovies()
        {
            InitializeComponent();
        }

        private async void frmFilmovi_Load(object sender, EventArgs e)
        {
            btnNazad.Enabled = false;
            Loading = true;
            await loadStatuses();
            await loadCategories();
            await loadMovies();
            Loading = false;
        }

        public async Task loadMovies()
        {
            var search = txtTrazi.Text;
            var statusId = (int?)(cmbStatus.SelectedValue);
            var categoryId = (int?)(cmbKategorija.SelectedValue);

            var queryParams = new MovieSearchObject
            {
                Page = PageNumber,
                PageSize = PageSize,
                TitleFTS = search,
                StatusId = statusId,
                CategoryId = categoryId,
            };

            try
            {
                var movies = await APIService.Get<List<MovieDto>>(queryParams);
                if (movies == null)
                    return;

                var bindMovies = movies
                    .Select(m => new
                    {
                        Id = m.Id,
                        Slika = m.ImageId != null ? ImageUtility.resizeImage(ImageUtility.GetImageById((Guid)m.ImageId!), new Size(50, 70)) : null,
                        Naziv = m.Title,
                        Zanr = string.Join(", ", m.Genres.Select(g => g.Name)),
                        Trajanje = m.Duration,
                        Godina = m.Year.Name,
                        Popularnost = $"{m.Popularity:F1}/10",
                        Kategorija = string.Join(", ", m.Categories.Select(g => g.Name)),
                        Status = m.Status.Name,
                        DatumDodavanja = m.DateCreated.ToShortDateString(),
                        Ocjena = m.AverageRating != 0 ? $"{m.AverageRating:F}/5" : "-",
                    })
                    .ToList();

                dgvMovies.DataSource = bindMovies;

                dgvMovies.Columns["Id"].Visible = false;
                dgvMovies.Columns["Slika"].HeaderText = "";
                dgvMovies.Columns["Zanr"].HeaderText = "Žanr";
                dgvMovies.Columns["DatumDodavanja"].HeaderText = "Datum dodavanja";
                dgvMovies.Columns["Naziv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMovies.Columns["Zanr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMovies.Columns["Kategorija"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMovies.Columns["DatumDodavanja"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                lblPaging.Text = "Stranica " + PageNumber;
                if (movies.Count < queryParams.PageSize)
                    btnNaprijed.Enabled = false;
                else
                    btnNaprijed.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show(Strings.LoadingError);
            }
        }

        public async Task loadStatuses()
        {
            await ListControlHelper.loadControlEntity<MovieStatusDto>(cmbStatus, "MovieStatus", "Name");
        }

        public async Task loadCategories()
        {
            await ListControlHelper.loadControlEntity<CategoryDto>(cmbKategorija, "Categories", "Name");
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            if (!Loading)
                await loadMovies();
        }

        private async void cmbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
                await loadMovies();
        }

        private async void cmbKategorija_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
                await loadMovies();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            txtTrazi.Text = string.Empty;
            PageNumber = 1;
            Loading = true;
            cmbKategorija.SelectedItem = null;
            cmbStatus.SelectedItem = null;

            await loadMovies();
            Loading = false;
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
            await loadMovies();
        }

        private async void btnNazad_Click(object sender, EventArgs e)
        {
            PageNumber -= 1;
            if (PageNumber == 1)
            {
                btnNazad.Enabled = false;
            }
            await loadMovies();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            var frmDodaj = new frmMovieUpsert();

            if (frmDodaj.ShowDialog() == DialogResult.OK)
            {
                await loadMovies();
            }
        }

        private async void dgvMovies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var movieId = dgvMovies.Rows[e.RowIndex].Cells["Id"].Value as int?;

            var frmEdit = new frmMovieUpsert(movieId);

            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                await loadMovies();
            }
        }

        private async void txtTrazi_TextChanged(object sender, EventArgs e)
        {
            await loadMovies();
        }
    }
}