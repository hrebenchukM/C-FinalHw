﻿using System;
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
        //скорость вращения шпинделя
        protected int speedSpindle;

        [DataMember]
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
        // для XML-сериализации необходим конструктор по умолчанию
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

        public override void Load(StreamReader sr)
        {
            base.Load(sr);
            SpeedSpindle = int.Parse(sr.ReadLine());

            Console.WriteLine("SpeedSpindle: {0}", SpeedSpindle);
        }
        public override void Save(StreamWriter sw)
        {
            base.Save(sw);
            sw.WriteLine(SpeedSpindle);
        }

    }
}
