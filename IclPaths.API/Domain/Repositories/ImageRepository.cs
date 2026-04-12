using AutoMapper;
using IclPaths.API.Domain.Interfaces;
using IclPaths.API.Models.DomainModels.IclPathsDbModels;
using IclPaths.API.Models.DTO.ImageDTOs;
using IclPaths.API.Persistance;
using Microsoft.EntityFrameworkCore;

namespace IclPaths.API.Domain.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IclPathsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, IclPathsDbContext dbContext, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ImageUploadResponseDto> UploadAsync(ImageUploadRequestDto image)
        {
            var mappedImage = _mapper.Map<Image>(image);

            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",$"{mappedImage.FileName}{mappedImage.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create);

            await mappedImage.File.CopyToAsync(stream);

            var urlFilePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}/Images/{mappedImage.FileName}{mappedImage.FileExtension}";
            mappedImage.FilePath = urlFilePath;

            await _dbContext.Images.AddAsync(mappedImage);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ImageUploadResponseDto>(mappedImage);
        }
    }
}
