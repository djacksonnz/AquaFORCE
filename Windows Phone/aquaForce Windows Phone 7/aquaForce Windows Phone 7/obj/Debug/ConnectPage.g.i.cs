﻿#pragma checksum "E:\Developement\AquaFORCE\Windows Phone\aquaForce Windows Phone 7\aquaForce Windows Phone 7\ConnectPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9DB15014F3E5D9E65DC3BEF1139C7E1E"
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
    
    
    public partial class ConnectPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock connectText;
        
        internal System.Windows.Controls.TextBox addressInput;
        
        internal System.Windows.Controls.Button connect;
        
        internal System.Windows.Controls.CheckBox viewOnlyCheck;
        
        internal System.Windows.Controls.Grid viewOnlyGrid;
        
        internal System.Windows.Controls.TextBox usernameInput;
        
        internal System.Windows.Controls.PasswordBox passwordInput;
        
        internal System.Windows.Controls.TextBlock savedText;
        
        internal System.Windows.Controls.Button connect2;
        
        internal System.Windows.Controls.ListBox savedList;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/aquaFORCE;component/ConnectPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.connectText = ((System.Windows.Controls.TextBlock)(this.FindName("connectText")));
            this.addressInput = ((System.Windows.Controls.TextBox)(this.FindName("addressInput")));
            this.connect = ((System.Windows.Controls.Button)(this.FindName("connect")));
            this.viewOnlyCheck = ((System.Windows.Controls.CheckBox)(this.FindName("viewOnlyCheck")));
            this.viewOnlyGrid = ((System.Windows.Controls.Grid)(this.FindName("viewOnlyGrid")));
            this.usernameInput = ((System.Windows.Controls.TextBox)(this.FindName("usernameInput")));
            this.passwordInput = ((System.Windows.Controls.PasswordBox)(this.FindName("passwordInput")));
            this.savedText = ((System.Windows.Controls.TextBlock)(this.FindName("savedText")));
            this.connect2 = ((System.Windows.Controls.Button)(this.FindName("connect2")));
            this.savedList = ((System.Windows.Controls.ListBox)(this.FindName("savedList")));
        }
    }
}

