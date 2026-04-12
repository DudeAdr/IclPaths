using System.ComponentModel.DataAnnotations.Schema;

namespace IclPaths.API.Models.DomainModels.IclPathsDbModels
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string? FileExtension { get; set; }
        //FileSize in bytes
        public long FileSize { get; set; }
        public string FilePath { get; set; }
    }
}
