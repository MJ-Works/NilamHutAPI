using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Rating
    {
        public Guid Id { get; set; }

        [Required]
        [Range(1,5)]
        public int UserRating { get; set; }

        [StringLength(500)]
        public String UserComment { get; set; }

        [Required]
        public String GivenUserId { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}