using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using NilamHutAPI.Models;

namespace NilamHutAPI.ViewModels.PostRelated
{
    public class ProductViewModel
    {
        [Required]
        public Guid PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        [StringLength(50)]
        public int ProductName { get; set; }

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
        public List<IFormFile> Image { get; set; }

        [Required]
        public List<Guid> Tags { get; set; }
    }
}