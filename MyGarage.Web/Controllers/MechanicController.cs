using MyGarage.Services.Data.Interfaces;
using MyGarage.Web.ViewModels.Mechanic;

namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyGarage.Web.ViewModels.Customer;

    [Authorize]
    public class MechanicController : Controller
    {
        private readonly IMechanicService _mechanicService;

        public MechanicController(IMechanicService service)
        {
            _mechanicService = service;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<MechanicViewModel> viewModel =
                await this._mechanicService.AllMechanicsAsync();

            return View(viewModel);
        }
    }
}
