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
    // класс съемный HDD.
    public class HDD : InfoCarrier
    {
        //скорость записи.
        [DataMember]
        protected int speedSpindle;

        public int SpeedSpindle
        {
            get
            {
                return speedSpindle;
            }
            set
            {
                speedSpindle = value;
            }
        }

        public HDD() { }
        public HDD(string man, string mod, string med, double cap, int c, int sp) : base(man, mod, med, cap, c)
        {
            SpeedSpindle = sp;
        }

        //переопределяются методы формирования отчёта, загрузки и сохранения
        public override string Report()
        {
            return base.Report() + "Speed Spindle: " + SpeedSpindle + "RPM";
        }

        public override void Load() 
        {
            Console.WriteLine("Загрузка данных на съемный HDD {0} ", Manufacturer);
        }
        public override void Save() 
        {
           Console.WriteLine("Загрузка данных на съемный HDD {0} ", Manufacturer);
        }
    }
}
