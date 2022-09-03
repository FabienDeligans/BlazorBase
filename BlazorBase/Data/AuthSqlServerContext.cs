using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Data
{
    public class AuthSqlServerContext : IdentityDbContext
    {
        public AuthSqlServerContext(DbContextOptions<AuthSqlServerContext> options)
            : base(options)
        {
        }
    }
}