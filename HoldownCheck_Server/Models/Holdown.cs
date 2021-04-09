using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public enum eWood { ANY, DF, SP, SPF, HF }
    public enum eLocation { Midwall, Corner/*, Endwall*/ }

    public abstract class HoldownSCH
    {
        public abstract bool IsNeedAB { get; }
        public string Name { get; set; }
        public double MinWoodThk { get; set; }
        public bool Is6X6 { get; set; }
        public string Nails { get; set; }
        public eWood Wood { get; set; }

        public int Tension { get; set; }
        public double Defl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Holdown : HoldownSCH
    {
        public double AB_dia { get; set; }

        public override bool IsNeedAB { get { return true; } }
    }

    public class Strap_Holdown : HoldownSCH
    {
        public int MinStemwall { get; set; }
        public eLocation Location { get; set; }
        public override bool IsNeedAB { get { return false; } }
    }


    public class HoldownData
    {
        private HoldownSCH[] mSimpSonHD;
        public HoldownSCH[] SimpSonHD { get { return mSimpSonHD; } }
        public HoldownData()
        {
            mSimpSonHD = new HoldownSCH[]
            {
                //new Strap_Holdown(){Name = "STHD10", MinWoodThk = 3.5, Wood = eWood.ANY, Nails = "(20) 16d sinkers", MinStemwall = 8, Location = eLocation.Midwall, Tension = 3400, Defl = 0.146},
                //new Strap_Holdown(){Name = "STHD10", MinWoodThk = 3.5, Wood = eWood.ANY, Nails = "(20) 16d sinkers", MinStemwall = 8, Location = eLocation.Corner, Tension = 2940, Defl = 0.146},

                //new Strap_Holdown(){Name = "STHD14", MinWoodThk = 3.5, Wood = eWood.ANY, Nails = "(20) 16d sinkers", MinStemwall = 8, Location = eLocation.Midwall, Tension = 3815, Defl = 0.164},
                //new Strap_Holdown(){Name = "STHD14", MinWoodThk = 3.5, Wood = eWood.ANY, Nails = "(20) 16d sinkers", MinStemwall = 8, Location = eLocation.Corner, Tension = 3815, Defl = 0.164},

                new Holdown(){Name = "HTT5", MinWoodThk = 3.5, Wood = eWood.DF, Nails = "(26) 16d sinkers", AB_dia = 5/8d, Tension = 4670, Defl = 0.116},

                new Holdown(){Name = "HDU2", MinWoodThk = 3.0, Wood = eWood.DF, Nails = "(6) 1/4\" X 2 1/2\" SDS", AB_dia = 5/8d, Tension = 3075, Defl = 0.088},

                new Holdown(){Name = "HDU4", MinWoodThk = 3.0, Wood = eWood.DF, Nails = "(10) 1/4\" X 2 1/2\" SDS", AB_dia = 5/8d, Tension = 4565, Defl = 0.114},

                new Holdown(){Name = "HDU5", MinWoodThk = 3.0, Wood = eWood.DF, Nails = "(10) 1/4\" X 2 1/2\" SDS", AB_dia = 5/8d, Tension = 5645, Defl = 0.115},

                new Holdown(){Name = "HDU8", MinWoodThk = 3.0, Wood = eWood.DF, Nails = "(20) 1/4\" X 2 1/2\" SDS", AB_dia = 7/8d, Tension = 6765, Defl = 0.110},
                new Holdown(){Name = "HDU8", MinWoodThk = 3.5, Wood = eWood.DF, Nails = "(20) 1/4\" X 2 1/2\" SDS", AB_dia = 7/8d, Tension = 6970, Defl = 0.116},
                new Holdown(){Name = "HDU8", MinWoodThk = 4.5, Wood = eWood.DF, Nails = "(20) 1/4\" X 2 1/2\" SDS", AB_dia = 7/8d, Tension = 7870, Defl = 0.113},

                new Holdown(){Name = "HDQ8", MinWoodThk = 3.5, Wood = eWood.DF, Nails = "(20) 1/4\" X 3\" SDS", AB_dia = 7/8d, Tension = 7630, Defl = 0.094},
                new Holdown(){Name = "HDQ8", MinWoodThk = 4.5, Wood = eWood.DF, Nails = "(30) 1/4\" X 3\" SDS", AB_dia = 7/8d, Tension = 9230, Defl = 0.095},

                new Holdown(){Name = "HDU11", MinWoodThk = 5.5, Wood = eWood.DF, Nails = "(30) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 9335, Defl = 0.137},
                new Holdown(){Name = "HDU11", MinWoodThk = 7.25, Wood = eWood.DF, Nails = "(30) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 11175, Defl = 0.137},

                new Holdown(){Name = "HDU14", MinWoodThk = 3.5, Wood = eWood.DF, Nails = "(36) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 10770, Defl = 0.122},
                new Holdown(){Name = "HDU14", MinWoodThk = 5.5, Is6X6 = false, Wood = eWood.DF, Nails = "(36) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 10770, Defl = 0.122},
                new Holdown(){Name = "HDU14", MinWoodThk = 5.5, Is6X6 = true, Wood = eWood.DF, Nails = "(36) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 14445, Defl = 0.172},
                new Holdown(){Name = "HDU14", MinWoodThk = 7.25, Wood = eWood.DF, Nails = "(36) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 14390, Defl = 0.177},

                new Holdown(){Name = "HHDQ11", MinWoodThk = 5.5, Wood = eWood.DF, Nails = "(24) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 11810, Defl = 0.131},

                new Holdown(){Name = "HHDQ14", MinWoodThk = 5.5, Is6X6 = true, Wood = eWood.DF, Nails = "(30) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 13710, Defl = 0.107},
                new Holdown(){Name = "HHDQ14", MinWoodThk = 7.25, Wood = eWood.DF, Nails = "(30) 1/4\" X 2 1/2\" SDS", AB_dia = 1d, Tension = 13015, Defl = 0.107},

                new Holdown(){Name = "HD12", MinWoodThk = 3.5, Wood = eWood.DF, Nails = "(4) 1\" Stud Bolts", AB_dia = 1+1/8d, Tension = 11775, Defl = 0.171},
                new Holdown(){Name = "HD12", MinWoodThk = 4.5, Wood = eWood.DF, Nails = "(4) 1\" Stud Bolts", AB_dia = 1+1/8d, Tension = 13335, Defl = 0.177},
                new Holdown(){Name = "HD12", MinWoodThk = 7.25, Wood = eWood.DF, Nails = "(4) 1\" Stud Bolts", AB_dia = 1+1/8d, Tension = 15435, Defl = 0.194},
                new Holdown(){Name = "HD12", MinWoodThk = 5.5, Is6X6 = true, Wood = eWood.DF, Nails = "(4) 1\" Stud Bolts", AB_dia = 1+1/8d, Tension = 15510, Defl = 0.162},

                new Holdown(){Name = "HD19", MinWoodThk = 7.25, Wood = eWood.DF, Nails = "(5) 1\" Stud Bolts", AB_dia = 1+1/4d, Tension = 19360, Defl = 0.18},
                new Holdown(){Name = "HD19", MinWoodThk = 5.5, Is6X6 = true, Wood = eWood.DF, Nails = "(5) 1\" Stud Bolts", AB_dia = 1+1/4d, Tension = 19070, Defl = 0.137},
            };
        }
    }




}
