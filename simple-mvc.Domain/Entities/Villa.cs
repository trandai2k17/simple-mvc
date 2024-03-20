﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_mvc.Domain.Entities
{
    [Table("VM_Villa")]
    public class Villa
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price per night")]
        public double Price { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }         
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedUser { get; set; }
        [ValidateNever]
        public IEnumerable<Amenity> VillaAmenities { get; set; }
        [ValidateNever]
        [NotMapped]
        public bool IsAvailable { get; set; } = true;
    }
}
