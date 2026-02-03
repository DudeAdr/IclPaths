namespace IclPaths.API.Models.DTO.WalkPathDTOs
{
    public class UpdateWalkPathDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? PathImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
