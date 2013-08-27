using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class Lighting
    {
        string description;
        int value;
        int index;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
