using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class CorrectXML
    {
        public bool CheckXML(string xml)
        {
            if (xml.Contains("ghl"))
                return true;
            else
                return false;
        }
    }
}
