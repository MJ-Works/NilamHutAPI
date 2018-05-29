using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string ApplicationUserId { get; set; }
        
        [StringLength(50)]
        [Display(Name="Full Name")]
        public String FullName { get; set; }

        [Display(Name="City")]
        public Guid CityId { get; set; }

        [StringLength(20)]
        [Display(Name="Post Code")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "Enter Only Numbers")]
        public String PostCode { get; set; }

        [StringLength(500)]
        public String Address { get; set; }

        [StringLength(50)]
        [Phone]
        public String Phone { get; set; }
    }
}