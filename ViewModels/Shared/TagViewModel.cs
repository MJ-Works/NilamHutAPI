using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels.Shared
{
    public class TagViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The Tag Name must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
       
        public String TagName { get; set; }
        
        [Required]
        [StringLength(1000, ErrorMessage = "The Tag Description must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
       
        public String TagDescription { get; set; }
    }
}