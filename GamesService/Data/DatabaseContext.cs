using GamesService.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add new models here
        public DbSet<GameModel> Games { get; set; }

    }
}
