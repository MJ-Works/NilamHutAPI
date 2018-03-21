using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The Country Name must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public String CountryName { get; set; }
    }
}