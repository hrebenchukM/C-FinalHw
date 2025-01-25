
namespace Serialize
{
    public class SoapSerialize : ISerialize
    {
        SoapFormatter? soap = null;
        FileStream? stream = null;
        public void Load(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Open);
            soap = new SoapFormatter();
            objects = (List<InfoCarrier>)soap.Deserialize(stream);
            Console.WriteLine("Десериализация успешно выполнена!");
            foreach (var student in objects)
            {
                student.Print();
            }
            stream.Close();
        }

        public void Save(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Create);
            soap = new SoapFormatter();
            soap.Serialize(stream, objects);
            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }
    }
}
