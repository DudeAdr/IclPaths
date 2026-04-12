using IclPaths.API.Models.DomainModels.IclPathsDbModels;
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
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>().HasData(
                new Region
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Code = "IS-1",
                    Name = "Capital Region (Höfuðborgarsvæðið)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Capital%20Region%2C%20Iceland%20-%20panoramio%20(15).jpg"
                },
                new Region
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Code = "IS-2",
                    Name = "Southern Peninsula (Suðurnes)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Southern%20Peninsula%20Region%2C%20Iceland%20-%20panoramio.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Code = "IS-3",
                    Name = "Western Region (Vesturland)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Western%20Region%2C%20Iceland%20-%20panoramio.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Code = "IS-4",
                    Name = "Westfjords (Vestfirðir)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Westfjords%20Region%2C%20Iceland%20-%20panoramio%20(5).jpg"
                },
                new Region
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Code = "IS-5",
                    Name = "Northwestern Region (Norðurland vestra)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Northwestern%20Region%2C%20Iceland%20-%20panoramio.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    Code = "IS-6",
                    Name = "Northeastern Region (Norðurland eystra)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Northeastern%20Region%2C%20Iceland%20-%20panoramio%20(24).jpg"
                },
                new Region
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    Code = "IS-7",
                    Name = "Eastern Region (Austurland)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Eastern%20Region%2C%20Iceland%20-%20panoramio%20(1).jpg"
                },
                new Region
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    Code = "IS-8",
                    Name = "Southern Region (Suðurland)",
                    RegionImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/South%2C%20Iceland%20-%20panoramio.jpg"
                }
            );
            modelBuilder.Entity<Difficulty>().HasData(
    new Difficulty
    {
        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
        Name = "Easy"
    },
    new Difficulty
    {
        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
        Name = "Medium"
    },
    new Difficulty
    {
        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
        Name = "Hard"
    }
);
            modelBuilder.Entity<WalkPath>().HasData(
    new WalkPath
    {
        Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
        Name = "Laugavegur Trail",
        Description = "Iconic multi-day trek through geothermal valleys, mountains and glaciers.",
        LengthInKm = 55,
        PathImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Laugavegur_trail.jpg",
        RegionId = Guid.Parse("88888888-8888-8888-8888-888888888888"), // Southern
        DifficultyId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc") // Hard
    },
    new WalkPath
    {
        Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
        Name = "Fimmvörðuháls Pass",
        Description = "Mountain trail between two glaciers with waterfalls and volcanic landscapes.",
        LengthInKm = 25,
        PathImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Fimmvorduhals_hike.jpg",
        RegionId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
        DifficultyId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")
    },
    new WalkPath
    {
        Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
        Name = "Glymur Waterfall Hike",
        Description = "Hike to Iceland’s second-highest waterfall with river crossings and caves.",
        LengthInKm = 7.5,
        PathImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Glymur_waterfall_hike.jpg",
        RegionId = Guid.Parse("33333333-3333-3333-3333-333333333333"), // West
        DifficultyId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") // Medium
    },
    new WalkPath
    {
        Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
        Name = "Hornstrandir Coastal Trail",
        Description = "Remote Arctic wilderness hike with cliffs, foxes and dramatic coastline.",
        LengthInKm = 15,
        PathImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Hornstrandir_coast.jpg",
        RegionId = Guid.Parse("44444444-4444-4444-4444-444444444444"), // Westfjords
        DifficultyId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
    },
    new WalkPath
    {
        Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
        Name = "Mt. Esja Trail",
        Description = "Popular hike near Reykjavík with panoramic views over the capital region.",
        LengthInKm = 6.5,
        PathImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Mount_Esja_hike.jpg",
        RegionId = Guid.Parse("11111111-1111-1111-1111-111111111111"), // Capital
        DifficultyId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
    },
    new WalkPath
    {
        Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
        Name = "Dettifoss River Trail",
        Description = "Easy walk along Europe’s most powerful waterfall in a volcanic canyon.",
        LengthInKm = 3,
        PathImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Dettifoss_hike.jpg",
        RegionId = Guid.Parse("66666666-6666-6666-6666-666666666666"), // NE
        DifficultyId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") // Easy
    }
);
        }
    }
}
