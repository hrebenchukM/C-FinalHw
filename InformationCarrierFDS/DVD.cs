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
        // скорость записи
        protected int speedWrite;

        [DataMember]
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
        // для XML-сериализации необходим конструктор по умолчанию
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



        public override void Load(StreamReader sr)
        {
            base.Load(sr);
            SpeedWrite = int.Parse(sr.ReadLine());

            Console.WriteLine("SpeedWrite: {0}", SpeedWrite);

        }
        public override void Save(StreamWriter sw)
        {
            base.Save(sw);
            sw.WriteLine(SpeedWrite);
        }



    }
}
