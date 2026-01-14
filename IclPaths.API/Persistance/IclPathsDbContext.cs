using IclPaths.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IclPaths.API.Persistance
{
    public class IclPathsDbContext : DbContext
    {
        public IclPathsDbContext(DbContextOptions<IclPathsDbContext> options) : base(options)
        { 

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WalkPath> Paths { get; set; }
    } 
}
