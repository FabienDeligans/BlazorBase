using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BlazorBase.Areas.Identity.Manage
{
    public partial class ManageRoleToUser
    {
        private List<string> ListUsers { get; set; }
        private List<string> ListRoles { get; set; }
        private List<string> ListRolesOfUser { get; set; } = new List<string>();

        private IdentityUser User { get; set; }
        private IdentityRole Role { get; set; }
        public List<string> ListToSave { get; set; }
        public string? Email { get; set; }

        protected override void OnInitialized()
        {
            ListUsers = UserManager.Users.OrderBy(v => v.UserName).Select(v => v.Email).ToList();
            ListRoles = RoleManager.Roles.OrderBy(v => v.Name).Select(v => v.Name).ToList();

            User = new IdentityUser();
            Role = new IdentityRole();
        }

        private async Task GetRole(ChangeEventArgs obj)
        {
            if (!string.IsNullOrEmpty(obj.Value.ToString()))
            {
                var param = obj.Value.ToString();

                User = await UserManager.FindByEmailAsync(obj.Value.ToString());
                
                var listRole = await UserManager.GetRolesAsync(User);
                ListRolesOfUser = listRole.ToList();
            }
        }

        private void Valider()
        {
            var list = ListToSave; 
        }
    }
}
