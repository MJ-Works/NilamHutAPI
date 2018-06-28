using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class SoldHistory
    {
        public Guid Id { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(100)]
        public String ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public String ProductName { get; set; }

        [Required]
        [StringLength(1000)]
        public String ProductDescription { get; set; }

        [Required]
        [Range(1,10000000)]
        public double SoldPrice { get; set; }

        [Required]
        public DateTime? DateTime { get; set; }

        [Required]
        public String BuyerID { get; set; }
    }
}