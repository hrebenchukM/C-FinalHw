using System;
using System.IO;
using System.Threading;
using InformationCarrierFDS;
using Log;
using Serialize;

namespace PriceList
{
    public class PriceListBoss//класс, в котором инкапсулируется массив ссылок типа InfoCarrier
    {
        List<InfoCarrier> objects = new List<InfoCarrier>();

        //• добавление носителя информации в список;
        public void Add(InfoCarrier inf)
        {
            Console.WriteLine("• добавление носителя информации в список;");
            objects.Add(inf);
        }
        //• удаление носителя информации из списка по заданному критерию;
        public void RemoveByCriterion(string name, object value)
        {
            objects.RemoveAll(inf => MatchCriterion(inf, name, value));
        }

        private bool MatchCriterion(InfoCarrier inf, string name, object value)
        {
            switch (name)
            {
                case "Manufacturer":
                    return inf.Manufacturer == (string)value;
                case "Model":
                    return inf.Model == (string)value;
                case "Capacity":
                    return inf.Capacity == (double)value;
                case "Count":
                    return inf.Count == (int)value;
                default:
                    return false;
            }
        }





        //• печать списка;
        public void PrintList(ILog log)

        {
            if (objects.Count == 0)
            {
                return;
            }

            Console.WriteLine("• печать списка;");
            foreach (var obj in objects)
            {
                string report  = obj.Report();
                log.Print(report);
            }
        }

        //• изменение определённых параметров носителя информации;
        public void EditInfo(string name, object oldValue, object newValue)
        {
            var editObj = objects.Where(inf => MatchCriterion(inf, name, oldValue)).ToList();

            foreach (var obj in editObj)
            {
                switch (name)
                {
                    case "Manufacturer":
                        obj.Manufacturer = (string)newValue;
                        break;
                    case "Model":
                        obj.Model = (string)newValue;
                        break;
                    case "Capacity":
                        obj.Capacity = (double)newValue;
                        break;
                    case "Count":
                        obj.Count = (int)newValue;
                        break;
                    default:
                        Console.WriteLine("Не найдент параметр для изменения");
                        break;
                }
            }
        }






        //• поиск носителя информации по заданному критерию;
        public List<InfoCarrier> SearchByCriterion(string name, object value)
        {
            var res = objects.Where(inf => MatchCriterion(inf, name, value)).ToList();

            if (res.Count == 0)
            {
                Console.WriteLine("Не найдено носителя информации по заданному критерию");
            }
            else
            {
                Console.WriteLine("Найдено {0} объект(ов) по заданному критерию.", res.Count);
            }

            return res;
        }





        //• считывание данных из файла и запись данных в файл.
        public void SaveFile(string path, ISerialize serializer)
        {
            Console.WriteLine("• запись данных в файл ");
            serializer.Save(path, objects);
        }
        public void LoadFile(string path, ISerialize serializer)
        {
            Console.WriteLine("• считывание данных из файла ");
            serializer.Load(path,objects);
        }

    }

}
