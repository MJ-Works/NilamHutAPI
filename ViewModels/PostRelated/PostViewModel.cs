using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels.PostRelated
{
    public class PostViewModel
    {
        [Required]
        public String ApplicationUserId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        [Required]
        [StringLength(1000)]
        public String ContactInfo { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public Guid CityId { get; set; }
    }
}