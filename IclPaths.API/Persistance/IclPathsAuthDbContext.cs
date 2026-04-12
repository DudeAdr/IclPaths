using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IclPaths.API.Persistance
{
    public class IclPathsAuthDbContext : IdentityDbContext
    {
        public IclPathsAuthDbContext(DbContextOptions<IclPathsAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminGuid = "ad03ff92-d9ae-4188-9ffc-ce1ca507dfe4";
            var readerGuid = "327a3010-1cea-4ffa-9234-57cb005ee1f9";

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = adminGuid, ConcurrencyStamp = adminGuid, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = readerGuid, ConcurrencyStamp = readerGuid, Name = "Reader", NormalizedName = "READER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
