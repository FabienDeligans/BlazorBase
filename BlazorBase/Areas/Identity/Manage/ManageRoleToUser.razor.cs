using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BlazorBase.Areas.Identity.Manage
{
    public partial class ManageRoleToUser
    {
        private string? _pass;
        private List<string> ListUsers { get; set; }
        private List<string> ListRoles { get; set; }
        private List<string> DisplayRoles { get; set; } = new List<string>();
        private List<string> ListRolesOfUser { get; set; } = new List<string>();

        private IdentityUser User { get; set; }
        public List<string> ListToSave { get; set; }
        public string? Email { get; set; }

        protected override void OnInitialized()
        {
            ListUsers = UserManager.Users.OrderBy(v => v.UserName).Select(v => v.Email).ToList();
            ListRoles = RoleManager.Roles.OrderBy(v => v.Name).Select(v => v.Name).ToList();
            ListRolesOfUser = new List<string>();

            User = new IdentityUser();
        }


        private async Task GetRole(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                User = await UserManager.FindByEmailAsync(user);

                var listRole = await UserManager.GetRolesAsync(User);
                ListRolesOfUser = listRole.ToList();
            }
            await InvokeAsync(StateHasChanged);
        }

        private async Task RemoveRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                await UserManager.RemoveFromRoleAsync(User, role);

                await GetRole(User.Email);
            }
        }

        private async Task AddRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                await UserManager.AddToRoleAsync(User, role);

                await GetRole(User.Email);
            }
        }

        private async Task GetRoles(ChangeEventArgs obj)
        {
            var user = obj.Value.ToString();

            if (!string.IsNullOrEmpty(user))
            {
                User = await UserManager.FindByEmailAsync(user);

                var listRole = await UserManager.GetRolesAsync(User);
                ListRolesOfUser = listRole.ToList();
            }
            else
            {
                OnInitialized();
            }
            await InvokeAsync(StateHasChanged);

        }

        private async Task NewPassword(string newPassword)
        {
            await UserManager.RemovePasswordAsync(User);
            await UserManager.AddPasswordAsync(User, newPassword);
            _pass = "";
            await InvokeAsync(StateHasChanged);
        }

        private async Task RemoveUser()
        {
            await UserManager.DeleteAsync(User);
            await InvokeAsync(StateHasChanged);
        }
    }
}
