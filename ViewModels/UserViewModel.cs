using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name="Full Name")]
        public String FullName { get; set; }

        [Required]
        [Display(Name="Country")]
        public Guid CountryId { get; set; }

        [Required]
        [Display(Name="City")]
        public Guid CityId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name="Post Code")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "Enter Only Numbers")]
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