using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public String ImgPath { get; set; }

        [Required]
        [StringLength(1000)]
        public String ImgDescription { get; set; }
    }
}