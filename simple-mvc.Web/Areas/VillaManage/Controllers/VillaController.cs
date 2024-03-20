using Microsoft.AspNetCore.Mvc;
using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Domain.Entities;

namespace simple_mvc.Web.Areas.VillaManage.Controllers
{
    [Area("VillaManage")]
    public class VillaController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
        public IActionResult Index()
		{
			List<Villa> villas = _unitOfWork.villaRepository.GetAll().ToList();
			return View(villas);
		}
		public IActionResult Create()
		{
			return View();

		}
		[HttpPost]
		public IActionResult Create(Villa obj)
		{
			if (obj.Name == obj.Description)
			{
				ModelState.AddModelError("name", "The description cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				if (obj.Image != null)
				{
					string filename = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
					string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\VillaImage");
					using (var fileStream = new FileStream(Path.Combine(imagePath, filename), FileMode.Create))
					{
						obj.Image.CopyTo(fileStream);
					}

					obj.ImageUrl = @"Images\VillaImage\" + filename;
				}
				else
				{
					obj.ImageUrl = "https://placehold.co/600x400";
				}
				_unitOfWork.villaRepository.Add(obj);
				_unitOfWork.villaRepository.Save();
				TempData["success"] = "The villa has been created successfully.";
				return RedirectToAction(nameof(Index));
			}

			return View(obj);

		}

		public IActionResult Edit(int id)
		{
			if (!ModelState.IsValid)
				return RedirectToAction("Index");
			var villa = _unitOfWork.villaRepository.GetFirstOrDefault(x => x.ID == id);

			if (villa == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(villa);
		}

		public IActionResult Details(int id)
		{
			var villa = _unitOfWork.villaRepository.GetFirstOrDefault(x => x.ID == id);

			if (villa == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(villa);
		}

		[HttpPost]
		public IActionResult Edit(Villa obj)
		{
			if (ModelState.IsValid && obj.ID >= 0)
			{
				if (obj.Image != null)
				{
					string filename = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
					string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\VillaImage");

					if (!string.IsNullOrEmpty(obj.ImageUrl))
					{
						var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(oldImagePath))
							System.IO.File.Delete(oldImagePath);
					}
					using (var fileStream = new FileStream(Path.Combine(imagePath, filename), FileMode.Create))
					{
						obj.Image.CopyTo(fileStream);
					}

					obj.ImageUrl = @"Images\VillaImage\" + filename;
				}
				else
				{
					obj.ImageUrl = "https://placehold.co/600x400";
				}

				_unitOfWork.villaRepository.Update(obj);
				_unitOfWork.villaRepository.Save();
				TempData["success"] = "The villa has been updated successfully.";

				return RedirectToAction(nameof(Index));
			}

			return View();
		}

		public IActionResult Delete(int id)
		{

			var villa = _unitOfWork.villaRepository.GetFirstOrDefault(x => x.ID == id);

			if (villa == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(villa);
		}
		[HttpPost]
		public IActionResult Delete(Villa villa)
		{

			Villa? obFromdb = _unitOfWork.villaRepository.GetFirstOrDefault(x => x.ID == villa.ID);

			if (obFromdb is not null)
			{
				_unitOfWork.villaRepository.Remove(obFromdb);
				_unitOfWork.villaRepository.Save();
				TempData["success"] = "The villa has been deleted successfully.";

				return RedirectToAction(nameof(Index));

			}
			TempData["error"] = "The villa could not be deleted.";
			return View(villa);
		}
	}
}
