using Asp.Versioning;
using IclPaths.API.CustomActionFilters;
using IclPaths.API.Domain.Interfaces.RegionInterfaces;
using IclPaths.API.Models.DTO.RegionDTOs;
using IclPaths.API.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IclPathsDbContext dbContext, IRegionRepository regionRepository, ILogger<RegionsController> logger)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Admin")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();
            return Ok(regions);
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Admin")]
        [Route("{id:Guid}")]
        [NotFoundIfNull]
        public async Task<IActionResult> GetRegion([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            return Ok(region);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionDto addRegionRequestDto)
        {
            var region = await _regionRepository.AddAsync(addRegionRequestDto);
            return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, region);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id:Guid}")]
        [ValidateModel]
        [NotFoundIfNull]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionRequestDto)
        {
            var regionModel = await _regionRepository.UpdateAsync(id, updateRegionRequestDto);
            return Ok(regionModel);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:Guid}")]
        [NotFoundIfNull]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionModel = await _regionRepository.DeleteAsync(id);
            return Ok(regionModel);
        }
    }
}
