using Microsoft.EntityFrameworkCore;
using SessionService.Models;

namespace SessionService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add new models here
        public DbSet<SessionModel> Session { get; set; }
        public DbSet<PlayerModel> Player { get; set; }

    }
}
