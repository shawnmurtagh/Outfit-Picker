using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outfit_Picker.Models
{
    public class Accessory
    {
        public int AccessoryID { get; set; }

        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public string Type { get; set; }

        public Color _Color { get; set; }

        public string Season { get; set; }

        public string Occasion { get; set; }

        public virtual IEnumerable<Outfit> Outfit { get; set; }
    }
}