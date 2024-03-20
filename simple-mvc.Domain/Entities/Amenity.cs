using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_mvc.Domain.Entities
{
    [Table("VM_Amenity")]
    public class Amenity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Villa))]
        public int VillaId { get; set; }
        public Villa? Villa { get; set; }
        public required string Name { get; set; }
        public string? Description{ get; set; }
    }
}
