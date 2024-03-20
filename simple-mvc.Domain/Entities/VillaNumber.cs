using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_mvc.Domain.Entities
{
    [Table("VM_VillaNumber")]
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Villa_Number { get; set; }
        [ForeignKey(nameof(Villa))]
        public int VillaID { get; set; }
        public Villa Villa { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
