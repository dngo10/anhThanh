using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AnchorSCH
    {
        public string Name { get; set; }
        public double Dia { get; set; }
        public int Tension { get; set; }
        public double Defl { get { return 0; } }

        public override string ToString()
        {
            return Name;
        }

    }

    public class SSTB : AnchorSCH
    {
        public int MinStemwall { get; set; }
        public eLocation Location { get; set; }
        public double le { get; set; }
    }

    public class PAB : AnchorSCH
    {
        public double de { get; set; }
        public double F { get; set; }
        public double fc { get; set; }
    }


    public class AnchorData
    {
        private AnchorSCH[] mSimpSonAB;
        public AnchorSCH[] SimpSonAB { get { return mSimpSonAB; } }

        public AnchorData()
        {
            mSimpSonAB = new AnchorSCH[]
            {
                new SSTB() { Name = "SSTB16", MinStemwall = 6, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 2550},
                new SSTB() { Name = "SSTB16", MinStemwall = 6, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 2550},
                new SSTB() { Name = "SSTB16", MinStemwall = 8, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 2550},
                new SSTB() { Name = "SSTB16", MinStemwall = 8, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 2550},
                new SSTB() { Name = "SSTB16", MinStemwall = 12, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 3780},
                new SSTB() { Name = "SSTB16", MinStemwall = 12, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 3780},

                new SSTB() { Name = "SSTB20", MinStemwall = 6, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 3145},
                new SSTB() { Name = "SSTB20", MinStemwall = 6, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 2960},
                new SSTB() { Name = "SSTB20", MinStemwall = 8, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 3145},
                new SSTB() { Name = "SSTB20", MinStemwall = 8, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 2960},
                new SSTB() { Name = "SSTB20", MinStemwall = 12, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 4785},
                new SSTB() { Name = "SSTB20", MinStemwall = 12, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 4785},

                new SSTB() { Name = "SSTB24", MinStemwall = 6, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 3740},
                new SSTB() { Name = "SSTB24", MinStemwall = 6, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 3325},
                new SSTB() { Name = "SSTB24", MinStemwall = 8, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 3740},
                new SSTB() { Name = "SSTB24", MinStemwall = 8, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 3325},
                new SSTB() { Name = "SSTB24", MinStemwall = 12, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Midwall, Tension = 5790},
                new SSTB() { Name = "SSTB24", MinStemwall = 12, Dia = 5/8d, le = 20+5/8d, Location = eLocation.Corner, Tension = 5790},

                new SSTB() { Name = "SSTB28", MinStemwall = 8, Dia = 7/8d, le = 24+7/8d, Location = eLocation.Midwall, Tension = 8315},
                new SSTB() { Name = "SSTB28", MinStemwall = 8, Dia = 7/8d, le = 24+7/8d, Location = eLocation.Corner, Tension = 7315},
                new SSTB() { Name = "SSTB28", MinStemwall = 12, Dia = 7/8d, le = 24+7/8d, Location = eLocation.Midwall, Tension = 11060},
                new SSTB() { Name = "SSTB28", MinStemwall = 12, Dia = 7/8d, le = 24+7/8d, Location = eLocation.Corner, Tension = 11645},

                new SSTB() { Name = "SSTB34", MinStemwall = 8, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Midwall, Tension = 8315},
                new SSTB() { Name = "SSTB34", MinStemwall = 8, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Corner, Tension = 7315},
                new SSTB() { Name = "SSTB34", MinStemwall = 12, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Midwall, Tension = 11060},
                new SSTB() { Name = "SSTB34", MinStemwall = 12, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Corner, Tension = 11645},

                new SSTB() { Name = "SSTB36", MinStemwall = 8, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Midwall, Tension = 8315},
                new SSTB() { Name = "SSTB36", MinStemwall = 8, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Corner, Tension = 7315},
                new SSTB() { Name = "SSTB36", MinStemwall = 12, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Midwall, Tension = 11060},
                new SSTB() { Name = "SSTB36", MinStemwall = 12, Dia = 7/8d, le = 28+7/8d, Location = eLocation.Corner, Tension = 11645},

                new PAB() { Name = "PAB4", Dia = 1/2d, de = 5, F = 7.5, Tension = 4270, fc = 2500},
                new PAB() { Name = "PAB5", Dia = 5/8d, de = 6.5, F = 10, Tension = 6675, fc = 2500},
                new PAB() { Name = "PAB6", Dia = 3/4d, de = 7.5, F = 11.5, Tension = 9060, fc = 2500},
                new PAB() { Name = "PAB7", Dia = 7/8d, de = 9, F = 13.5, Tension = 11905, fc = 2500},
                new PAB() { Name = "PAB8", Dia = 1d, de = 11, F = 16.5, Tension = 15996, fc = 2500},
                new PAB() { Name = "PAB9", Dia = 1+1/8d, de = 12.5, F = 19, Tension = 19795, fc = 2500},
                new PAB() { Name = "PAB10", Dia = 1+1/4d, de = 14.5, F = 22, Tension = 25350, fc = 2500},


                new PAB() { Name = "PAB4", Dia = 1/2d, de = 4.5, F = 7, Tension = 4270, fc = 3000},
                new PAB() { Name = "PAB5", Dia = 5/8d, de = 6, F = 9, Tension = 6675, fc = 3000},
                new PAB() { Name = "PAB6", Dia = 3/4d, de = 7, F = 10.5, Tension = 8945, fc = 3000},
                new PAB() { Name = "PAB7", Dia = 7/8d, de = 9, F = 13.5, Tension = 11905, fc = 3000},
                new PAB() { Name = "PAB8", Dia = 1d, de = 11, F = 16.5, Tension = 15996, fc = 3000},
                new PAB() { Name = "PAB9", Dia = 1+1/8d, de = 12.5, F = 19, Tension = 19795, fc = 3000},
                new PAB() { Name = "PAB10", Dia = 1+1/4d, de = 14.5, F = 22, Tension = 25350, fc = 3000},

            };
        }

        public static AnchorSCH NONE { get { return new AnchorSCH() { Name = "NONE", Tension = 0 }; } }
    }
}