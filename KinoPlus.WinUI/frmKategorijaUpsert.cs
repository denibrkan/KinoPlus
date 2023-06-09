﻿using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Utils;

namespace KinoPlus.WinUI
{
    public partial class frmKategorijaUpsert : Form
    {
        public APIService CategoryService { get; set; } = new APIService("categories");
        public bool IsEdit { get; set; }
        public CategoryDto? EditCategory { get; set; }

        public frmKategorijaUpsert(CategoryDto? category)
        {
            InitializeComponent();

            if (category != null)
            {
                IsEdit = true;
                EditCategory = category;
                this.Text = "Edit Kategorija";
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
            var category = new CategoryUpsertObject();

            category.Name = txtNaziv.Text;
            category.MovieIds = lbFilmovi.SelectedItems.Cast<MovieDto>().Select(h => h.Id).ToArray();
            category.OrderPoints = (int)numOrderPoints.Value;
            category.IsDisplayed = cbPrikazan.Checked;

            CategoryDto? categoryDto;
            if (IsEdit)
            {
                categoryDto = await CategoryService.Update<CategoryDto>(EditCategory!.Id, category);
            }
            else
            {
                categoryDto = await CategoryService.Post<CategoryDto>(category);
            }
            if (categoryDto != null)
            {
                Cache.Remove<CategoryDto>();
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
