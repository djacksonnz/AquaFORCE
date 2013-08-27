using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class SensorData
    {
        List<Lighting> lightingItems = new List<Lighting>();

        internal List<Lighting> LightingItems
        {
            get { return lightingItems; }
            set { lightingItems = value; }
        }
        List<Overview> overviewItems = new List<Overview>();

        internal List<Overview> OverviewItems
        {
            get { return overviewItems; }
            set { overviewItems = value; }
        }
        List<Switches> switchItems = new List<Switches>();

        internal List<Switches> SwitchItems
        {
            get { return switchItems; }
            set { switchItems = value; }
        }
        List<Systems> systemItems = new List<Systems>();

        internal List<Systems> SystemItems
        {
            get { return systemItems; }
            set { systemItems = value; }
        }


        private SensorData() { }

        static private SensorData data;

        static public SensorData Data
        {
            get
            {
                if (data == null)
                {
                    data = new SensorData();
                }
                return data;
            }
        }

        public void PopulateLists(string rawXML)
        {
            lightingItems = new ParseXML().GetLighting(rawXML);
            overviewItems = new ParseXML().GetOverview(rawXML);
            switchItems = new ParseXML().GetSwitches(rawXML);
            systemItems = new ParseXML().GetSystem(rawXML);
        }
            
    }
}
