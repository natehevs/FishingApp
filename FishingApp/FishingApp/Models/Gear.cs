using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishingApp.Models
{
    public class Gear
    {
        [Key]
        [Display(Name = "Gear ID")]
        public int GearID { get; set; }

        [Display(Name = "Marker ID")]
        public int MarkerID { get; set; }

        [Display(Name = "Rod")]
        public string Rod { get; set; }

        [Display(Name = "Reel")]
        public string Reel { get; set; }

        [Display(Name = "Line")]
        public string Line { get; set; }
    }
}