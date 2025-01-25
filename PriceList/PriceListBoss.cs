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

        //• поиск носителя информации по заданному критерию;

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
