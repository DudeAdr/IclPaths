using IclPaths.API.Models.DTO.RegionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Domain.Interfaces.RegionInterfaces
{
    public interface IRegionRepository
    {
        Task<List<RegionDto>?> GetAllAsync();
        Task<RegionDto?> GetByIdAsync(Guid id);
        Task<RegionDto> AddAsync(AddRegionDto addRegionRequestDto);
        Task<RegionDto?> UpdateAsync(Guid id, UpdateRegionDto updateRegionRequestDto);
        Task<RegionDto?> DeleteAsync(Guid id);
    }
}
