﻿#pragma checksum "E:\Developement\AquaForce\Windows Phone\aquaFORCE Windows Phone\aquaFORCE\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A4FD8965C782D78A3C86EBC38EAF2E5E"
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
    
    
    public partial class Settings : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock refBlock;
        
        internal System.Windows.Controls.Button increseRef;
        
        internal System.Windows.Controls.Button decreaseRef;
        
        internal System.Windows.Controls.Grid connectionGrid;
        
        internal System.Windows.Controls.TextBlock addressBlock;
        
        internal System.Windows.Controls.TextBlock modelBlock;
        
        internal System.Windows.Controls.TextBlock fwBlock;
        
        internal System.Windows.Controls.TextBlock serialBlock;
        
        internal System.Windows.Controls.TextBlock timeBlock;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/aquaFORCE;component/Settings.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.refBlock = ((System.Windows.Controls.TextBlock)(this.FindName("refBlock")));
            this.increseRef = ((System.Windows.Controls.Button)(this.FindName("increseRef")));
            this.decreaseRef = ((System.Windows.Controls.Button)(this.FindName("decreaseRef")));
            this.connectionGrid = ((System.Windows.Controls.Grid)(this.FindName("connectionGrid")));
            this.addressBlock = ((System.Windows.Controls.TextBlock)(this.FindName("addressBlock")));
            this.modelBlock = ((System.Windows.Controls.TextBlock)(this.FindName("modelBlock")));
            this.fwBlock = ((System.Windows.Controls.TextBlock)(this.FindName("fwBlock")));
            this.serialBlock = ((System.Windows.Controls.TextBlock)(this.FindName("serialBlock")));
            this.timeBlock = ((System.Windows.Controls.TextBlock)(this.FindName("timeBlock")));
        }
    }
}
