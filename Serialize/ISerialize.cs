
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;

/*
 Сериализация представляет процесс преобразования какого-либо объекта в поток байтов. 
 После преобразования мы можем этот поток байтов или записать на диск или сохранить его временно в памяти. 
 А при необходимости можно выполнить обратный процесс - десериализацию, 
 то есть получить из потока байтов ранее сохраненный объект.
 Чтобы объект определенного класса можно было сериализовать, надо этот класс пометить атрибутом Serializable.
 Если мы не хотим, чтобы какой-то член класса сериализовался, то мы его помечаем атрибутом NonSerialized.
    В .NET можно использовать следующие форматы:
    - SOAP
    - xml
    - JSON
 Для каждого формата предусмотрен свой класс: 
 * для формата SOAP - класс SoapFormatter, 
 * для xml - XmlSerializer, 
 * для json - DataContractJsonSerializer
 * 
 Протокол SOAP (Simple Object Access Protocol) представляет простой протокол для обмена данными между различными платформами. 
 При такой сериализации данные упакуются в конверт SOAP, данные в котором имеют вид xml-подобного документа.
 * 
 JSON (JavaScript Object Notation) — текстовый формат обмена данными, основанный на JavaScript
 и обычно используемый именно с этим языком. Чтобы пометить класс как сериализуемый, к нему применяется атрибут DataContract, 
 а ко всем его сериализуемым свойствам - атрибут DataMember.
 */

namespace Serialize
{
    public interface ISerialize
    {
        void Save(string path, List<InfoCarrier> objects);
        public void Load(string path, List<InfoCarrier> objects);
    }
}
