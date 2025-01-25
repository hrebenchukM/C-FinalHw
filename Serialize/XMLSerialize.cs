using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InformationCarrierFDS;

namespace Serialize
{
    public class XMLSerialize : ISerialize
    {
        XmlSerializer? serializer = null;
        FileStream? stream = null;
        public void Load(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Open);
            serializer = new XmlSerializer(typeof(List<InfoCarrier>));
            objects = serializer.Deserialize(stream) as List<InfoCarrier>;
            Console.WriteLine("Десериализация успешно выполнена!");
            foreach (var obj in objects)
            {
                obj.Report();
            }
            stream.Close();
        }

        public void Save(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Create);
            serializer = new XmlSerializer(typeof(List<InfoCarrier>));
            serializer.Serialize(stream, objects);
            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }
    }
}
