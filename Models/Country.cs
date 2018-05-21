using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Country
    {
         public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public String CountryName { get; set; }

        public List<Post> Post { get; set; }
    }
}