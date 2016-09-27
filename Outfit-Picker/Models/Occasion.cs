using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outfit_Picker.Models
{
    public class Occasion
    {
        public int OccasionID { get; set; }
        public string OccasionName { get; set; }

        public virtual IEnumerable<Top> Top { get; set; }
        public virtual IEnumerable<Bottom> Bottom { get; set; }
        public virtual IEnumerable<Shoe> Shoe { get; set; }
        public virtual IEnumerable<Accessory> Accessory { get; set; }
    }
}