using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InformationCarrierFDS
{
    [Serializable]
    [DataContract]
    //• класс Flash - память
    public class Flash : InfoCarrier
    {
        //скорость USB
        [DataMember]
        protected double speedUSB;
    
        public double SpeedUSB
        {
            get
            {
                return speedUSB;
            }
            set
            {
                speedUSB = value;
            }
        }
        public Flash() { }

        public Flash(string man, string mod, string med, double cap, int c,int sp) : base( man,  mod,  med,  cap,  c) 
        {
            SpeedUSB = sp;
        }

        //переопределяются методы формирования отчёта, загрузки и сохранения
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
