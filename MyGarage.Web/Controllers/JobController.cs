namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using static Common.NotificationsMessagesConstants;
    using MyGarage.Services.Data.Interfaces;
    using ViewModels.Job;

    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<JobViewModel> viewModel =
                await this._jobService.AllJobsAsync();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJobViewModel addJob)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Something went wrong while trying to add new job!";
                return View(addJob);
            }

            await _jobService.AddJobAsync(addJob);
            TempData[SuccessMessage] = "Successfully added new job!";
            return RedirectToAction("All", "Job");
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddJobViewModel formModel)
        {
            bool job = await _jobService.ExistingByIdAsync(id);

            if (!job)
            {
                this.TempData[ErrorMessage] = "Job with provided id does not exist!";
                return this.RedirectToAction("All", "Job");
            }

            try
            {
                await this._jobService.EditJobByIdAndFormModelAsync(id, formModel);
                this.TempData[SuccessMessage] = "Job edited successfully!";
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occur while trying to update job details, please try again later or contact support!");
                return View(formModel);
            }

            return RedirectToAction("All", "Job", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool jobExist = await _jobService.ExistingByIdAsync(id);

            if (!jobExist)
            {
                this.TempData[ErrorMessage] = "Job with provided id does not exist!";
                return this.RedirectToAction("All", "Job");
            }

            AddJobViewModel formModel = await this._jobService.GetJobForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
            {
                this.TempData[ErrorMessage] = "Unable to take job id!";
                return this.RedirectToAction("All", "Job");
            }

            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, JobViewModel jobToDelete)
        {
            Guid jobId = Guid.Parse(id);
            var isDeleted = await _jobService.SoftDeleteJobAsync(jobId);
            if (!isDeleted)
            {
                this.TempData[ErrorMessage] = "Job with provided id does not exist!";
                return this.RedirectToAction("All", "Job");
            }


            this.TempData[SuccessMessage] = "Job successfully deleted!";
            return RedirectToAction("All", "Job");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool jobExist = await _jobService.ExistingByIdAsync(id);

            if (!jobExist)
            {
                this.TempData[ErrorMessage] = "Job with provided id does not exist!";
                return this.RedirectToAction("All", "Job");
            }

            JobViewModel? viewModel =
                await this._jobService.ViewJobDetailsByIdAsync(id);

            return View(viewModel);
        }
    }
}
