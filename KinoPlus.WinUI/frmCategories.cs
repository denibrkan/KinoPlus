using eProdaja.WinUI;
using KinoPlus.Common.Resources.Strings;
using KinoPlus.Models;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmCategories : Form
    {
        public APIService APIService { get; set; } = new APIService("categories");
        public int PageNumber = 1;
        public int PageSize = 10;
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public frmCategories()
        {
            InitializeComponent();
        }

        private async void frmKategorije_Load(object sender, EventArgs e)
        {
            btnNazad.Enabled = false;
            await loadCategories();
        }

        public async Task loadCategories()
        {
            var search = txtTrazi.Text;
            var queryParams = new CategorySearchObject
            {
                Page = PageNumber,
                PageSize = PageSize,
                IncludeMovies = true,
                NameFTS = search
            };

            try
            {
                var categories = await APIService.Get<List<CategoryDto>>(queryParams);
                if (categories == null)
                    return;

                Categories = categories;
                var bindCategories = Categories
                    .Select(category => new
                    {
                        Id = category.Id,
                        Naziv = category.Name,
                        OrderPoeni = category.OrderPoints,
                        Prikazan = category.IsDisplayed,
                        BrojFilmova = category.Movies?.Count
                    })
                    .ToList();

                dgvKategorije.DataSource = bindCategories;

                dgvKategorije.Columns["Id"].Visible = false;
                dgvKategorije.Columns["OrderPoeni"].HeaderText = "Order poeni";
                dgvKategorije.Columns["BrojFilmova"].HeaderText = "Broj filmova";

                lblPaging.Text = "Stranica " + PageNumber;

                if (categories.Count < queryParams.PageSize)
                    btnNaprijed.Enabled = false;
                else
                    btnNaprijed.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show(Strings.LoadingError);
            }
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            await loadCategories();
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
            await loadCategories();
        }

        private async void btnNazad_Click(object sender, EventArgs e)
        {
            PageNumber -= 1;
            if (PageNumber == 1)
            {
                btnNazad.Enabled = false;
            }
            await loadCategories();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            var frmKategorijeUpsert = new frmCategoryUpsert(null);

            if (frmKategorijeUpsert.ShowDialog() == DialogResult.OK)
            {
                await loadCategories();
            }
        }

        private async void dgvKategorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var categoryId = dgvKategorije.Rows[e.RowIndex].Cells["Id"].Value as int?;

            var category = Categories.SingleOrDefault(c => c.Id == categoryId);
            var frmEdit = new frmCategoryUpsert(category);

            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                await loadCategories();
            }
        }

        private async void txtTrazi_TextChanged(object sender, EventArgs e)
        {
            await loadCategories();
        }
    }
}
