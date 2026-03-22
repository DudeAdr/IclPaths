using System.ComponentModel.DataAnnotations;

namespace IclPaths.API.Models.DTO.RegionDTOs
{
    public class AddRegionDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
