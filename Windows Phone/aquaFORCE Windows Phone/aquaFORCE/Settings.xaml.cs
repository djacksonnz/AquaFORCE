using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace aquaFORCE
{
    public partial class Settings : PhoneApplicationPage
    {
        SensorData sensorData = SensorData.Data;

        ConnectionData connectionData = ConnectionData.Connection;

        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            addressBlock.Text = connectionData.Address;

            for (int i = 0; i < sensorData.SystemItems.Count(); i++)
            {
                switch (sensorData.SystemItems[i].Description)
                {
                    case "Model":
                        modelBlock.Text = sensorData.SystemItems[i].Value;
                        break;
                    case "Firmware V#":
                        fwBlock.Text = sensorData.SystemItems[i].Value;
                        break;
                    case "Serial #":
                        serialBlock.Text = sensorData.SystemItems[i].Value;
                        break;
                    case "Time":
                        timeBlock.Text = sensorData.SystemItems[i].Value;
                        break;
                }
                refBlock.Text = connectionData.RefreshTime.ToString();
            }
        }

        private void increseRef_Click(object sender, RoutedEventArgs e)
        {
            if (!(connectionData.RefreshTime >= 120))
            {
                connectionData.RefreshTime++;
                refBlock.Text = connectionData.RefreshTime.ToString();
            }
        }

        private void decreaseRef_Click(object sender, RoutedEventArgs e)
        {
            if (!(connectionData.RefreshTime <= 10))
            {
                connectionData.RefreshTime--;
                refBlock.Text = connectionData.RefreshTime.ToString();
            }
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.aquaforce.co.nz", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "Windows Phone App";
            emailComposeTask.To = "support@aquaforce.co.nz";

            emailComposeTask.Show();
        }
    }
}