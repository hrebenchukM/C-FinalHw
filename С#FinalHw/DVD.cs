using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_FinalHw
{
    class DVD : InfoCarrier
    {
        public int SpeedWrite { get; set; }

        public DVD(string man, string mod, string med, double cap, int c, int sp) : base(man, mod, med, cap, c)
        {
            SpeedWrite = sp;
        }

        public override string Report()
        {
            return base.Report() + "Speed Write: " + SpeedWrite + "x";
        }

        public override void Load() 
        {
            base.Load();
            Console.WriteLine("на DVD-диск {0} ", Manufacturer);
        }
        public override void Save() 
        {
            base.Save();
            Console.WriteLine("на DVD-диск {0} ", Manufacturer);
        }
    }
}
