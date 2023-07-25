using MyGarage.Services.Data.Interfaces;
using MyGarage.Web.ViewModels.Part;

namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyGarage.Services.Data;
    using MyGarage.Web.ViewModels.Customer;

    [Authorize]
    public class PartController : Controller
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllPartsViewModel> viewModel =
                await this._partService.AllPartsAsync();

            return View(viewModel);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AllPartsViewModel addPart)
        {
            if (ModelState.IsValid)
            {
                await _partService.AddPartAsync(addPart);
                return RedirectToAction("All", "Part");
            }

            return View(addPart);
        }
    }
}
