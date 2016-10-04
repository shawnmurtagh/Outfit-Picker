using System.Collections.Generic;

namespace Outfit_Picker.Models
{
    public class Outfit
    {
        public Outfit()
        {
            this.Accessories = new HashSet<Accessory>();
        }

        public int OutfitID { get; set; }
        public string OutfitName { get; set; }

        public int TopID { get; set; }
        public int BottomID { get; set; }
        public int ShoeID { get; set; }

        public virtual Top Top { get; set; }
        public virtual Bottom Bottom { get; set; }
        public virtual Shoe Shoe { get; set; }

        public virtual ICollection <Accessory> Accessories { get; set; }


    }
}