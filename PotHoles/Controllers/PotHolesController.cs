using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PotHoles.Models;

namespace PotHoles.Controllers
{
    public class PotHolesController : Controller
    {

	    private const string API_URL = "http://spotholes.herokuapp.com/api/pothole";
        //
        // GET: /PotHoles/
        public ActionResult Index()
        {
            return View(new PotHoleViewModel());
        }

        //
        // GET: /PotHoles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // POST: /PotHoles/Create
        [HttpPost]
        public ActionResult Create(PotHoleViewModel pvm)
        {
			var serializer = new JavaScriptSerializer();
	        var s = serializer.Serialize(pvm);

			POST(API_URL, s);

			return Json("OK");
        }

		//
		// POST: /PotHoles/GetByLongLat
		[HttpGet]
		public ActionResult GetByLongLat(double longitude, double latitude)
		{
			
			var result = GET(API_URL + "?latitude=" + latitude + "&longitude=" + longitude + "&meters=10000");
			var serializer = new JavaScriptSerializer();
			var s = serializer.Deserialize<List<PotHoleViewModel>>(result);
			return Json(s, JsonRequestBehavior.AllowGet);
		}

	    private string GET(string url)
	    {
			using (WebClient wc = new WebClient())
			{
				wc.Headers[HttpRequestHeader.ContentType] = "application/json";
				return wc.DownloadString(url);
			}
	    }

	   
		private string POST(string url, string jsonContent)
		{
			using (var wc = new WebClient())
			{
				wc.Headers[HttpRequestHeader.ContentType] = "application/json";
				return wc.UploadString(url, jsonContent);
			}
		}
    }
}
