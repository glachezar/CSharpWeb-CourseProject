namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class JobCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
