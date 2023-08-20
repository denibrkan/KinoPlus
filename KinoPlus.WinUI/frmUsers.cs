using eProdaja.WinUI;
using KinoPlus.Models;
using KinoPlus.WinUI.Constants;
using KinoPlus.WinUI.Utils;
using System.Data;

namespace KinoPlus.WinUI
{
    public partial class frmUsers : Form
    {
        public APIService APIService { get; set; } = new APIService("users");
        public int PageNumber = 1;
        public int PageSize = 10;

        private bool _loading = false;

        public frmUsers()
        {
            InitializeComponent();
        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            btnNazad.Enabled = false;
            _loading = true;
            await loadRoles();
            await loadUsers();
            _loading = false;
        }

        public async Task loadUsers()
        {
            var search = txtTrazi.Text;
            var roleId = (int?)cmbRole.SelectedValue;
            object queryParams = new UserSearchObject
            {
                Page = PageNumber,
                PageSize = PageSize,
                NameFTS = search,
                RoleId = roleId
            };
            try
            {
                var users = await APIService.Get<List<UserDto>>(queryParams);
                var bindUsers = users?
                    .Select(user => new
                    {
                        Id = user.Id,
                        ImePrezime = $"{user.FirstName} {user.LastName}",
                        KorisnickoIme = user.Username,
                        Email = user.Email,
                        LoyaltyPoeni = user.LoyaltyPoints,
                        Filmovi = user.MovieCount,
                    })
                    .ToList();

                dgvKorisnici.DataSource = bindUsers;

                dgvKorisnici.Columns["Id"].Visible = false;
                dgvKorisnici.Columns["ImePrezime"].HeaderText = "Ime prezime";
                dgvKorisnici.Columns["KorisnickoIme"].HeaderText = "Korisnicko ime";
                dgvKorisnici.Columns["LoyaltyPoeni"].HeaderText = "Loyalty poeni";

                lblPaging.Text = "Stranica " + PageNumber;
            }
            catch (Exception)
            {
                MessageBox.Show(ErrorMessages.LoadingError);
            }

        }

        public async Task loadRoles()
        {
            await ListControlHelper.loadControlEntity<RoleDto>(cmbRole, "Roles", "Name");
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            await loadUsers();
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
            await loadUsers();
        }

        private async void btnNazad_Click(object sender, EventArgs e)
        {
            PageNumber -= 1;
            if (PageNumber == 1)
            {
                btnNazad.Enabled = false;
            }
            await loadUsers();
        }

        private async void cmbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_loading)
                await loadUsers();
        }
    }
}
