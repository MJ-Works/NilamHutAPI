using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class City
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public String CityName { get; set; }

        public List<Product> Products { get; set; }
        public List<User> User { get; set; }
    }
}