using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationCarrierFDS
{
    public class Flash : InfoCarrier
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
            Console.WriteLine("Загрузка данных на Flash-память {0} ", Manufacturer);
        }
        public override void Save() 
        {
          Console.WriteLine("Загрузка данных на Flash-память {0} ", Manufacturer);

        }

    }
}
