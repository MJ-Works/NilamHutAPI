using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using NilamHutAPI.Models;

namespace NilamHutAPI.ViewModels.PostRelated
{
    public class ProductViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(1000)]
        public String ProductDescription { get; set; }

        [Required]
        [Range(1, 100000)]
        public String Quantity { get; set; }

        [Required]
        [Range(1, 10000000)]
        public double BasePrice { get; set; }

        [Required]
        [StringLength(1000)]
        public String ContactInfo { get; set; }

        public Country Country { get; set; }
        [Required]
        public Guid? CountryId { get; set; }

        public City City { get; set; }
        [Required]
        public Guid? CityId { get; set; }

        [Required]
        public List<IFormFile> Image { get; set; }

        [Required]
        public List<Guid> Tags { get; set; }
    }
}