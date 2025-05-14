using Microsoft.EntityFrameworkCore;
using SmartMotoZone.API.Models;

namespace SmartMotoZone.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Moto> Motos { get; set; }
    }
}

