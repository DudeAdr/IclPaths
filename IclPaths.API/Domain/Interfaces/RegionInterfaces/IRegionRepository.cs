using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.RegionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Domain.Interfaces.RegionInterfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> AddAsync(AddRegionDto addRegionRequestDto);
        Task<Region?> UpdateAsync(Guid id, UpdateRegionDto updateRegionRequestDto);
        Task<Region?> DeleteAsync(Guid id);
    }
}
