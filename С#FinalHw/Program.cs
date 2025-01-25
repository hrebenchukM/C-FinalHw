using System.Threading;
using Log;
using PriceList;
using InformationCarrierFDS;
using System.Reflection;
using System.Xml.Linq;
using Serialize;
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PriceListBoss priceList = new PriceListBoss();
            ILog log = new ConsoleLog();

            while (true)
            {
            Console.WriteLine("1.Добавление носителя информации в список");
            Console.WriteLine("2. Удаление носителя информации из списка по заданному критерию");
            Console.WriteLine("3. Печать списка");
            Console.WriteLine("4. Изменение определённых параметров носителя информации");
            Console.WriteLine("5. Поиск носителя информации по заданному критерию");
            Console.WriteLine("6. Считывание данных из файла");
            Console.WriteLine("7. Запись данных в файл");
            Console.WriteLine("0.Выход");
            Console.Write("Выберите пунктик: ");

            string words = Console.ReadLine();

            switch (words)
            {
                case "1"://Добавление носителя информации в список
                    Console.Write("Введите имя производителя: ");
                    string manufacturerA = Console.ReadLine();

                    Console.Write("Введите модель: ");
                    string modelA = Console.ReadLine();

                    Console.Write("Введите наименование: (Flash/DVD/HDD) ");
                    string media_nameA = Console.ReadLine();


                    Console.Write("Введите ёмкость носителя: ");
                    double capacityA = double.Parse(Console.ReadLine());

                    Console.Write("Введите количество: ");
                    int countA = int.Parse(Console.ReadLine());


                    InfoCarrier obj = null;


                    switch (media_nameA)
                    {
                        case "Flash":
                            Console.Write("Введите скорость USB: ");
                            double speedUSBA = double.Parse(Console.ReadLine());
                            obj = new Flash(manufacturerA, modelA, media_nameA, capacityA, countA, speedUSBA);
                            break;

                        case "HDD":
                            Console.Write("Введите скорость вращения шпинделя: ");
                            int speedSpindleA = int.Parse(Console.ReadLine());
                            obj = new HDD(manufacturerA, modelA, media_nameA, capacityA, countA, speedSpindleA);
                            break;

                        case "DVD":
                            Console.Write("Введите скорость записи: ");
                            int speedWriteA = int.Parse(Console.ReadLine());
                            obj = new DVD(manufacturerA, modelA, media_nameA, capacityA, countA, speedWriteA);
                            break;

                        default:
                            Console.WriteLine("Неверное наименование");
                            return;
                    }

                    priceList.Add(obj);
                    break;

                case "2"://Удаление носителя информации из списка по заданному критерию

                    break;

                case "3"://Печать списка
                    priceList.PrintList(log);
                    break;

                case "4"://Изменение определённых параметров носителя информации
                    break;

                case "5"://Поиск носителя информации по заданному критерию
                    break;


                case "6"://Считывание данных из файла
                  
                    Console.Write("Прочитать файл: ");
                    Console.Write("Введите способ: (Xml/Json/Soap) ");
                    string ser_nameL = Console.ReadLine();

                    ISerialize serializerL = null;


                    switch (ser_nameL)
                    {
                        case "Xml":
                            serializerL = new XMLSerialize();
                            break;

                        case "Json":
                            serializerL = new JSONSerialize();
                            break;

                        case "Soap":
                            serializerL = new SoapSerialize(); 
                            break;

                        default:
                            Console.WriteLine("Неверный способ");
                            return;
                    }
                    Console.Write("Введите путь (.xml/.json): ");
                    string pathL = Console.ReadLine();


                    priceList.LoadFile(pathL, serializerL);
                    Console.WriteLine("Загружено.");

                    break;

                case "7"://Запись данных в файл
                    Console.Write("Записать файл: ");
                    Console.Write("Введите способ: (Xml/Json/Soap) ");
                    string ser_nameS = Console.ReadLine();

                    ISerialize serializerS = null;


                    switch (ser_nameS)
                    {
                        case "Xml":
                            serializerS = new XMLSerialize();
                            break;

                        case "Json":
                            serializerS = new JSONSerialize();
                            break;

                        case "Soap":
                            serializerS = new SoapSerialize();
                            break;

                        default:
                            Console.WriteLine("Неверный способ");
                            return;
                    }
                    Console.Write("Введите путь (.xml/.json): ");
                    string pathS = Console.ReadLine();

                    priceList.SaveFile(pathS, serializerS);
                    Console.WriteLine("сохранено.");

                    break;

              
                case "0"://Выход
                    return;

                default:
                    Console.WriteLine("Ошибочка");
                    break;
            }


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("По окончании try-блока.");
        }
    }
}