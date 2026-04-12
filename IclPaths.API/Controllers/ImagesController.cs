using IclPaths.API.CustomActionFilters;
using IclPaths.API.Domain.Interfaces;
using IclPaths.API.Domain.Repositories;
using IclPaths.API.Models.DTO.ImageDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        [HttpPost]
        [ValidateModel]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto file)
        {
            ValidateFileUpload(file);
            var okResponse = await _imageRepository.UploadAsync(file);

            return Ok(okResponse);
        }
        private void ValidateFileUpload(ImageUploadRequestDto file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(file.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported file type. Only .jpg, .jpeg, and .png are allowed.");
            }
            if (file.File.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("File", "File size exceeds the limit of 5MB.");
            }
        }
    }
}
