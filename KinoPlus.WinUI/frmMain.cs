namespace KinoPlus.WinUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            projekcijeToolStripMenuItem.BackColor = Color.MidnightBlue;
            projekcijeToolStripMenuItem.ForeColor = Color.White;

            projekcijeToolStripMenuItem_Click(sender, e);

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in ((ToolStrip)sender).Items)
            {
                if (item != e.ClickedItem)
                {
                    item.BackColor = Color.FromName("Control");
                    item.ForeColor = Color.Black;
                }
                else
                {
                    item.BackColor = Color.MidnightBlue;
                    item.ForeColor = Color.White;
                }
            }
        }

        private void filmoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmFilmovi = new frmMovies();
            frmFilmovi.MdiParent = this;
            frmFilmovi.WindowState = FormWindowState.Maximized;

            frmFilmovi.Show();
        }

        private void kategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmKategorije = new frmCategories();
            frmKategorije.MdiParent = this;
            frmKategorije.WindowState = FormWindowState.Maximized;

            frmKategorije.Show();
        }

        private void projekcijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmProjekcije = new frmProjections();
            frmProjekcije.MdiParent = this;
            frmProjekcije.WindowState = FormWindowState.Maximized;

            frmProjekcije.Show();
        }

        private void lokacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmLokacije = new frmLocations();
            frmLokacije.MdiParent = this;
            frmLokacije.WindowState = FormWindowState.Maximized;

            frmLokacije.Show();
        }

        private void izvještajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmIzvjestaji = new frmReports();
            frmIzvjestaji.MdiParent = this;
            frmIzvjestaji.WindowState = FormWindowState.Maximized;

            frmIzvjestaji.Show();
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmKorisnici = new frmUsers();
            frmKorisnici.MdiParent = this;
            frmKorisnici.WindowState = FormWindowState.Maximized;

            frmKorisnici.Show();
        }
    }
}
