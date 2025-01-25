
using System.Runtime.Serialization.Formatters.Soap;
using InformationCarrierFDS;

namespace Serialize
{
    public class SoapSerialize : ISerialize
    {
        SoapFormatter? soap = null;
        FileStream? stream = null;
        public SoapSerialize() { }
        public void Load(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Open);
            soap = new SoapFormatter();
            var loadObjects = (List<InfoCarrier>)soap.Deserialize(stream);
            Console.WriteLine("Десериализация успешно выполнена!");
            objects.Clear();
            foreach (var obj in loadObjects)
            {
                objects.Add(obj);
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
