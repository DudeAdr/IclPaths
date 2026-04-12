using System.ComponentModel.DataAnnotations;

namespace IclPaths.API.Models.DTO.ImageDTOs
{
    public class ImageUploadResponseDto
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FilePath { get; set; }
    }
}
