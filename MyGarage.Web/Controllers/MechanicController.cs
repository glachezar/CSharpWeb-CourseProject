namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MyGarage.Services.Data.Interfaces;
    using static Common.NotificationsMessagesConstants;
    using ViewModels.Mechanic;



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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MechanicViewModel addMechanic)
        {
            if (ModelState.IsValid)
            {
                await _mechanicService.AddMechanicAsync(addMechanic);
                this.TempData[SuccessMessage] = "Successfully added new mechanic!";
                return RedirectToAction("All", "Mechanic");
            }

            return View(addMechanic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, MechanicViewModel formModel)
        {
            bool mechanicExist = await _mechanicService.ExistingByIdAsync(id);

            if (!mechanicExist)
            {
                this.TempData[ErrorMessage] = "Mechanic with provided id does not exist!";
                return this.RedirectToAction("All", "Mechanic");
            }

            try
            {
                await this._mechanicService.EditMechanicByIdAndFormModelAsync(id, formModel);
                this.TempData[SuccessMessage] = "Mechanic edited successfully!";
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
            bool mechanicExist = await _mechanicService.ExistingByIdAsync(id);

            if (!mechanicExist)
            {
                this.TempData[ErrorMessage] = "Mechanic with provided id does not exist!";
                return this.RedirectToAction("All", "Mechanic");
            }

            MechanicViewModel formModel = await this._mechanicService.GetMechanicForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var mechanic = await _mechanicService.GetMechanicByIdAsync(id);
            if (mechanic == null)
            {
                this.TempData[ErrorMessage] = "Mechanic with provided id does not exist!";
                return this.RedirectToAction("All", "Mechanic");
            }

            return View(mechanic);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, MechanicViewModel mechanicToDelete)
        {
            Guid mechanicId = Guid.Parse(id);
            var isDeleted = await _mechanicService.SoftDeleteMechanicAsync(mechanicId);
            if (!isDeleted)
            {
                this.TempData[ErrorMessage] = "Mechanic with provided id does not exist!";
                return this.RedirectToAction("All", "Mechanic");
            }


            this.TempData[SuccessMessage] = "Mechanic successfully deleted!";
            return RedirectToAction("All", "Mechanic");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool mechanicExist = await _mechanicService.ExistingByIdAsync(id);

            if (!mechanicExist)
            {
                this.TempData[ErrorMessage] = "Mechanic with provided id does not exist!";
                return this.RedirectToAction("All", "Mechanic");
            }

            MechanicViewModel? viewModel =
                await this._mechanicService.ViewMechanicDetailsByIdAsync(id);

            return View(viewModel);
        }
       
    }
}
