﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace InformationCarrierFDS
{
    // для XML-сериализации необходим открытый доступ к классу
    [Serializable]
    [XmlRoot("InfoCarrier")]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(HDD))]
    [XmlInclude(typeof(DVD))]

    [KnownType(typeof(Flash))]
    [KnownType(typeof(HDD))]
    [KnownType(typeof(DVD))]
    [DataContract]
    // абстрактный класс «Носитель информации».

    public abstract class InfoCarrier
    {
        //имя производителя,  
        protected string manufacturer;
        // модель,
        protected string model;
        //наименование,
        protected string media_name;
        // ёмкость носителя,
        protected double capacity;
        // количество
        protected int count;


        //свойства для доступа к полям
        [DataMember]
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }

        [DataMember]
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        [DataMember]
        public string MediaName
        {
            get
            {
                return media_name;
            }
            set
            {
                media_name = value;
            }
        }

        [DataMember]
        public double Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        [DataMember]
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        
        public InfoCarrier()
        {
        }
        public InfoCarrier(string man, string mod, string med, double cap, int c)
        {
            Manufacturer = man;
            Model = mod;    
            MediaName = med;
            Capacity = cap;
            Count = c;
        }
        //виртуальные методы формирования отчёта, загрузки данных и сохранения данных
        public virtual string Report()
        {
            return "Manufacturer: " + Manufacturer + ", Model: " + Model + ", MediaName: " + MediaName + ", Capacity: " + Capacity + "GB, Count: " + Count + ", ";
        }

        public virtual void Load() 
        {
         
        }
        public virtual void Save() 
        {
        
        }
    }
}
