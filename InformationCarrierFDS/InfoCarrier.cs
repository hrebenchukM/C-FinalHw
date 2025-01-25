using System;
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
    [DataContract]
    // абстрактный класс «Носитель информации».

    public abstract class InfoCarrier
    {
        //имя производителя,  
        [DataMember]
        protected string manufacturer;
        // модель,
        [DataMember]
        protected string model;
        //наименование,
        [DataMember]
        protected string media_name;
        // ёмкость носителя,
        [DataMember]
        protected double capacity;
        // количество
        [DataMember]
        protected int count;


        //свойства для доступа к полям
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
            return "Manufacturer: " + Manufacturer + ", Model: " + Model + ", MediaName: " + MediaName + ", Capacity: " + Capacity + "GB, Count: " + Count;
        }

        public virtual void Load() 
        {
         
        }
        public virtual void Save() 
        {
        
        }
    }
}
