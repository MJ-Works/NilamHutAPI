using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.ViewModels.FrontEnd
{
    public class ReportViewModel
    {
        [Required]
        public String ApplicationUserId { get; set; }

        [Required]
        public string ReportDescription { get; set; }

    }
    
}