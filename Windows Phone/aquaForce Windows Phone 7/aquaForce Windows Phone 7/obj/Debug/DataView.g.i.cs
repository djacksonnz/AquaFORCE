﻿#pragma checksum "E:\Developement\AquaFORCE\Windows Phone\aquaForce Windows Phone 7\aquaForce Windows Phone 7\DataView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81E9DF757E74B6D863ECAACECF7A2D75"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace aquaFORCE {
    
    
    public partial class DataView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock overviewHeader;
        
        internal System.Windows.Controls.Grid overviewGrid;
        
        internal System.Windows.Controls.TextBlock switchesHeader;
        
        internal System.Windows.Controls.Grid switchGrid;
        
        internal System.Windows.Controls.TextBlock lightingHeader;
        
        internal System.Windows.Controls.Grid lightingGrid;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/aquaFORCE;component/DataView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.overviewHeader = ((System.Windows.Controls.TextBlock)(this.FindName("overviewHeader")));
            this.overviewGrid = ((System.Windows.Controls.Grid)(this.FindName("overviewGrid")));
            this.switchesHeader = ((System.Windows.Controls.TextBlock)(this.FindName("switchesHeader")));
            this.switchGrid = ((System.Windows.Controls.Grid)(this.FindName("switchGrid")));
            this.lightingHeader = ((System.Windows.Controls.TextBlock)(this.FindName("lightingHeader")));
            this.lightingGrid = ((System.Windows.Controls.Grid)(this.FindName("lightingGrid")));
        }
    }
}

