using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels.Shared
{
    public class SearchViewModel
    {
        public Guid? Category { get; set; }
        public Guid? City { get; set; }

        [StringLength(50, ErrorMessage = "The User SearchName must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
        public String searchName { get; set; }
    }
}