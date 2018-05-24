using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NilamHutAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public Guid PostId { get; set; }
        
        public Post Post { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(1000)]
        public String ProductDescription { get; set; }

        [Required]
        [Range(1,100000)]
        public String Quantity { get; set; }
        
        [Required]
        [Range(1,10000000)]
        public double BasePrice { get; set; }

        public List<Image> Image { get; set; }

        public List<ProductTag> Tags { get; set; }
    }
}