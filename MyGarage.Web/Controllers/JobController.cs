﻿namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

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
            if (ModelState.IsValid)
            {
                await _jobService.AddJobAsync(addJob);
                return RedirectToAction("All", "Job");
            }

            return View(addJob);
        }
    }
}
