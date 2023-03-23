using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmFilmovi : Form
    {
        public APIService APIService { get; set; } = new APIService("movies");

        public frmFilmovi()
        {
            InitializeComponent();
        }

        private void frmFilmovi_Load(object sender, EventArgs e)
        {
            checkScreenSize();
            loadMovies();
        }

        public async void loadMovies()
        {
            var movies = Cache.Movies;

            if (movies?.Any() == false)
            {
                movies = await APIService.Get<List<MovieDto>>();
                Cache.Movies = movies!;
            }

            var bindMovies = movies!.Select(m => new
            {
                Slika = ImageUtility.Base64ToImage(m.Image, 55, 80),
                Naziv = m.Title,
                Zanr = string.Join(", ", m.Genres.Select(g => g.Name)),
                Trajanje = m.Duration,
                Godina = m.Year,
                Kategorija = string.Join(", ", m.Categories.Select(g => g.Name)),
                Status = m.Status.Name,
                DatumDodavanja = DateTime.Now,
                Ocjena = m.AverageRating != 0 ? m.AverageRating.ToString() + "/5" : "-",
            }).ToList();


            dgvMovies.DataSource = bindMovies;

            dgvMovies.Columns["Slika"].HeaderText = "";
            dgvMovies.Columns["Naziv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovies.Columns["Zanr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMovies.Columns["Kategorija"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void checkScreenSize()
        {
            var screenSize = Screen.PrimaryScreen!.WorkingArea.Size;
            dgvMovies.Size = new Size(screenSize.Width - 300, (int)(screenSize.Height * 0.6));
            btnDodaj.Location = new Point(dgvMovies.Size.Width + 100 - btnDodaj.Width, btnDodaj.Location.Y);
        }

    }
}
