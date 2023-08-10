namespace MyGarage.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MyGarage.Services.Data.Interfaces;
    using ViewModels.JobCard;
    using ViewModels.Part;
    using static Common.NotificationsMessagesConstants;

    public class JobCardController : BaseAdminController
    {
        private readonly IVehicleService _vehicleService;
        private readonly IPartService _partService;
        private readonly IJobService _jobService;
        private readonly IMechanicService _mechanicService;
        private readonly IJobCardService _jobCardService;

        public JobCardController(IVehicleService vehicleService, IJobCardService jobCardService, IPartService partService, IJobService jobService, IMechanicService mechanicService)
        {
            _vehicleService = vehicleService;
            _jobService = jobService;
            _jobCardService = jobCardService;
            _partService = partService;
            _mechanicService = mechanicService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable <JobCardViewModel> allJobCards= await _jobCardService.ViewAllJobCardsAsync();

            return View(allJobCards);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {

            try
            {
                var vehicle = await _vehicleService.GetVehicleByIdAsync(id);


                var formModel = new CreateJobCardViewModel()
                {

                    VehicleId = vehicle.Id,
                    Parts = await _partService.AllPartsForFormModelAsync(),
                    Jobs = await _jobService.AllJobsForFormModelAsync(),
                    Mechanics = await _mechanicService.AllMechanicsForFormModelAsync()

                };

                return View(formModel);
            }
            catch (Exception)
            {
                //TempData[ErrorMessage] = "Something Went Wrong!";
                return new NoContentResult();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string id, CreateJobCardViewModel model)
        {

            if (ModelState.IsValid)
            {

                TempData[ErrorMessage] = "There is something wrong with the data you want to input!";
            }
            else
            {
                await _jobCardService.CreateJobCardViewModelAsync(id, model);
                this.TempData[SuccessMessage] = "Job Card was created successfully!";
                return RedirectToAction("All", "Vehicle");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await _jobCardService.GetJobCardForDetailsViewAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] =
                    "No Job Card with provided Id have been found! Please try again later or contact support.";
                return RedirectToAction("All", "JobCard");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(DetailsJobCardViewModel model)
        {
            var viewModel = await _jobCardService.GetJobCardForDetailsViewAsync(model.Id);
            if (viewModel == null)
            {
                TempData[ErrorMessage] = "Job card with provided id do not exist!";
                return RedirectToAction("All", "JobCard");
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, DetailsJobCardViewModel model)
        {
            bool isDeleted = await _jobCardService.DeleteJobCardByIdAsync(id);

            if (isDeleted == false)
            {
                TempData[ErrorMessage] =
                    "Something went wrong while trying to delete Job card, please try again later or contact support.";
                return RedirectToAction("All", "JobCard");
            }

            TempData[SuccessMessage] = "Successfully deleted!";
            return RedirectToAction("All", "JobCard");
        }

        [HttpGet]
        public async Task<IActionResult> AddPart(string id)
        {
            var model = await _jobCardService.GetJobCardToAddPartAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(string id, AddPartToJobCardViewModel model)
        {
            var jobCard = await _jobCardService.GetJobCardToAddPartAsync(id);

            if (jobCard == null)
            {
                TempData[ErrorMessage] = "Job card not found.";
                return RedirectToAction("Index", "Home");
            }

            if (model.SelectedPartId == Guid.Empty)
            {
                TempData[ErrorMessage] = "Please select a part.";
                return RedirectToAction("AddPart", new { id });
            }

            bool isAdded = await _jobCardService.AddPartToJobCardAsync(model.SelectedPartId.ToString(), jobCard);

            if (!isAdded)
            {
                TempData[ErrorMessage] = "Something went wrong while trying to add part to job card.";
                return RedirectToAction("Details", "JobCard", new { id });
            }

            TempData[SuccessMessage] = "Successfully added part to JobCard!";
            return RedirectToAction("Details", "JobCard", new { id });
        }

    }
}
