namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MyGarage.Services.Data.Interfaces;
    using ViewModels.Part;
    using static Common.NotificationsMessagesConstants;

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
            IEnumerable<PartsViewModel> viewModel =
                await this._partService.AllPartsAsync();

            return View(viewModel);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PartsViewModel addPart)
        {
            if (ModelState.IsValid)
            {
                await _partService.AddPartAsync(addPart);
                this.TempData[SuccessMessage] = "Successfully added new part!";
                return RedirectToAction("All", "Part");
            }

            return View(addPart);
        }

        public async Task<IActionResult> Edit(string id, PartsViewModel formModel)
        {
            bool vehicleExist = await _partService.ExistingByIdAsync(id);

            if (!vehicleExist)
            {
                this.TempData[ErrorMessage] = "Part with provided id does not exist!";
                return this.RedirectToAction("All", "Part");
            }

            try
            {
                await this._partService.EditPartByIdAndFormModelAsync(id, formModel);
                this.TempData[SuccessMessage] = "Part edited successfully!";
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occur while trying to update part details, please try again later or contact support!");
                return View(formModel);
            }

            return RedirectToAction("All", "Part", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool partExist = await _partService.ExistingByIdAsync(id);

            if (!partExist)
            {
                this.TempData[ErrorMessage] = "Part with provided id does not exist!";
                return this.RedirectToAction("All", "Part");
            }

            PartsViewModel formModel = await this._partService.GetPartForEditByIdAsync(id);

            return this.View(formModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var part = await _partService.GetPartByIdAsync(id);
            if (part == null)
            {
                this.TempData[ErrorMessage] = "Part with provided id does not exist!";
                return this.RedirectToAction("All", "Part");
            }

            return View(part);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, PartsViewModel partToDelete)
        {
            Guid partId = Guid.Parse(id);   
            var isDeleted = await _partService.SoftDeletePartAsync(partId);
            if (!isDeleted)
            {
                this.TempData[ErrorMessage] = "Part with provided id does not exist!";
                return this.RedirectToAction("All", "Part");
            }


            this.TempData[SuccessMessage] = "Part successfully deleted!";
            return RedirectToAction("All", "Part");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool partExist = await _partService.ExistingByIdAsync(id);

            if (!partExist)
            {
                this.TempData[ErrorMessage] = "Part with provided id does not exist!";
                return this.RedirectToAction("All", "Part");
            }

            PartsViewModel? viewModel =
                await this._partService.ViewPartDetailsByIdAsync(id);

            return View(viewModel);
        }
    }
}
