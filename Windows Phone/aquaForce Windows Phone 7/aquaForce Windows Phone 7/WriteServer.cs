using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO.IsolatedStorage;
using System.IO;


namespace aquaFORCE
{
    class WriteServer
    {
        ConnectionData connectionData = ConnectionData.Connection;

        public void WriteXML()
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("saved.txt", FileMode.Create, FileAccess.Write, isolatedStorage)))
            {
                for (int i = 0; i < connectionData.SavedConnections.Length; i++)
                {
                    writeFile.WriteLine(connectionData.SavedConnections[i].Name);
                    writeFile.WriteLine(connectionData.SavedConnections[i].Address);
                    writeFile.WriteLine(connectionData.SavedConnections[i].ViewOnly);
                    writeFile.WriteLine(connectionData.SavedConnections[i].Username);
                    writeFile.WriteLine(connectionData.SavedConnections[i].Password);
                    writeFile.WriteLine(connectionData.SavedConnections[i].RefreshTime.ToString());
                }
                writeFile.Close();
            }

        }
    }
}
