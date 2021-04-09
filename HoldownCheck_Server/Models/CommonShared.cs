using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    internal class WoodPost
    {
        internal string Name { get; set; }
        internal double Thickness { get; set; }
        internal double Width { get; set; }

        public override string ToString()
        {
            return Name;
        }

        internal static WoodPost[] getWoodPost()
        {
            return new WoodPost[]
            {
                new WoodPost() { Name = "4X4", Thickness = 3.5, Width = 3.5},
                new WoodPost() { Name = "4X6", Thickness = 5.5, Width = 3.5},
                new WoodPost() { Name = "4X8", Thickness = 7.25, Width = 3.5},
                new WoodPost() { Name = "6x4", Thickness = 3.5, Width = 5.5},
                new WoodPost() { Name = "6X6", Thickness = 5.5, Width = 5.5},
                new WoodPost() { Name = "6X8", Thickness = 7.25, Width = 5.5},
            };
        }
    }

    internal class ComboHardware
    {
        public HoldownSCH Holdown { get; set; }
        public AnchorSCH AnchorBolt { get; set; }
        public WoodPost post { get; set; }
        public int Stemwall { get; set; }

        public override string ToString()
        {
            string err = "\\!*** Error! ***";
            if (Holdown == null && AnchorBolt == null)
                return err;

            if (Holdown.GetType() == typeof(Strap_Holdown))
            {
                var st = Holdown as Strap_Holdown;
                return string.Format("{0}/{1} {2}", Holdown, post,
                        Stemwall >= 12 ? string.Format("on Footing @ {0}", st.Location) : string.Format("on {0}\" stemwall @ {1}", Stemwall, st.Location));
            }
            else if (Holdown.GetType() == typeof(Holdown))
            {
                if (AnchorBolt == null)
                    return err;

                if (AnchorBolt.GetType() == typeof(SSTB))
                {
                    var sstb = AnchorBolt as SSTB;
                    return string.Format("{0}/{1} w/{2} on {3}", Holdown, post, AnchorBolt,
                           Stemwall >= 12 ? "Footing" : string.Format("{0}\" stemwall @ {1}", Stemwall, sstb.Location));
                }
                else
                    return string.Format("{0}/{1}\nPad is required per detail", Holdown, post);
            }
            else
                return err;
        }

        public int MaxTension
        {
            get
            {
                if (Holdown == null && AnchorBolt == null)
                    return 0;

                return AnchorBolt != null
                        ? Math.Min(Holdown.Tension, AnchorBolt.Tension)
                        : Holdown.Tension;
            }
        }

        public double Defl
        {
            get
            {
                return Holdown != null ? Holdown.Defl * MaxTension / Holdown.Tension : -1;
            }
        }

        public string DetailReport
        {
            get
            {
                var str = new StringBuilder();
                str.AppendLine("SDC C-F, Concrete state: Cracked");
                str.AppendLine(this.ToString());

                if (Holdown != null && AnchorBolt != null)
                {                    
                    str.AppendLine(string.Format("Holdown capacity: {0} lb {1}", Holdown.Tension, is_FIRST_Tension_Govern(Holdown, AnchorBolt) ? "\\B(Govern)" : ""));
                    if (AnchorBolt != null)
                        str.AppendLine(string.Format("Anchor Bolt capacity: {0} lb {1}", AnchorBolt.Tension, is_FIRST_Tension_Govern(AnchorBolt, Holdown) ? "\\B\\!(Govern) *** " : ""));
                    str.AppendLine();
                    str.AppendLine(string.Format("\\BMax. Capacity = {0} lb, MaxDefl. = {1:f3} in.", MaxTension, Defl));
                }

                return str.ToString();
            }
        }

        private bool is_FIRST_Tension_Govern(object o1, object o2)
        {
            dynamic p1 = o1;
            dynamic p2 = o2;
            return (p2 == null || p1.Tension < p2.Tension);
        }
    }

}
