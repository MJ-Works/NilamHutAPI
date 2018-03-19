using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class PersonalInfo
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public String FullName { get; set; }


        public Country Country { get; set; }
        [Required]
        public Guid CountryId { get; set; }

        public City City { get; set; }
        [Required]
        public Guid CityId { get; set; }

        [Required]
        [StringLength(20)]
        public String PostCode { get; set; }

        [Required]
        [StringLength(500)]
        public String Address { get; set; }

        [Required]
        [StringLength(50)]
        [Phone]
        public String Phone { get; set; }
    }
}