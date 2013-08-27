using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class Overview
    {
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        string shortname;

        public string Shortname
        {
            get { return shortname; }
            set { shortname = value; }
        }
        int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

    }
}
