using System.ComponentModel.DataAnnotations;

namespace IclPaths.API.Models.DTO.WalkPathDTOs
{
    public class UpdateWalkPathDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description has to be maximum of 1000 characters")]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? PathImageUrl { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
    }
}
