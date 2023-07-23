using MyGarage.Services.Data.Interfaces;
using MyGarage.Web.ViewModels.Part;

namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
    }
}
