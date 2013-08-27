using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace aquaFORCE
{
    public partial class NewSaved : PhoneApplicationPage
    {
        ConnectionData connectionData = ConnectionData.Connection;

        public NewSaved()
        {
            InitializeComponent();
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
            tb.Margin = new Thickness(0, 270, 0, 0);

            viewOnlyGrid.Children.Add(tb);

            tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.Height = 30;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = "Password";
            tb.VerticalAlignment = VerticalAlignment.Top;
            tb.Width = 456;
            tb.Margin = new Thickness(0,369, 0, 0);

            viewOnlyGrid.Children.Add(tb);

            TextBox tbx = new TextBox();
            tbx.Name = "usernameInput";
            tbx.Margin = new Thickness(0, 297, 0, 0);
            tbx.Height = 72;

            viewOnlyGrid.Children.Add(tbx);

            PasswordBox pwd = new PasswordBox();
            pwd.Name = "passwordInput";
            pwd.HorizontalAlignment = HorizontalAlignment.Left;
            pwd.Margin = new Thickness(0, 391, 0, 0);
            pwd.VerticalAlignment = VerticalAlignment.Top;
            pwd.Width = 456;
            pwd.Height = 66;

            viewOnlyGrid.Children.Add(pwd);



        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SavedConnections[] scb;
            if (connectionData.SavedConnections == null)
            {
                scb = new SavedConnections[1];
            }
            else
            {
  
                scb = connectionData.SavedConnections;
                Array.Resize(ref scb, scb.Length + 1);
            }
            SavedConnections sc = new SavedConnections();
            sc.Name = nameInput.Text;
            sc.Address = addressInput.Text;
            sc.Password = passwordInput.Password;
            sc.Username = usernameInput.Text;
            if (viewCheck.IsChecked == true)
            {
                sc.ViewOnly = "yes";
            }
            else
            {
                sc.ViewOnly = "no";
            }
            scb[scb.Length - 1] = sc;
            connectionData.SavedConnections = scb;

            new WriteServer().WriteXML();

            NavigationService.GoBack();
        }

    }
}