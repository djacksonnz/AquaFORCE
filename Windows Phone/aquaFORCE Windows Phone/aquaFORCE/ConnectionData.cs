using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquaFORCE
{
    class ConnectionData
    {
        private ConnectionData() { }

        static private ConnectionData connection;

        static public ConnectionData Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new ConnectionData();
                }
                return connection;
            }
        }

        private string address;

        private bool viewOnly;

        private string username;

        private int refreshTime;

        public int RefreshTime
        {
            get { return refreshTime; }
            set { refreshTime = value; }
        }

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

        public bool ViewOnly
        {
            get { return viewOnly; }
            set { viewOnly = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
