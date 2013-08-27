using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace aquaFORCE
{
    class ParseXML
    {
        string rawXML;

        public List<Lighting> GetLighting(string xml)
        {
            XDocument xmlData = XDocument.Parse(xml);

            List<Lighting> lightingData = new List<Lighting>();

            var lightingElements = from lightingElement in xmlData.Descendants("data")
                                 where lightingElement.Attribute("group").Value == "Illumination"
                                 select lightingElement;

            foreach (XElement lightingElement in lightingElements)
            {
                string value = Regex.Replace(lightingElement.Element("value").Value, "[^0-9]", "");
                value.Trim();
               
                int lightValue = Convert.ToInt16(value);

                Lighting data = new Lighting()
                {
                    Description = lightingElement.Element("desc").Value,
                    Value = lightValue,
                    Index = Convert.ToInt16(lightingElement.Element("index").Value)
                };
                lightingData.Add(data);
            }

            return lightingData;
        }

        public List<Overview> GetOverview(string xml)
        {
            XDocument xmlData = XDocument.Parse(xml);

            List<Overview> overviewData = new List<Overview>();

            var overviewElements = from overviewElement in xmlData.Descendants("data")
                                 where overviewElement.Attribute("group").Value == "Sensors"
                                 select overviewElement;

            foreach (XElement overviewElement in overviewElements)
            {
                Overview data = new Overview()
                {
                    Description = overviewElement.Element("desc").Value,
                    Value = overviewElement.Element("value").Value,
                    Shortname = overviewElement.Element("short_name").Value,
                    Index = Convert.ToInt16(overviewElement.Element("index").Value)
                };
                overviewData.Add(data);
            }

            return overviewData;
        }

        public List<Switches> GetSwitches(string xml)
        {
            XDocument xmlData = XDocument.Parse(xml);

            List<Switches> switchData = new List<Switches>();

            var switchElements = from switchElement in xmlData.Descendants("data")
                                 where switchElement.Attribute("group").Value == "Switch"
                                 select switchElement;

            foreach (XElement switchElement in switchElements)
            {
                bool valueData;

                if (switchElement.Element("value").Value == "On")
                    valueData = true;
                else
                    valueData = false;

                Switches data = new Switches()
                {
                    Description = switchElement.Element("desc").Value,
                    Value = valueData
                };
                switchData.Add(data);
            }

            return switchData;
        }


        public List<Systems> GetSystem(string xml)
        {
            this.rawXML = xml;
            XDocument xmlData = XDocument.Parse(rawXML);
           
            List<Systems> systemData = new List<Systems>();

            var systemElements = from systemElement in xmlData.Descendants("data")
                                 where systemElement.Attribute("group").Value == "System"
                                 select systemElement;

            

            foreach (XElement systemElement in systemElements) 
            {
                Systems data = new Systems()
                {
                    Description = systemElement.Element("desc").Value,
                    Value = systemElement.Element("value").Value
                };
                systemData.Add(data);
                    
            }
            
            return systemData;

        }
    }
}
