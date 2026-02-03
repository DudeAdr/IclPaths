using IclPaths.API.Models.Domain;

namespace IclPaths.API.Models.DTO.WalkDTOs
{
    public class AddWalkPathDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? PathImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
