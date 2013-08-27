/*
 * ConnectPage.xaml.cs
 * 
 * Author: David Jackson 2013
 * 
 * Class controls main page connecting to aquarium computer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;


namespace aquaFORCE
{
    public partial class ConnectPage : PhoneApplicationPage
    {
        ConnectionData connectionData = ConnectionData.Connection;

        WebClient xmlClient = new WebClient();

        WebClient loginClient = new WebClient();

        string address;

        //program initialisation
        public ConnectPage()
        {
            InitializeComponent();
            //set the username and pw and address (local testing)
            addressInput.Text = "skaggully.com/ghl";
            usernameInput.Text = "Admin";
            passwordInput.Password = "1234";
            //viewOnlyCheck.IsChecked = true;
            connectionData.SavedConnections = new ParseXML().LoadSaved();
            PopulateServerList();
            //set the location for the webclient requests to go
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(XmlClient_DownloadStringCompleted);
            loginClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(LoginClient_DownloadStringCompleted);
        }

        public void PopulateServerList()
        {
            connectionData.SavedConnections = new ParseXML().LoadSaved();
            try
            {
                for (int i = 0; i < connectionData.SavedConnections.Length; i++)
                {
                    savedList.Items.Add(connectionData.SavedConnections[i].Name);
                }
            }
            catch
            {
            }
        }

        //read result of login
        void LoginClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //check for valid login
            System.Diagnostics.Debug.WriteLine(e.ToString());
            if (e.Result == "2")
            {
                //set app wide variables through ConnectionData class   
                connectionData.Username = usernameInput.Text;
                connectionData.Password = passwordInput.Password;
                connectionData.RefreshTime = 60;
                //move to Data scree
                NavigationService.Navigate(new Uri("/DataView.xaml", UriKind.Relative));
            }
            //throw user error if incorrect
            else
            {
                MessageBox.Show("Username and/or Password are incorrect, please check these, or check view only");
            }
        }

        //read result of xml download
        void XmlClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //if there is no error check for valid xml
            if (e.Error == null)
            {
                if (new CorrectXML().CheckXML(e.Result))
                {
                    //set app wide xml address
                    connectionData.XmlAddress = address;
                    //work out where the /xml.xml is and get a general address and save to app wide class
                    int xmlStart = connectionData.XmlAddress.LastIndexOf("/");
                    connectionData.Address = connectionData.XmlAddress.Substring(0, xmlStart + 1);
                    //check to see if we should login
                    if (viewOnlyCheck.IsChecked == true)
                    {
                        //if true set app wide vars to be read only
                        connectionData.ViewOnly = true;
                        connectionData.RefreshTime = 60;
                        //move to data view
                        NavigationService.Navigate(new Uri("/DataView.xaml", UriKind.Relative));
                    }
                    else
                    {
                        //check to see whether there isnt an empty input field
                        if (usernameInput.Text == "" || passwordInput.Password == "")
                        {
                            //message if its empty
                            MessageBox.Show("Username and/or Password are empty, please check these, or check view only.");
                        }
                        else
                        {
                            //send login command
                            loginClient.DownloadStringAsync(new Uri(connectionData.Address + "security.php?action=login&name=" + usernameInput.Text + "&pass=" + passwordInput.Password));
                        }
                    }
                }
                else
                    ConnectError();
            }
            else
                ConnectError();

            //set buttons active again
            connect.IsEnabled = true;
            connect2.IsEnabled = true;
        }

        //general bad connection error
        private void ConnectError()
        {
            MessageBox.Show("Could not connect, please check your address and try again!");
        }

        private void ConnectToServer(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (addressInput.Text == "")
            {    
                MessageBox.Show("Please enter an address.");
            }
            else
            {
                address = new CheckAddress().CheckAddressName(addressInput.Text);
                addressInput.Text = address;
                xmlClient.DownloadStringAsync(new Uri(address));
                connect.IsEnabled = false;
                connect2.IsEnabled = false;
            }
        }

        //clears the ui when read only is checked
        private void ViewChecked(object sender, RoutedEventArgs e)
        {
            viewOnlyGrid.Children.Clear();
        }
        //populate ui when readonly is unchecked
        private void ViewUnchecked(object sender, RoutedEventArgs e)
        {   
            viewOnlyGrid.Children.Add(new LoadDisplay().ConnectText(168,"Username"));

            viewOnlyGrid.Children.Add(new LoadDisplay().ConnectText(260,"Password"));

            viewOnlyGrid.Children.Add(new LoadDisplay().ConnectUsername());

            viewOnlyGrid.Children.Add(new LoadDisplay().ConnectPassword());
        }

        //opens page to save a connection(not implemented)
        private void NewConnection(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewSaved.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PopulateServerList();
        }
    }
}