using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace aquaFORCE
{
    public partial class ConnectPage : PhoneApplicationPage
    {
        ConnectionData connectionData = ConnectionData.Connection;

        WebClient client = new WebClient();

        string address;

        public ConnectPage()
        {
            InitializeComponent();

            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (new CorrectXML().CheckXML(e.Result))
                {
                    connectionData.Address = address;
                    if (viewOnlyCheck.IsChecked == true)
                    {
                        connectionData.ViewOnly = true;
                        
                    }
                    else
                    {
                        connectionData.Username = usernameInput.Text;
                        connectionData.Password = passwordInput.Password;
                    }
                    connectionData.RefreshTime = 60;
                    NavigationService.Navigate(new Uri("/DataView.xaml", UriKind.Relative));
                }
                else
                    ConnectError();
            }
            else
                ConnectError();

            connect.IsEnabled = true;
            connect2.IsEnabled = true;
        }

        private void ConnectError()
        {
            MessageBox.Show("Could not connect, please check your address and try again!");
        }

        private void ConnectToServer(object sender, System.Windows.Input.GestureEventArgs e)
        {
            address = new CheckAddress().CheckAddressName(addressInput.Text);
            addressInput.Text = address;
            client.DownloadStringAsync(new Uri(address));
            connect.IsEnabled = false;
            connect2.IsEnabled = false;
        }

        private void ViewChecked(object sender, RoutedEventArgs e)
        {
            viewOnlyGrid.Children.Clear();
        }

        private void ViewUnchecked(object sender, RoutedEventArgs e)
        {   
            var tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.Height = 30;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = "Username";
            tb.VerticalAlignment = VerticalAlignment.Top;
            tb.Width = 456;
            tb.Margin = new Thickness(0, 168, 0, 0);

            viewOnlyGrid.Children.Add(tb);

            tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.Height = 30;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = "Password";
            tb.VerticalAlignment = VerticalAlignment.Top;
            tb.Width = 456;
            tb.Margin = new Thickness(0, 260, 0, 0);

            viewOnlyGrid.Children.Add(tb);

            TextBox tbx = new TextBox();
            tbx.Name = "usernameInput";
            tbx.Margin = new Thickness(0, 198, 0, 396);

            viewOnlyGrid.Children.Add(tbx);

            PasswordBox pwd = new PasswordBox();
            pwd.Name = "passwordInput";
            pwd.HorizontalAlignment = HorizontalAlignment.Left;
            pwd.Margin = new Thickness(0, 295, 0, 0);
            pwd.VerticalAlignment = VerticalAlignment.Top;
            pwd.Width = 456;
            pwd.Height = 66;

            viewOnlyGrid.Children.Add(pwd);



        }

        private void NewConnection(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewSaved.xaml", UriKind.Relative));
        }
    }
}