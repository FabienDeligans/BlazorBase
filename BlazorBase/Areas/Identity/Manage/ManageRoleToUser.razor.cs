using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BlazorBase.Areas.Identity.Manage
{
    public partial class ManageRoleToUser
    {
        public List<IdentityUser> ListUsers { get; set; }
        public List<IdentityUser> ListUsers2 { get; set; }
        public List<IdentityRole> ListRoles { get; set; }
        private List<string> ListRolesOfUser { get; set; } = new List<string>();

        private IdentityUser User { get; set; }
        private IdentityRole Role { get; set; }
        public List<string> ListToSave { get; set; }
        public string? Email { get; set; }

        [Inject]
        public UserManager<IdentityUser>? UserManager { get; set; }

        [Inject]
        public RoleManager<IdentityRole>? RoleManager { get; set; }

        protected override void OnInitialized()
        {
            ListUsers = UserManager.Users.OrderBy(v => v.UserName).ToList();
            ListRoles = RoleManager.Roles.OrderBy(v => v.Name).ToList();

            User = new IdentityUser();
            Role = new IdentityRole();

            ListUsers2 = new List<IdentityUser>();
            foreach (var identityUser in ListUsers)
            {
                ListUsers2.Add(identityUser);
            }
        }

        private async void GetRole(string userEmail)
        {
            User = await UserManager.FindByEmailAsync(userEmail);

            var listRole = await UserManager.GetRolesAsync(User);
            ListRolesOfUser = listRole.ToList();
            StateHasChanged();
        }

        private void Valider()
        {
            var list = ListToSave;
        }
    }
}
