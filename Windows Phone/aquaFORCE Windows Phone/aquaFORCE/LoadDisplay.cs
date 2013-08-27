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

        public ToggleSwitch Switches(bool viewOnly, bool value, string description, int margin)
        {
            ToggleSwitch ts = new ToggleSwitch();
            if (value)
            {
                ts.Content = "On";
                ts.IsChecked = true;
            }
            else
            {
                ts.Content = "Off";
                ts.IsChecked = false;
            }
            ts.Header = description;
            ts.Margin = new Thickness(0, margin, 0, 0);
            if (viewOnly)
                ts.IsEnabled = false;

            return ts;
        }

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

        public Slider LightingSlider(int margin, int value, bool viewOnly)
        {
            Slider si = new Slider();
            si.HorizontalAlignment = HorizontalAlignment.Left;
            si.Margin = new Thickness(0, margin + 50, 0, 0);
            si.VerticalAlignment = VerticalAlignment.Top;
            si.Width = 446;
            si.Value = value;
            si.Maximum = 100;
            if (viewOnly)
                si.IsEnabled = false;

            return si;
        }
    }
}
