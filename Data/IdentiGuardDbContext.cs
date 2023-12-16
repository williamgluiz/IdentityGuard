using IdentityGuard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityGuard.Data
{
    public class IdentiGuardDbContext : IdentityDbContext<User>
    {
        public IdentiGuardDbContext(DbContextOptions<IdentiGuardDbContext> options) : base(options)
        {
        }
    }
}
