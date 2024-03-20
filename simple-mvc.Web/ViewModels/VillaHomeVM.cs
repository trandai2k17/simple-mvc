using simple_mvc.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace simple_mvc.Web.ViewModels
{
	public class VillaHomeVM
	{
        public IEnumerable<Villa> VillaList { get; set; }
        [DisplayFormat(DataFormatString = "{0:M/d/YYYY}")]
        public DateOnly CheckInDate { get; set; }
        public DateOnly? CheckOutdate { get; set; }
        public int Nights { get; set; } 
    }
}
