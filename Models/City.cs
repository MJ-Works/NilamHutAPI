using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class City
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public String CityName { get; set; }
    }
}