using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishingApp.Models
{
    public class LocationMarkers
    {
        [Key]
        [Display(Name = "Marker ID")]
        public int MarkerID { get; set; }

        [ForeignKey("Enthusiast")]
        public int EnthusiastID { get; set; }
        public Enthusiast Enthusiast { get; set; }

        [Display(Name = "Species")]
        public string Species { get; set; }

        [Display(Name = "Date/Time Caught")]
        public DateTime DateTimeCaught { get; set; }

        [Display(Name = "Bait Used")]
        public string BaitUsed { get; set; }

        [Display(Name = "Rod Used")]
        public string RodUsed { get; set; }

        [Display(Name = "Reel Used")]
        public string ReelUsed { get; set; }

        [Display(Name = "Line Used")]
        public string LineUsed { get; set; }

        [Display(Name = "Lake Name")]
        public string LakeName { get; set; }

        [ForeignKey("TechniqueModel")]
        public int TechniqueID { get; set; }
        public TechniqueModel TechniqueModel { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; }

        [NotMapped]
        public SelectList Techniques { get; set; }
    }
}