using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aquaFORCE
{
    class CheckAddress
    {
        public string CheckAddressName(string address)
        {
            address = address.ToLower();

            if (!(address.StartsWith("http://") || address.StartsWith("https://")))
                address = "http://" + address;

            if (!(address.EndsWith("/xml.xml") || address.EndsWith(".xml")))
                address = address + "/xml.xml";

            return address;
        }
    }
}
