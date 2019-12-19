using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FishingApp.Models
{
    public class RatingModel
    {
        [Key]
        [Display(Name = "Rating ID")]
        public int RatingID { get; set; }

        [ForeignKey("LocationMarkers")]
        public int MarkerID { get; set; }
        public LocationMarkers LocationMarkers { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [ForeignKey("Enthusiast")]
        public int EnthusiastID { get; set; }
        public Enthusiast Enthusiast { get; set; }
    }
}