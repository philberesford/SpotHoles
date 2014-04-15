using System.Web.Mvc;

namespace PotHoles.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return RedirectToAction("Index", "PotHoles");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}