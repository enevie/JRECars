using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JRECars.Models;
using JRECars.Managers;

namespace JRECars.Controllers
{
	public  class HomeController : Controller
	{
		PathManager _pathManager = new PathManager();

		// GET: Home
		public virtual ActionResult Index()
		{
			var uris = _pathManager.GetAllPictures("Content\\images\\Cars");
			var test = new List<string>();

			foreach (var uri in uris)
			{
				test.Add(uri.Split('\\').Last());
			}


			var model = new IndexPicturesViewModel
			{
				ImagePath = test
			};

			return View(model);
		}
	}
}