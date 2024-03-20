using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Domain.Entities;
using simple_mvc.Web.ViewModels;

namespace simple_mvc.Web.Areas.VillaManage.Controllers
{
    [Area("VillaManage")]
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int villaID)
        {
            List<Amenity> amenities = _unitOfWork.amenityRepository
                .GetAll(includeProperties: "Villa").OrderBy(m => m.Name).ToList();
            return View(amenities);
        }

        public IActionResult Create()
        {
            AmenityVM vm = new()
            {
                VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }),
                
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(AmenityVM model)
        {
            //Remove validation
            if (ModelState.IsValid)
            {
                _unitOfWork.amenityRepository.Add(model.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity successfully";
                return RedirectToAction(nameof(Index));
            }

            model.VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });
            return View(model);
        }
        public IActionResult Update(int id)
        {
            AmenityVM AmenityVM = new AmenityVM()
            {
                VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.ID.ToString()
                }),
                Amenity = _unitOfWork.amenityRepository.GetFirstOrDefault(m => m.Id == id)
            };

            if (AmenityVM == null)
            {
                return RedirectToAction("error", "home");
            }
            return View(AmenityVM);
        }
        [HttpPost]
        public IActionResult Update(AmenityVM model)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.amenityRepository.Update(model.Amenity);
                _unitOfWork.Save();

                TempData["success"] = "Amenity successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //public IActionResult Delete(int id) {
        //    AmenityVM AmenityVM = new()
        //    {
        //        VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(m => new SelectListItem()
        //        {
        //            Text = m.Name,
        //            Value = m.ID.ToString()
        //        }),
        //        VillaNumber = _unitOfWork.amenityRepository.GetFirstOrDefault(m => m.Villa_Number == id)
        //    };
        //    if (AmenityVM == null)
        //    {
        //        return RedirectToAction("error", "Home");
        //    }
        //    return View(AmenityVM);
        //}

        public ActionResult Delete(int id)
        {
            Amenity? objFromDb = _unitOfWork.amenityRepository.GetFirstOrDefault(x => x.Id == id);
            if(objFromDb != null)
            {
                _unitOfWork.amenityRepository.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Villa Number deleted successfully";
                
            }else
                TempData["error"] = "Delete fail";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(AmenityVM model)
        {
            Amenity? objFromDb = _unitOfWork.amenityRepository
                .GetFirstOrDefault(x => x.Id == model.Amenity.Id);
            if (objFromDb != null)
            {
                _unitOfWork.amenityRepository.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Amenity Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
