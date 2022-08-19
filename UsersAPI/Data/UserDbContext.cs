using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt) { }
    }
}
