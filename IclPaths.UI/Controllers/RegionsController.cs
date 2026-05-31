using Microsoft.AspNetCore.Mvc;
using IclPaths.UI.Services;
namespace IclPaths.UI.Controllers
{
    using IclPaths.UI.Models;

    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var regions = await _regionRepository.GetAllAsync();
            return View(regions);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region is null) return NotFound();
            return View((object)region);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegionViewModel region)
        {
            var addedRegion = await _regionRepository.AddRegion(region);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var region = await _regionRepository.GetByIdAsync(id);
            if (region is null) return NotFound();
            return View((object)region);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionViewModel region)
        {
            await _regionRepository.UpdateRegion(region);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region is null) return NotFound();
            return View((object)region);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessDelete(Guid id)
        {
            var response = await _regionRepository.DeleteRegion(id);
            if (response is null) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
