using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JRECars.Models;
using JRECars.Managers;
using Data.Context;
using System.IO;

namespace CarShop.Controllers
{
	public  class StoreManagerController : Controller
	{
		private JREMotorsDB db = new JREMotorsDB();
		private PathManager pathManager = new PathManager();

		// GET: StoreManager
		public virtual ActionResult Index()
		{
			var cars = db.Cars.ToList();

			var viewModel = cars.Select(x => new CarViewModel
			{
				CarId = x.CarId,
				Model = x.Model,
				ManufacturerName = db.Manufacturers.Where(y => y.ManufacturerId == x.ManufacturerId)
												   .Select(z => z.Name)
												   .FirstOrDefault(),
				Price = x.Price,
				YearOfManufacture = x.YearOfManufacture,
				Kilometers = x.Kilometers,
				HorsePower = x.HorsePower,
			});

			return View(viewModel);
		}

		public FileContentResult GetImage(int carId)
		{
			byte[] image = db.Images.Where(x => x.Car.CarId == carId)
				             .Select(z => z.Image)
			                 .FirstOrDefault();

			return new FileContentResult(image, "image/jpeg");
		}

		public IEnumerable<FileContentResult> GetImages(int carId)
		{
			var imagesForTheCar = db.Images.Where(x => x.Car.CarId == carId)
										   .Select(y => y.Image);

			var test = new List<FileContentResult>();

			foreach (var image in imagesForTheCar)
			{
				//byte[] newArr = new byte[image];
				var newFile = new FileContentResult(image, "image/jpeg");
				test.Add(newFile);
			}

			return test;
		}

		// GET: StoreManager/Details/5
		public virtual ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Car car = db.Cars.Find(id);
			if (car == null)
			{
				return HttpNotFound();
			}
			return View(car);
		}

		// GET: StoreManager/Create
		public virtual ActionResult Create()
		{
			var manufacturers = db.Manufacturers.ToList();

			var model = new CreateCarViewModel
			{
				Manufacturer = manufacturers,
				Car = new Car()
			};


			return View(model);
		}

		public virtual ActionResult AddManufacturer()
		{

			var model = new Manufacturer();
			{

			};

			return View(model);
		}


		// POST: StoreManager/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(Car car, HttpPostedFileBase file)
		{

			if (ModelState.IsValid)
			{
				
				var addCar = new Car
				{
					YearOfManufacture = car.YearOfManufacture,
					HorsePower = car.HorsePower,
					Model = car.Model,
					ManufacturerId = car.ManufacturerId,
					Kilometers = car.Kilometers,
					Price =  car.Price
				};

				var addImage = new Images
				{
					Image = pathManager.ImageToByteArray(file),
					Car = addCar
				};

				db.Images.Add(addImage);
				db.Cars.Add(addCar);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult AddManufacturer(Manufacturer manufacturer)
		{
			if (ModelState.IsValid && manufacturer.Name != null)
			{
				db.Manufacturers.Add(manufacturer);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		// GET: StoreManager/Edit/5
		public virtual ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Car car = db.Cars.Find(id);
			if (car == null)
			{
				return HttpNotFound();
			}
			return View(car);
		}

		// POST: StoreManager/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit([Bind(Include = "CarId,Model,Price")] Car car, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{

				var addCar = new Car
				{
					CarId = car.CarId,
					YearOfManufacture = car.YearOfManufacture,
					HorsePower = car.HorsePower,
					Model = car.Model,
					ManufacturerId = car.ManufacturerId,
					Kilometers = car.Kilometers,
					Price = car.Price
				};

				var addImage = new Images
				{
					Car = addCar,
					Image = pathManager.ImageToByteArray(file)
				};

				db.Entry(addImage).State = EntityState.Added;
				db.Entry(addCar).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(car);
		}

		// GET: StoreManager/Delete/5
		public virtual ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Car car = db.Cars.Find(id);
			if (car == null)
			{
				return HttpNotFound();
			}
			return View(car);
		}

		// POST: StoreManager/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public virtual ActionResult DeleteConfirmed(int id)
		{
			Car car = db.Cars.Find(id);
			db.Cars.Remove(car);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
