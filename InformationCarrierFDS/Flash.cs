using System;
using System.Collections.Generic;
using System.IO;
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
        protected double speedUSB;

        [DataMember]
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
        // для XML-сериализации необходим конструктор по умолчанию
        public Flash() { }

        public Flash(string man, string mod, string med, double cap, int c, double sp) : base( man,  mod,  med,  cap,  c) 
        {
            SpeedUSB = sp;
        }

        //переопределяются методы формирования отчёта, загрузки и сохранения
        public override string Report()
        {
           return base.Report()+ "Speed USB: " + SpeedUSB + "MB/sec";
        }

        public override void Load(StreamReader sr)
        {
            base.Load(sr);
            SpeedUSB = double.Parse(sr.ReadLine());

            Console.WriteLine("SpeedUSB: {0}", SpeedUSB);
        }
        public override void Save(StreamWriter sw) 
        {
            base.Save(sw);
            sw.WriteLine(SpeedUSB);
        }

    }
}
