using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class Saved
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private bool viewOnly;

        public bool ViewOnly
        {
            get { return viewOnly; }
            set { viewOnly = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int refreshTime;

        public int RefreshTime
        {
            get { return refreshTime; }
            set { refreshTime = value; }
        }

    }
}
