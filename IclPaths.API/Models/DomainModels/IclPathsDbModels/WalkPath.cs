namespace IclPaths.API.Models.DomainModels.IclPathsDbModels
{
    public class WalkPath
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? PathImageUrl { get; set; }

        // RELATIONSHIPS
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public Guid DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
