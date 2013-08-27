/*
 * LoadDisplay.cs
 * 
 * Author: David Jackson 2013
 * Used to load the UI items onto the screen when the methods are called
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;
using System.Windows.Controls;
using System.Windows;


namespace aquaFORCE
{
    class LoadDisplay
    {
        //TextBlock for overview pivot
        public TextBlock OverviewTextBlock(int margin, string description, string value)
        {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.Height = 50;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.VerticalAlignment = VerticalAlignment.Top;
            tb.Width = 456;
            tb.FontSize = 40;
            tb.Margin = new Thickness(0, margin, 0, 0);
            tb.Text = description + "     " + value;
            return tb;
        }

        //Switches for switch pivot
        public ToggleSwitch Switches(bool viewOnly, bool value, string description, int margin, string index)
        {
            ToggleSwitch ts = new ToggleSwitch();
            if (value)
            {
                ts.IsChecked = true;
            }
            else
            {
                ts.IsChecked = false;
            }
            ts.Header = description;
            ts.Tag = index;
            ts.Margin = new Thickness(0, margin, 0, 0);
            if (viewOnly)
                ts.IsEnabled = false;

            return ts;
        }

        //TextBlock for lighting pivot
        public TextBlock LightingTextBlock(int margin, string description, string value)
        {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.Height = 50;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.VerticalAlignment = VerticalAlignment.Top;
            tb.Width = 456;
            tb.FontSize = 40;
            tb.Margin = new Thickness(0, margin, 0, 0);
            tb.Text = description + "       " + value + "%";

            return tb;
        }

        //Slider for lighting pivot
        public Slider LightingSlider(int margin, int value, bool viewOnly, string index)
        {
            Slider si = new Slider();
            si.HorizontalAlignment = HorizontalAlignment.Left;
            si.Margin = new Thickness(0, margin + 50, 0, 0);
            si.VerticalAlignment = VerticalAlignment.Top;
            si.Width = 446;
            si.Value = value;
            si.Maximum = 100;
            si.Tag = index;
            if (viewOnly)
                si.IsEnabled = false;

            return si;
        }

        //Text for connection page for login
        public TextBlock ConnectText(int margin, string text)
        {
            var tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.Height = 30;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = text;
            tb.VerticalAlignment = VerticalAlignment.Top;
            tb.Width = 456;
            tb.Margin = new Thickness(0, margin, 0, 0);

            return tb;
        }

        //username input box
        public TextBox ConnectUsername()
        {
            TextBox tbx = new TextBox();
            tbx.Name = "usernameInput";
            tbx.Margin = new Thickness(0, 198, 0, 396);

            return tbx;
        }

        //password input box
        public PasswordBox ConnectPassword()
        {
            PasswordBox pwd = new PasswordBox();
            pwd.Name = "passwordInput";
            pwd.HorizontalAlignment = HorizontalAlignment.Left;
            pwd.Margin = new Thickness(0, 295, 0, 0);
            pwd.VerticalAlignment = VerticalAlignment.Top;
            pwd.Width = 456;
            pwd.Height = 66;

            return pwd;
        }
    }
}
