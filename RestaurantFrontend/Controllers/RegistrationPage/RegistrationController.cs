using Microsoft.AspNetCore.Mvc;

namespace RestaurantFrontend.Controllers.RegistrationPage
{
    public class RegistrationController : Controller
    {
        [Route("regis")]
        public ActionResult Index()
        {
            return View(new RegistrationController());
        }

        [Route("Reg")]

        [HttpPost]
        public ActionResult Index(RegistrationController model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("RegistrationSuccess");
            }
            return View(model);
        }

        public ActionResult RegistrationSuccess()
        {
            return View();
        }
    }

}

