using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using InformationCarrierFDS;

namespace Serialize
{
    public class JSONSerialize : ISerialize
    {
        DataContractJsonSerializer? jsonFormatter = null;
        FileStream? stream = null;
        public JSONSerialize() { }
        public void  Load(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Open);
            jsonFormatter = new DataContractJsonSerializer(typeof(List<InfoCarrier>));
            objects = jsonFormatter.ReadObject(stream) as List<InfoCarrier>;
            foreach (var obj in objects)
            {
                obj.Report();
            }
            stream.Close();
        }

        public void Save(string path, List<InfoCarrier> objects)
        {
            stream = new FileStream(path, FileMode.Create);
            jsonFormatter = new DataContractJsonSerializer(typeof(List<InfoCarrier>));
            jsonFormatter.WriteObject(stream, objects);
            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }
    }
}
