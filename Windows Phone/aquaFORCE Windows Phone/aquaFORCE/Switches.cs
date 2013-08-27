using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class Switches
    {
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        bool value;

        public bool Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
