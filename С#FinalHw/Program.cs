using System.Threading;
using Log;
using PriceList;
using InformationCarrierFDS;
using System.Reflection;
using System.Xml.Linq;
using Serialize;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PriceListBoss priceList = new PriceListBoss();
           
            while (true)
            {
            Console.WriteLine("1.Добавление носителя информации в список");
            Console.WriteLine("2. Удаление носителя информации из списка по заданному критерию");
            Console.WriteLine("3. Печать списка");
            Console.WriteLine("4. Изменение определённых параметров носителя информации");
            Console.WriteLine("5. Поиск носителя информации по заданному критерию");
            Console.WriteLine("6. Десериализация");
            Console.WriteLine("7. Сериализация");
            Console.WriteLine("8. Считывание данных из текстового файла");
            Console.WriteLine("9. Запись данных в текстовый файл");

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

                case "2": // Удаление носителя информации из списка по заданному критерию
                        Console.WriteLine("Введите название критерия (например: Model, Manufacturer, MediaName, Capacity, Count, SpeedUSB, SpeedWrite, SpeedSpindle): ");
                        string criterionNameD = Console.ReadLine();

                        Console.WriteLine("Введите значение для критерия {0}: ", criterionNameD);
                        string criterionValueD = Console.ReadLine();

                        priceList.RemoveCarrierByCriterion(criterionNameD, criterionValueD);
                        break;


                case "3"://Печать списка
                        //ILog log1 = new ConsoleLog();
                        //priceList.PrintList(log1);
                        Console.WriteLine("Выберете способ печати (например: ConsoleLog/FileLog): ");

                        string choiceP = Console.ReadLine();
                        switch (choiceP)
                        {
                            case "ConsoleLog":
                                ILog log1 = new ConsoleLog();
                                priceList.PrintList(log1);
                                break;

                            case "FileLog":
                                ILog log2 = new FileLog("data.txt");
                                priceList.PrintList(log2);
                                break;

                            default:
                                Console.WriteLine("Неверный способ");
                                return;
                        }
                        break;

                case "4"://Изменение определённых параметров носителя информации
                        Console.WriteLine("Введите название критерия для поиска (например: Model, Manufacturer, MediaName, Capacity, Count, SpeedUSB, SpeedWrite, SpeedSpindle): ");
                        string criterionNameES = Console.ReadLine();

                        Console.WriteLine("Введите значение для критерия {0}: ", criterionNameES);
                        string criterionValueES = Console.ReadLine();

                        Console.WriteLine("Введите название критерия, которое хотите изменить (например: Model, Manufacturer, MediaName, Capacity, Count, SpeedUSB, SpeedWrite, SpeedSpindle): ");
                        string criterionNameE = Console.ReadLine();

                        Console.WriteLine("Введите новое значение для критерия {0}: ", criterionNameE);
                        string criterionValueE = Console.ReadLine();

                        priceList.EditInfo(criterionNameES, criterionValueES, criterionNameE, criterionValueE);
                break;

                case "5"://Поиск носителя информации по заданному критерию
                        Console.WriteLine("Введите название критерия (например: Model, Manufacturer, MediaName, Capacity, Count, SpeedUSB, SpeedWrite, SpeedSpindle): ");
                        string criterionNameS = Console.ReadLine();

                        Console.WriteLine("Введите значение для критерия {0}: ", criterionNameS);
                        string criterionValueS = Console.ReadLine();

                        var resS = priceList.SearchCarrierByCriterion(criterionNameS, criterionValueS);

                        foreach (var carrier in resS)
                        {
                            Console.WriteLine(carrier.Report());
                        }
                        break;


                case "6"://Десериализация

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


                    priceList.Deserialize(pathL, serializerL);
                    Console.WriteLine("Загружено.");

                    break;

                case "7"://Сериализация
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

                    priceList.Serialize(pathS, serializerS);
                    Console.WriteLine("сохранено.");

                break;

                case "8"://Считывание данных из файла
                        Console.Write("Введите путь (.txt): ");
                        string pathLT = Console.ReadLine();
                        priceList.LoadFile(pathLT);
                        break;



                case "9"://Запись данных в файл
                        Console.Write("Введите путь (.txt): ");
                        string pathST = Console.ReadLine();
                        priceList.SaveFile(pathST);
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