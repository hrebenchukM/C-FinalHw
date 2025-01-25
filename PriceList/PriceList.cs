using System;
using InformationCarrierFDS;
using Log;

namespace PriceList
{
    public class PriceList//класс, в котором инкапсулируется массив ссылок типа InfoCarrier
    {
        List<InfoCarrier> objects = new List<InfoCarrier>();

        public void Add(InfoCarrier inf)
        {
            objects.Add(inf);
        }


    }

}
