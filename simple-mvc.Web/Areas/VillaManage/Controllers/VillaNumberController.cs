using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Domain.Entities;
using simple_mvc.Web.ViewModels;

namespace simple_mvc.Web.Areas.VillaManage.Controllers
{
    [Area("VillaManage")]
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int villaID)
        {
            List<VillaNumber> villaNumberList = _unitOfWork.villaNumberRepository
                .GetAll(includeProperties: "Villa").OrderBy(m => m.VillaID).ToList();
            return View(villaNumberList);
        }

        public IActionResult Create()
        {
            VillaNumberVM vm = new()
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
        public IActionResult Create(VillaNumberVM villaNumberVM)
        {
            //Remove validation
            ModelState.Remove("VillaNumber.Villa");
            bool isNumberUnique = _unitOfWork.villaNumberRepository
                .GetAll(u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number).Count() == 0;
            if (ModelState.IsValid && isNumberUnique)
            {
                _unitOfWork.villaNumberRepository.Add(villaNumberVM.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "Villa number successfully";
                return RedirectToAction(nameof(Index));
            }

            if (!isNumberUnique)
            {
                TempData["error"] = "Villa number already exists. Please use a different villa number";
            }
            villaNumberVM.VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });
            return View(villaNumberVM);
        }
        public IActionResult Update(int id)
        {
            VillaNumberVM villaNumberVM = new VillaNumberVM()
            {
                VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.ID.ToString()
                }),
                VillaNumber = _unitOfWork.villaNumberRepository.GetFirstOrDefault(m => m.Villa_Number == id)
            };

            if (villaNumberVM == null)
            {
                return RedirectToAction("error", "home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {
            ModelState.Remove("VillaNumber.Villa");
            if(ModelState.IsValid)
            {
                _unitOfWork.villaNumberRepository.Update(villaNumberVM.VillaNumber);
                _unitOfWork.Save();

                TempData["success"] = "Villa number successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(villaNumberVM);
        }

        //public IActionResult Delete(int id) {
        //    VillaNumberVM villaNumberVM = new()
        //    {
        //        VillaList = _unitOfWork.villaRepository.GetAll().ToList().Select(m => new SelectListItem()
        //        {
        //            Text = m.Name,
        //            Value = m.ID.ToString()
        //        }),
        //        VillaNumber = _unitOfWork.villaNumberRepository.GetFirstOrDefault(m => m.Villa_Number == id)
        //    };
        //    if (villaNumberVM == null)
        //    {
        //        return RedirectToAction("error", "Home");
        //    }
        //    return View(villaNumberVM);
        //}

        public ActionResult Delete(int id)
        {
            VillaNumber? objFromDb = _unitOfWork.villaNumberRepository.GetFirstOrDefault(x => x.Villa_Number == id);
            if(objFromDb != null)
            {
                _unitOfWork.villaNumberRepository.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Villa Number deleted successfully";
                
            }else
                TempData["error"] = "Delete fail";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? objFromDb = _unitOfWork.villaNumberRepository
                .GetFirstOrDefault(x => x.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);
            if (objFromDb != null)
            {
                _unitOfWork.villaNumberRepository.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Villa Number Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(villaNumberVM);
        }
    }
}
