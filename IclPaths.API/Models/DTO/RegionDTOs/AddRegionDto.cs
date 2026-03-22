using System.ComponentModel.DataAnnotations;

namespace IclPaths.API.Models.DTO.RegionDTOs
{
    public class AddRegionDto
    {
        [Required]
        [Length(3, 3, ErrorMessage = "Code has to be made of exactly 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
