using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishingApp.Models
{
    public class TechniqueModel
    {
        [Key]
        [Display(Name = "Technique ID")]
        public int TechniqueID { get; set; }
        
        [Display(Name = "Technique")]
        public string Technique { get; set; }
    }
}