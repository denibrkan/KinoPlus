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
            filmoviToolStripMenuItem.BackColor = Color.MidnightBlue;
            filmoviToolStripMenuItem.ForeColor = Color.White;

            filmoviToolStripMenuItem_Click(sender, e);

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

            var frmFilmovi = new frmFilmovi();
            frmFilmovi.MdiParent = this;

            frmFilmovi.Show();
        }

        private void kategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild?.Close();

            var frmKategorije = new frmKategorije();
            frmKategorije.MdiParent = this;

            frmKategorije.Show();
        }

    }
}
