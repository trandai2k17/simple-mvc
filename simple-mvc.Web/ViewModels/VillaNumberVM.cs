using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using simple_mvc.Domain.Entities;

namespace simple_mvc.Web.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumber?  VillaNumber{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; }
    }
}
