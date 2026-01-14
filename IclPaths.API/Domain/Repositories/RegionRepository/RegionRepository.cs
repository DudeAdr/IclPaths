using AutoMapper;
using IclPaths.API.Domain.Interfaces.RegionInterfaces;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.RegionDTOs;
using IclPaths.API.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IclPaths.API.Domain.Repositories.RegionRepository
{
    public class RegionRepository : IRegionRepository
    {
        private IclPathsDbContext _dbContext;
        private IMapper _mapper;

        public RegionRepository(IclPathsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Region> AddAsync(AddRegionDto addRegionRequestDto)
        {
            var region = _mapper.Map<Region>(addRegionRequestDto);

            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var regionModel = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (regionModel == null)
            {
                return null;
            }
            _dbContext.Regions.Remove(regionModel);
            await _dbContext.SaveChangesAsync();
            return regionModel;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, UpdateRegionDto updateRegionRequestDto)
        {
            var regionModel = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (regionModel == null)
            {
                return null;
            }

            regionModel.Code = updateRegionRequestDto.Code;
            regionModel.Name = updateRegionRequestDto.Name;
            regionModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            return regionModel;
        }
    }
}
