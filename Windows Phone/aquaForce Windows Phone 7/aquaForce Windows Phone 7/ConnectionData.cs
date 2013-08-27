using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace aquaFORCE
{
    class ConnectionData
    {
        
        private string xmlAddress;
        static private ConnectionData connection;
        private string address;
        private bool viewOnly;
        private string username;
        private int refreshTime;
        private string password;
        SavedConnections[] savedConnections = new SavedConnections[0];

        internal SavedConnections[] SavedConnections
        {
            get { return savedConnections; }
            set { savedConnections = value; }
        }

        private ConnectionData() { }

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

        public string XmlAddress
        {
            get { return xmlAddress; }
            set { xmlAddress = value; }
        }

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
