using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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

        [ForeignKey("Gear")]
        public int GearID { get; set; }
        public Gear Gear { get; set; }

        [Display(Name = "Lake Name")]
        public string LakeName { get; set; }

        [ForeignKey("TechniqueModel")]
        public int TechniqueID { get; set; }
        public TechniqueModel TechniqueModel { get; set; }

        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Display(Name = "Average Rating")]
        public double AverageRating { get; set; }
    }
}