/*
 * DataView.xaml.cs
 * 
 * Author: David Jackson 2013
 * 
 * Class controls main page of downloading and displaying data
 */
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
using System.IO;
using System.Text;

namespace aquaFORCE
{
    public partial class DataView : PhoneApplicationPage
    {
        DispatcherTimer timer;

        ConnectionData connectionData = ConnectionData.Connection;

        WebClient xmlDownload = new WebClient();

        string xmlData;

        SensorData sensorData = SensorData.Data;

        ToggleSwitch[] switches = new ToggleSwitch[0];

        int[] controllerSwitchCodeIndex = new int[65];

        int index;
        int state;

        //inital page load
        public DataView()
        {
            InitializeComponent();
            //start new timer
            timer = new DispatcherTimer();
            //set timer interval
            TimerInterval();
            //handle where to go on timer tick
            timer.Tick += new EventHandler(timer_Tick);
            //handle where to go on xml download
            xmlDownload.DownloadStringCompleted += new DownloadStringCompletedEventHandler(XmlDownload_DownloadStringCompleted);
        }

        //set timer interval
        private void TimerInterval()
        {
            timer.Interval = TimeSpan.FromSeconds(connectionData.RefreshTime);
        }

        //handle timer ticks
        void timer_Tick(object sender, EventArgs e)
        {
            //redownload xml from server
            xmlDownload.DownloadStringAsync(new Uri(connectionData.XmlAddress));
        }

        //loads overview ui
        private void LoadOverview()
        {
            //set inital margin as 0
            int margin = 0;
            //cycle through all overview items
            for (int i = 0; i < sensorData.OverviewItems.Count(); i++)
            {
                //add overview items to ui
                overviewGrid.Children.Add(new LoadDisplay().OverviewTextBlock(margin, sensorData.OverviewItems[i].
                    Description, sensorData.OverviewItems[i].Value));
                //increment margin
                margin += 90;
            }
        }

        //loads switches ui
        private void LoadSwitches()
        {
            //set inital margin as 0
            int margin = 0;
            //Cycle through all switches
            for (int i = 0; i < sensorData.SwitchItems.Count(); i++)
            {
                //create toggleswitch using LoadDisplay class
                ToggleSwitch ts = new LoadDisplay().Switches(connectionData.ViewOnly,
                    sensorData.SwitchItems[i].Value, sensorData.SwitchItems[i].Description, margin, sensorData.SwitchItems[i].Index.ToString());
                //temp names for display
                if (ts.Header.Equals("S 1"))
                {
                    ts.Header = "Return Pump";
                }
                else if (ts.Header.Equals("S 2"))
                {
                    ts.Header = "Refugium Lights";
                }
                else if (ts.Header.Equals("S 3"))
                {
                    ts.Header = "Skimmer";
                }
                else if (ts.Header.Equals("S12"))
                {
                    ts.Header = "Right Tunze";
                }
                else if (ts.Header.Equals("S11"))
                {
                    ts.Header = "Left Radion";
                }
                else if (ts.Header.Equals("S10"))
                {
                    ts.Header = "Right Radion";
                }
                //Handle switch clicks
                ts.Click += new EventHandler<RoutedEventArgs>(UpdateSwitch);
                //add to ui
                switchGrid.Children.Add(ts);
                //increment margins
                margin += 90;
            }
        }

        //handing switch click
        void UpdateSwitch(object sender, RoutedEventArgs e)
        {
            //make a toggleswitch from sent data
            ToggleSwitch ts = (ToggleSwitch)sender;
            //record its index value
            index = Convert.ToInt16(ts.Tag);
            //ask for confirmation
            MessageBoxResult r = MessageBox.Show("Are you sure you want to do this?", "Change Value", MessageBoxButton.OKCancel);
            //do work if confirmation is yes
            if (r == MessageBoxResult.OK)
            {
                //check for wanted new state
                if (ts.IsChecked == true)
                    state = 1;
                else
                    state = 0;

                //send Login to server
                System.Uri myUri = new Uri(connectionData.Address + "security?action=login&name=" + connectionData.Username + "&pass=" + connectionData.Password);
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallbackLogin), myRequest);
            }
            //un do change if no
            else
            {
                ts.IsChecked = !ts.IsChecked;
            }
        }

        //Handles login stream
        void GetRequestStreamCallbackLogin(IAsyncResult callbackResult)
        {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
            // End the stream request operation
            Stream postStream = myRequest.EndGetRequestStream(callbackResult);

            //Create the post data
            string postData = "";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Add the post data to the web request
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

             //Start the web request
            myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallbackLogin), myRequest);
        }

        //handles login response
        void GetResponsetStreamCallbackLogin(IAsyncResult callbackResult)
        {
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            string result;
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                result = httpWebStreamReader.ReadToEnd();
                //For debug: show results
                System.Diagnostics.Debug.WriteLine(result);
            }

            //if its authenticated move on
            if (result == "2")
            {
                System.Uri myUri = new Uri(connectionData.Address + "communication.php?dir=sel&code=" + controllerSwitchCodeIndex[index] + "&data=" + state.ToString() + "&count=0.1");
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallbackUpdateSwitch), myRequest);
            }
            //if not authenticated error
            else
            {
                Error();
            }

        }

        //Connection error
        private void Error()
        {
            MessageBox.Show("Could not validate connection.");
        }

        //Handles switch update http stream
        void GetRequestStreamCallbackUpdateSwitch(IAsyncResult callbackResult)
        {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
            // End the stream request operation
            Stream postStream = myRequest.EndGetRequestStream(callbackResult);

            //Create the post data
            string postData = "";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Add the post data to the web request
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

             //Start the web request
            myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallbackUpdateSwitch), myRequest);
        }

        //handles the switch update response
        void GetResponsetStreamCallbackUpdateSwitch(IAsyncResult callbackResult)
        {
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            string result;
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                result = httpWebStreamReader.ReadToEnd();
                //For debug: show results
                System.Diagnostics.Debug.WriteLine(result);
            }

            //Check it was acknologed
            if (!(result == "code=" + controllerSwitchCodeIndex[index] + "&data=ACK"))
            {
                MessageBox.Show("Could not update value, please try again.");
            }
            //ReloadUI(new object sender, new EventArgs e);
        }

        //Loads lighting into ui
        private void LoadLighting()
        {
            //inital setting of the margin at 0
            int margin = 0;
            //cycle through all of the light items
            for (int i = 0; i < sensorData.LightingItems.Count(); i++)
            {
                //add text to ui
                lightingGrid.Children.Add(new LoadDisplay().LightingTextBlock(margin,
                    sensorData.LightingItems[i].Description, sensorData.LightingItems[i].Value.ToString()));

                //create a slider component
                Slider si = new LoadDisplay().LightingSlider(
                    margin, sensorData.LightingItems[i].Value, connectionData.ViewOnly, sensorData.LightingItems[i].Index.ToString());

                //control what happens when the value is changed
                si.ValueChanged += SliderValueChange;
                //add control to ui
                lightingGrid.Children.Add(si);
                //increment margin
                margin += 134;
            }
        }

        //generates all possible switch codes, code c/o Daniel
        private void generateControllerSwitchCodeIndexes()
        {
            int intOffset = 0;
            for (int i = 0; i < 65; i++)
            {
                if (i % 24 == 0 && i != 0)
                {
                    intOffset = intOffset + 1000;
                }
                controllerSwitchCodeIndex[i] = 10100 + i % 24 * 1 + intOffset;
            }
        }

        //does stuff when slider is changed (to implement)
        void SliderValueChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider si = (Slider)sender;
            double newValue = e.NewValue;
        }

        //clears the ui
        private void ClearGrids()
        {
            overviewGrid.Children.Clear();
            lightingGrid.Children.Clear();
            switchGrid.Children.Clear();
        }

        //main method for populating ui
        private void UpdateDisplay()
        {
            sensorData.PopulateLists(xmlData);
            ClearGrids();
            LoadLighting();
            LoadOverview();
            LoadSwitches();
        }

        //handled when xml code is downloaded
        void XmlDownload_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //if there was no error get result and update ui
            if (e.Error == null)
            {
                xmlData = e.Result;
                UpdateDisplay();
            }
            else
                MessageBox.Show("Could not connect, please check your address and try again!");
        }
        
        //controls when the page is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //start ui reload timer and set interval
            this.timer.Start();
            TimerInterval();
            //generate switch codes
            generateControllerSwitchCodeIndexes();
            //download xml
            xmlDownload.DownloadStringAsync(new Uri(connectionData.XmlAddress));
        }

        //reload ui on button press
        private void ReloadUI(object sender, EventArgs e)
        {
            //download xml
            xmlDownload.DownloadStringAsync(new Uri(connectionData.XmlAddress));
        }

        //navigates to settings page on click
        private void GotoSettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}