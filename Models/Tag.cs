using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public String TagName { get; set; }
        
        [Required]
        [StringLength(1000)]
        public String TagDescription { get; set; }

        public List<ProductTag> Products { get; set; }
    }
}