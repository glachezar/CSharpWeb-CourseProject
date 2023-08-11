namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MyGarage.Services.Data.Interfaces;
    using static Common.NotificationsMessagesConstants;

    public class JobCardController : Controller
    {

        private readonly IJobCardService _jobCardService;

        public JobCardController( IJobCardService jobCardService)
        {

            _jobCardService = jobCardService;

        }


        public async Task<IActionResult> Details(string id)
        {
            var model = await _jobCardService.GetJobCardForDetailsViewAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] =
                    "Something went wrong while trying to get your job card details! Please try again later or contact administrator.";
                return RedirectToAction("All", "Vehicle");
            }

            return View(model);
        }

    }
}
