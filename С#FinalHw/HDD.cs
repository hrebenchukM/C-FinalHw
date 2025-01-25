using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_FinalHw
{
    class HDD : InfoCarrier
    {
        public int SpeedSpindle { get; set; }

        public HDD(string man, string mod, string med, double cap, int c, int sp) : base(man, mod, med, cap, c)
        {
            SpeedSpindle = sp;
        }

        public override string Report()
        {
            return base.Report() + "Speed Spindle: " + SpeedSpindle + "RPM";
        }

        public override void Load() 
        {
            base.Load();
            Console.WriteLine("на съемный HDD {0} ", Manufacturer);
        }
        public override void Save() 
        {
            base.Save();
            Console.WriteLine("на съемный HDD {0} ", Manufacturer);
        }
    }
}
