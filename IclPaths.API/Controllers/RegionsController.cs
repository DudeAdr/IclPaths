using AutoMapper;
using IclPaths.API.Domain.Interfaces.RegionInterfaces;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.RegionDTOs;
using IclPaths.API.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IclPathsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IclPathsDbContext dbContext, IMapper mapper, IRegionRepository regionRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();
            var mapped = _mapper.Map<List<RegionDto>>(regions);
            return Ok(mapped);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegion([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<RegionDto>(region);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionDto addRegionRequestDto)
        {
            var region = await _regionRepository.AddAsync(addRegionRequestDto);
            var regionDto = _mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionRequestDto)
        {
            var regionModel = await _regionRepository.UpdateAsync(id, updateRegionRequestDto);
            if (regionModel == null)
            {
                return NotFound();
            }
            var regionModelDto = _mapper.Map<RegionDto>(regionModel);

            return Ok(regionModelDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionModel = await _regionRepository.DeleteAsync(id);
            if (regionModel == null)
            {
                return NotFound();
            }
            var regionModelDto = _mapper.Map<RegionDto>(regionModel);
            return Ok(regionModelDto);
        }
    }
}
