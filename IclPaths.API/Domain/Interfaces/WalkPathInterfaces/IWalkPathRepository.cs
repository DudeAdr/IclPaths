using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using IclPaths.API.Models.Enums;
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
        Task<IEnumerable<WalkPathDto>> GetAllWalkPathsAsync(SortAndFilterBy? filterOn = null, string? filterQuery = null, SortAndFilterBy? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

    }
}
