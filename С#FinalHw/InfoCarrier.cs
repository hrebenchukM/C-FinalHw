using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_FinalHw
{
    abstract class InfoCarrier
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string MediaName { get; set; }
        public double Capacity { get; set; } 
        public int Count { get; set; }

        public InfoCarrier(string man, string mod, string med, double cap, int c)
        {
            Manufacturer = man;
            Model = mod;    
            MediaName = med;
            Capacity = cap;
            Count = c;
        }
        public virtual string Report()
        {
            return "Manufacturer: " + Manufacturer + ", Model: " + Model + ", MediaName: " + MediaName + ", Capacity: " + Capacity + "GB, Count: " + Count;
        }

        public virtual void Load() 
        {
            Console.WriteLine("Загрузка данных ");
        }
        public virtual void Save() 
        {
            Console.WriteLine("Сохранение данных ");
        }
    }
}
