using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NilamHutAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }

        [StringLength(50)]
        public String FullName { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }

        public City City { get; set; }
        public Guid CityId { get; set; }

        [StringLength(20)]
        public String PostCode { get; set; }

        [StringLength(500)]
        public String Address { get; set; }

        [StringLength(50)]
        [Phone]
        public String Phone { get; set; }
        
        public bool IsVip { get; set; }

        public Rating Rating { get; set; }
        public Credit Credit { get; set; }
    }
}