using IclPaths.UI.Models;

namespace IclPaths.UI.Services
{
    public interface IRegionRepository
    {
        Task<List<RegionViewModel>> GetAllAsync();
        Task<RegionViewModel?> GetByIdAsync(Guid id);
        Task<RegionViewModel?> AddRegion(RegionViewModel regionViewModel);
        Task<RegionViewModel?> UpdateRegion(RegionViewModel regionViewModel);
        Task<RegionViewModel?> DeleteRegion(Guid regionId);
    }
}
