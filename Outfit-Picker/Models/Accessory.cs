using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Outfit_Picker.Models
{
    public class Accessory
    {
        public int AccessoryID { get; set; }

        [Required, StringLength(40)]
        public string AccessoryName { get; set; }

        public string PhotoPath { get; set; }

        [Required, StringLength(40)]
        public string Type { get; set; }

        [Required]
        public int ColorID { get; set; }

        [Required]
        public int SeasonID { get; set; }

        [Required]
        public int OccasionID { get; set; }

        //Navigation Properties 
        public virtual Color Color { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }
        public object AccessoryId { get; internal set; }
    }
}