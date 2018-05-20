using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required]
        public Guid userId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime? StartDateTime { get; set; }

        [Required]
        public DateTime? EndDateTime { get; set; }

        [Required]
        [StringLength(1000)]
        public String ContactInfo { get; set; }

        public Product Product { get; set; }
    }
}