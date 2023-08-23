using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;

namespace KinoPlus.WinUI
{
    public partial class frmCategoryUpsert : Form
    {
        public APIService CategoryService { get; set; } = new APIService("categories");
        public bool IsEdit { get; set; }
        public CategoryDto? EditCategory { get; set; }

        public frmCategoryUpsert(CategoryDto? category)
        {
            InitializeComponent();

            if (category != null)
            {
                IsEdit = true;
                EditCategory = category;
                this.Text = "Uredi Kategoriju";
            }
        }

        private async void frmKategorijaUpsert_Load(object sender, EventArgs e)
        {
            await loadMovies();
            if (IsEdit)
            {
                loadCategory();
            }
        }

        public void loadCategory()
        {
            txtNaziv.Text = EditCategory!.Name;
            numOrderPoints.Value = EditCategory.OrderPoints;
            cbPrikazan.Checked = EditCategory.IsDisplayed;
            foreach (var item in EditCategory.Movies)
            {
                lbFilmovi.SelectedValue = item.Id;
            }
        }

        public async Task loadMovies()
        {
            await ListControlHelper.loadControlEntity<MovieDto>(lbFilmovi, "Movies", "Title");
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var category = new CategoryUpsertObject
            {
                Name = txtNaziv.Text,
                MovieIds = lbFilmovi.SelectedItems.Cast<MovieDto>().Select(h => h.Id).ToArray(),
                OrderPoints = (int)numOrderPoints.Value,
                IsDisplayed = cbPrikazan.Checked
            };

            CategoryDto? categoryDto;
            if (IsEdit)
                categoryDto = await CategoryService.Update<CategoryDto>(EditCategory!.Id, category);
            else
                categoryDto = await CategoryService.Post<CategoryDto>(category);

            if (categoryDto != null)
            {
                Cache.Remove<CategoryDto>();
                var message = !IsEdit ? "Uspješno dodana nova kategorija" : "Uspješno izmijenjena kategorija";
                MessageBox.Show(message);

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateForm()
        {
            return Validator.ValidateControl(txtNaziv, errorProvider, "Naziv nije unesen");
        }
    }
}
