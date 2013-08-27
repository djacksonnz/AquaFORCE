/*
 * Overview.cs
 * 
 * Author: David Jackson 2013
 * 
 * Class for holding overview items
 */
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
        string value;
        string shortname;
        int index;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        
        public string Shortname
        {
            get { return shortname; }
            set { shortname = value; }
        }
        
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

    }
}
