using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels.Shared
{
    public class CategoryViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The Country Name must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public String CategoryName { get; set; }
    }
}