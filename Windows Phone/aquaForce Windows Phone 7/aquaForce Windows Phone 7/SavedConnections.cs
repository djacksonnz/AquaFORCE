using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aquaFORCE
{
    class SavedConnections
    {
        public SavedConnections(){ }
        private string name;
        private string address;
        private string username;
        private string password;
        private int refreshTime;
        private string viewOnly;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
       

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public int RefreshTime
        {
            get { return refreshTime; }
            set { refreshTime = value; }
        }
        

        public string ViewOnly
        {
            get { return viewOnly; }
            set { viewOnly = value; }
        }
    }
}
