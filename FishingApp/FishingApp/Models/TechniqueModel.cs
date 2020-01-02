using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishingApp.Models
{
    public class TechniqueModel
    {
        [Key]
        [Display(Name = "Technique")]
        public int TechniqueID { get; set; }
        
        [Display(Name = "Technique")]
        public string Technique { get; set; }
    }
}