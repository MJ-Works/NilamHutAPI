using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Country
    {
         public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public String CountryName { get; set; }
    }
}