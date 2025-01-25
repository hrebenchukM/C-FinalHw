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
    //• класс DVD - диск;
    public class DVD : InfoCarrier
    {
        // скорость вращения шпинделя
        [DataMember]
        protected int speedWrite;

        public int SpeedWrite
        {
            get
            {
                return speedWrite;
            }
            set
            {
                speedWrite = value;
            }
        }

        public DVD() {}
        public DVD(string man, string mod, string med, double cap, int c, int sp) : base(man, mod, med, cap, c)
        {
            SpeedWrite = sp;
        }
        //переопределяются методы формирования отчёта, загрузки и сохранения
        public override string Report()
        {
            return base.Report() + "Speed Write: " + SpeedWrite + "x";
        }

        public override void Load() 
        {
            Console.WriteLine("Загрузка данных на DVD-диск {0} ", Manufacturer);
        }
        public override void Save() 
        {
             Console.WriteLine("Загрузка данных на DVD-диск {0} ", Manufacturer);
        }
    }
}
