using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels
{
    public class RatingViewModel
    {
        [Required]
        [Range(1,5)]
        public int UserRating { get; set; }

        [StringLength(500)]
        public String UserComment { get; set; }

        [Required]
        public String GivenUserId { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }
    }
}