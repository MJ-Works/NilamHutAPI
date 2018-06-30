using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Report
    {
        public Guid Id { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string ReportDescription { get; set; }
    }
}