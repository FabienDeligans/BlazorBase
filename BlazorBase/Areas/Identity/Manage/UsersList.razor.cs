using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BlazorBase.Areas.Identity.Manage
{
    public partial class UsersList
    {
        private List<IdentityUser> ListUsers { get; set; }
        private IdentityUser User { get; set; }
        protected override void OnInitialized()
        {
            ListUsers = UserManager.Users.OrderBy(v => v.UserName).ToList();

            User = new IdentityUser();
        }

        private void GetUser(ChangeEventArgs obj)
        {
            if (!string.IsNullOrEmpty(obj.Value.ToString()))
            {
                User = ListUsers.FirstOrDefault(v => v.Email == obj.Value.ToString()); 
            }
        }
    }
}
