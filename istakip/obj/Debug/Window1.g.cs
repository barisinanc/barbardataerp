﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1269A6A8E49A3724AC71AF2182805B23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
        
        
        #line 9 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBox1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Window1.xaml"
        internal System.Windows.Controls.WrapPanel wrapPanelGallery;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Window1.xaml"
        internal System.Windows.Controls.Slider sliderSize;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxAdSoyad;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxCepTel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxTel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window1.xaml"
        internal System.Windows.Controls.Image imageSelected;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBlock textAciklama;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label labelFileName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonLeft;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonRight;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Window1.xaml"
        internal System.Windows.Controls.CheckBox imageFlag;
        
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
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\Window1.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.wrapPanelGallery = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 4:
            this.sliderSize = ((System.Windows.Controls.Slider)(target));
            
            #line 14 "..\..\Window1.xaml"
            this.sliderSize.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderSize_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBoxAdSoyad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.textBoxCepTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.textBoxTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.imageSelected = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.textAciklama = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.labelFileName = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.buttonLeft = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Window1.xaml"
            this.buttonLeft.Click += new System.Windows.RoutedEventHandler(this.buttonLeft_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.buttonRight = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Window1.xaml"
            this.buttonRight.Click += new System.Windows.RoutedEventHandler(this.buttonRight_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.imageFlag = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}