using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace aquaFORCE
{
    public partial class DataView : PhoneApplicationPage
    {
        DispatcherTimer timer;

        ConnectionData connectionData = ConnectionData.Connection;

        WebClient client = new WebClient();

        string xmlData;

        SensorData sensorData = SensorData.Data;

        public DataView()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            TimerInterval();
            timer.Tick += new EventHandler(timer_Tick);

            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        }

        private void TimerInterval()
        {
            timer.Interval = TimeSpan.FromSeconds(connectionData.RefreshTime);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            client.DownloadStringAsync(new Uri(connectionData.Address));
        }

        private void LoadOverview()
        {
            int margin = 0;
            for (int i = 0; i < sensorData.OverviewItems.Count(); i++)
            {
                overviewGrid.Children.Add(new LoadDisplay().OverviewTextBlock(margin,sensorData.OverviewItems[i].
                    Description,sensorData.OverviewItems[i].Value));
                margin += 90;
            }
        }

        private void LoadSwitches()
        {
            int margin = 0;
            for (int i = 0; i < sensorData.SwitchItems.Count(); i++)
            {
                switchGrid.Children.Add(new LoadDisplay().Switches(connectionData.ViewOnly,
                    sensorData.SwitchItems[i].Value, sensorData.SwitchItems[i].Description, margin));
                margin += 90;
            }
        }

        private void LoadLighting()
        {
            int margin = 0;
            for (int i = 0; i < sensorData.LightingItems.Count(); i++)
            {
                lightingGrid.Children.Add(new LoadDisplay().LightingTextBlock(margin,
                    sensorData.LightingItems[i].Description, sensorData.LightingItems[i].Value.ToString()));

                lightingGrid.Children.Add(new LoadDisplay().LightingSlider(
                    margin, sensorData.LightingItems[i].Value, connectionData.ViewOnly));

                margin += 134;
            }
        }

        private void ClearGrids()
        {
            overviewGrid.Children.Clear();
            lightingGrid.Children.Clear();
            switchGrid.Children.Clear();
        }

        private void UpdateDisplay()
        {
            sensorData.PopulateLists(xmlData);
            ClearGrids();
            LoadLighting();
            LoadOverview();
            LoadSwitches();
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                xmlData = e.Result;
                UpdateDisplay();
            }
            else
                MessageBox.Show("Could not connect, please check your address and try again!");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.timer.Start();
            TimerInterval();
            client.DownloadStringAsync(new Uri(connectionData.Address));
        }

        private void ReloadUI(object sender, EventArgs e)
        {
            client.DownloadStringAsync(new Uri(connectionData.Address));
        }

        private void GotoSettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml",UriKind.Relative));
        }
    }
}