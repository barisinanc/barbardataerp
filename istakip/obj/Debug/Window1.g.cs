﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8814D3D06D77C4D6E016473866295E1B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace istakip {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBox1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxAdSoyad;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxCepTel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxTel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonSearch;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label labelCariStatus;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonClear;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window1.xaml"
        internal Microsoft.Windows.Controls.DataGrid dataGrid1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonProductSelect;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid gridGallery;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/istakip;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\Window1.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxAdSoyad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.textBoxCepTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.textBoxTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.buttonSearch = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Window1.xaml"
            this.buttonSearch.Click += new System.Windows.RoutedEventHandler(this.buttonSearch_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.labelCariStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.buttonClear = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Window1.xaml"
            this.buttonClear.Click += new System.Windows.RoutedEventHandler(this.buttonClear_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.dataGrid1 = ((Microsoft.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.buttonProductSelect = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Window1.xaml"
            this.buttonProductSelect.Click += new System.Windows.RoutedEventHandler(this.buttonProductSelect_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.gridGallery = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
