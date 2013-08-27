/*
 * ParseXML.cs
 * 
 * Author: David Jackson 2013
 * 
 * Class takes raw XML data and pulls out specific data
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;

namespace aquaFORCE
{
    class ParseXML
    {
        public List<Lighting> GetLighting(string xml)
        {
            //make xml file off raw xml
            XDocument xmlData = XDocument.Parse(xml);
            //create array list
            List<Lighting> lightingData = new List<Lighting>();
            //Specify where lighting data is located
            var lightingElements = from lightingElement in xmlData.Descendants("data")
                                   where lightingElement.Attribute("group").Value == "Illumination"
                                   select lightingElement;
            //Find all lights
            foreach (XElement lightingElement in lightingElements)
            {
                //Get just number % value
                string value = Regex.Replace(lightingElement.Element("value").Value, "[^0-9]", "");
                value.Trim();

                int lightValue = Convert.ToInt16(value);
                //make into lighting class
                Lighting data = new Lighting()
                {
                    Description = lightingElement.Element("desc").Value,
                    Value = lightValue,
                    Index = Convert.ToInt16(lightingElement.Element("index").Value)
                };
                //add data to array list
                lightingData.Add(data);
            }

            return lightingData;
        }

        public List<Overview> GetOverview(string xml)
        {
            //make xml file off raw xml string
            XDocument xmlData = XDocument.Parse(xml);
            //create overview list
            List<Overview> overviewData = new List<Overview>();
            //specifiy overview item locations
            var overviewElements = from overviewElement in xmlData.Descendants("data")
                                   where overviewElement.Attribute("group").Value == "Sensors"
                                   select overviewElement;
            //get each record and put into overview class
            foreach (XElement overviewElement in overviewElements)
            {
                Overview data = new Overview()
                {
                    Description = overviewElement.Element("desc").Value,
                    Value = overviewElement.Element("value").Value,
                    Shortname = overviewElement.Element("short_name").Value,
                    Index = Convert.ToInt16(overviewElement.Element("index").Value)
                };
                //add overview class to list array
                overviewData.Add(data);
            }

            return overviewData;
        }

        public List<Switches> GetSwitches(string xml)
        {
            //make xml file off raw xml string
            XDocument xmlData = XDocument.Parse(xml);
            //create switch array list
            List<Switches> switchData = new List<Switches>();
            //specify switch items locations
            var switchElements = from switchElement in xmlData.Descendants("data")
                                 where switchElement.Attribute("group").Value == "Switch"
                                 select switchElement;
            //get each record and put into switch class
            foreach (XElement switchElement in switchElements)
            {
                bool valueData;
                //set whether switch is on or off
                if (switchElement.Element("value").Value == "On")
                    valueData = true;
                else
                    valueData = false;

                Switches data = new Switches()
                {
                    Description = switchElement.Element("desc").Value,
                    Value = valueData,
                    Index = Convert.ToInt16(switchElement.Element("index").Value)
                };
                //add switch class to list array
                switchData.Add(data);
            }

            return switchData;
        }


        public List<Systems> GetSystem(string xml)
        {
            //make xml file off raw xml string
            XDocument xmlData = XDocument.Parse(xml);
            //create system array list
            List<Systems> systemData = new List<Systems>();
            //specify where data is located
            var systemElements = from systemElement in xmlData.Descendants("data")
                                 where systemElement.Attribute("group").Value == "System"
                                 select systemElement;
            //Take data and put into System class
            foreach (XElement systemElement in systemElements)
            {
                Systems data = new Systems()
                {
                    Description = systemElement.Element("desc").Value,
                    Value = systemElement.Element("value").Value
                };
                //add class to list array
                systemData.Add(data);

            }

            return systemData;

        }

        public SavedConnections[] LoadSaved()
        {
            try
            {
                SavedConnections[] sc = new SavedConnections[0];

                IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("saved.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream))
                {    //Visualize the text data in a TextBlock text
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        Array.Resize(ref sc, sc.Length + 1);
                        sc[i].Name = reader.ReadLine();
                        sc[i].Address = reader.ReadLine();
                        sc[i].ViewOnly = reader.ReadLine();
                        sc[i].Username = reader.ReadLine();
                        sc[i].Password = reader.ReadLine();
                        sc[i].RefreshTime = Convert.ToInt16(reader.ReadLine());
                        i++;
                    }
                    reader.Close();
                }

                return sc;
            }
            catch
            {
                return null;
            }

        }
    }
}
