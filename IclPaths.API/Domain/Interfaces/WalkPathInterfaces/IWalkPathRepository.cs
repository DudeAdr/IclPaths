using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Domain.Interfaces.WalkPathInterfaces
{
    public interface IWalkPathRepository
    {
        Task<WalkPathDto> AddWalkAsync(AddWalkPathDto addWalkPathRequestDto);
        Task<WalkPathDto?> GetWalkPathByIdAsync(Guid id);
        Task<WalkPathDto?> UpdateWalkPathAsync(Guid id, UpdateWalkPathDto updateWalkPathRequestDto);
        Task<WalkPathDto?> DeleteWalkPathAsync(Guid id);
        Task<IEnumerable<WalkPathDto>> GetWalkPathsAsync(Guid? regionId, Guid? difficultyId);
        Task<IEnumerable<WalkPathDto>> GetAllWalkPathsAsync();

    }
}
