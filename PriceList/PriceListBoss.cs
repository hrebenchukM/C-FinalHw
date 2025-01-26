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
        public void RemoveCarrierByCriterion(string criterionName, string criterionValue)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список пуст. Удаление невозможно.");
                return;
            }

            objects.RemoveAll(item =>
                (criterionName == "Model" && item.Model == criterionValue) ||
                (criterionName == "Manufacturer" && item.Manufacturer == criterionValue) ||
                (criterionName == "MediaName" && item.MediaName == criterionValue) ||
                (criterionName == "Capacity" && item.Capacity.ToString() == criterionValue) ||
                (criterionName == "Count" && item.Count.ToString() == criterionValue) ||
                (criterionName == "SpeedUSB" && item is Flash flash && flash.SpeedUSB.ToString() == criterionValue) ||
                (criterionName == "SpeedWrite" && item is DVD dvd && dvd.SpeedWrite.ToString() == criterionValue) ||
                (criterionName == "SpeedSpindle" && item is HDD hdd && hdd.SpeedSpindle.ToString() == criterionValue)
            );

            Console.WriteLine("Удаление носителя информации завершено.");
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
        public void EditInfo(string criterionName, string criterionValue, string newCriterion, string newValue)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список пуст. Изменение невозможно");
                return;
            }

            var objectsEdit = objects.Where(item =>
                (criterionName == "Model" && item.Model == criterionValue) ||
                (criterionName == "Manufacturer" && item.Manufacturer == criterionValue) ||
                (criterionName == "MediaName" && item.MediaName == criterionValue) ||
                (criterionName == "Capacity" && item.Capacity.ToString() == criterionValue) ||
                (criterionName == "Count" && item.Count.ToString() == criterionValue) ||
                (criterionName == "SpeedUSB" && item is Flash flash && flash.SpeedUSB.ToString() == criterionValue) ||
                (criterionName == "SpeedWrite" && item is DVD dvd && dvd.SpeedWrite.ToString() == criterionValue) ||
                (criterionName == "SpeedSpindle" && item is HDD hdd && hdd.SpeedSpindle.ToString() == criterionValue)
            ).ToList();

            if (objectsEdit.Count == 0)
            {
                Console.WriteLine("Носители информации по заданному критерию не найдены");
                return;
            }



            foreach (var obj in objectsEdit)
            {
                switch (newCriterion)
                {
                    case "Model":
                        obj.Model = newValue;
                        break;
                    case "Manufacturer":
                        obj.Manufacturer = newValue;
                        break;
                    case "MediaName":
                        obj.MediaName = newValue;
                        break;
                    case "Capacity":
                        if (double.TryParse(newValue, out double newCapacity))
                            obj.Capacity = newCapacity;
                        else
                            Console.WriteLine("Неправильное значение для Capacity.");
                        break;
                    case "Count":
                        if (int.TryParse(newValue, out int newCount))
                            obj.Count = newCount;
                        else
                            Console.WriteLine("Неправильное значение для Count.");
                        break;
                    case "SpeedUSB":
                        if (obj is Flash flashCarrier && double.TryParse(newValue, out double newSpeedUSB))
                            flashCarrier.SpeedUSB = newSpeedUSB;
                        else
                            Console.WriteLine("Неправильное значение для SpeedUSB или носитель не является Flash.");
                        break;
                    case "SpeedWrite":
                        if (obj is DVD dvdCarrier && int.TryParse(newValue, out int newSpeedWrite))
                            dvdCarrier.SpeedWrite = newSpeedWrite;
                        else
                            Console.WriteLine("Неправильное значение для SpeedWrite или носитель не является DVD.");
                        break;
                    case "SpeedSpindle":
                        if (obj is HDD hddCarrier && int.TryParse(newValue, out int newSpeedSpindle))
                            hddCarrier.SpeedSpindle = newSpeedSpindle;
                        else
                            Console.WriteLine("Неправильное значение для SpeedSpindle или носитель не является HDD.");
                        break;
                    default:
                        Console.WriteLine("Критерий не найден: {0}", newCriterion);
                        break;
                }
            }

            Console.WriteLine("Изменение параметров завершено.");
        }





        //• поиск носителя информации по заданному критерию;
        public List<InfoCarrier> SearchCarrierByCriterion(string criterionName, string criterionValue)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список пуст. Поиск невозможен.");
                return new List<InfoCarrier>();
            }

            var res = objects.Where(item =>
                (criterionName == "Model" && item.Model == criterionValue) ||
                (criterionName == "Manufacturer" && item.Manufacturer == criterionValue) ||
                (criterionName == "MediaName" && item.MediaName == criterionValue) ||
                (criterionName == "Capacity" && item.Capacity.ToString() == criterionValue) ||
                (criterionName == "Count" && item.Count.ToString() == criterionValue) ||
                (criterionName == "SpeedUSB" && item is Flash flash && flash.SpeedUSB.ToString() == criterionValue) ||
                (criterionName == "SpeedWrite" && item is DVD dvd && dvd.SpeedWrite.ToString() == criterionValue) ||
                (criterionName == "SpeedSpindle" && item is HDD hdd && hdd.SpeedSpindle.ToString() == criterionValue)
            ).ToList();

            if (res.Count > 0)
            {
                Console.WriteLine("Найдено {0} носителей", res.Count);
            }
            else
            {
                Console.WriteLine("Носители информации по заданному критерию не найдены");
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
