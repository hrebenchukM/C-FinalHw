using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_FinalHw
{
    class Flash : InfoCarrier
    {
        public int SpeedUSB { get; set; }

        public Flash(string man, string mod, string med, double cap, int c,int sp) : base( man,  mod,  med,  cap,  c) 
        {
            SpeedUSB = sp;
        }
        public override string Report()
        {
           return base.Report()+ "Speed USB: " + SpeedUSB + "MB/sec";
        }

        public override void Load()
        {
            base.Load();
            Console.WriteLine("на Flash-память {0} ",Manufacturer);
        }
        public override void Save() 
        {
          base.Save();
          Console.WriteLine("на Flash-память {0} ", Manufacturer);

        }

    }
}
