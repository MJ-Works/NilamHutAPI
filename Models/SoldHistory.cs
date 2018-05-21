using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class SoldHistory
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        [StringLength(100)]
        public String ProductName { get; set; }

        [Required]
        [Range(1,10000000)]
        public double SoldPrice { get; set; }
    }
}