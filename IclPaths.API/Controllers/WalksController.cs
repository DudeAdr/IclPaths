using IclPaths.API.CustomActionFilters;
using IclPaths.API.Domain.Interfaces.WalkPathInterfaces;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using IclPaths.API.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkPathRepository _walkPathRepository;

        public WalksController(IWalkPathRepository walkPathRepository)
        {
            _walkPathRepository = walkPathRepository;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> AddWalk([FromBody] AddWalkPathDto addWalkPathDto)
        {
            var result = await _walkPathRepository.AddWalkAsync(addWalkPathDto);
            return CreatedAtAction(nameof(GetWalk), new { id = result.Id }, result);
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Admin")]
        [Route("/getAll")]
        public async Task<IActionResult> GetWalks(
            [FromQuery] SortAndFilterBy? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] SortAndFilterBy? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000)
        {
            var walks = await _walkPathRepository.GetAllWalkPathsAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(walks);
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Admin")]
        [Route("{id:Guid}")]
        [NotFoundIfNull]
        public async Task<IActionResult> GetWalk([FromRoute] Guid id)
        {
            var walks = await _walkPathRepository.GetWalkPathByIdAsync(id);
            return Ok(walks);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id:Guid}")]
        [ValidateModel]
        [NotFoundIfNull]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkPathDto updateWalkPathDto)
        {
            var result = await _walkPathRepository.UpdateWalkPathAsync(id, updateWalkPathDto);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:Guid}")]
        [NotFoundIfNull]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var result = await _walkPathRepository.DeleteWalkPathAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Admin")]
        [NotFoundIfNull]
        public async Task<IActionResult> GetWalkPaths([FromQuery] Guid? regionId, [FromQuery] Guid? difficultyId)
        {
            var walks = await _walkPathRepository.GetWalkPathsAsync(regionId, difficultyId);
            return Ok(walks);
        }
    }
}
