﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;

namespace GeneralScreens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }

        private void bas()
        {
            BarisGorselDLL.Print print = new BarisGorselDLL.Print();
            //print.Dosya = new System.IO.FileInfo("c:\folder.gif");
            print.Adet = 1;
            print.Ebat = BarisGorselDLL.Print.CardSize.E10x15;
            print.KartTipi = BarisGorselDLL.Print.CardType.Parlak;
            BarisGorselDLL.Kullanici kull = new BarisGorselDLL.Kullanici();
            print.Personel = new BarisGorselDLL.Kullanici(1);//1=kullanıcı Id
            //print.Save(new System.IO.FileInfo("c:\\folder.gif"));
            List<BarisGorselDLL.Print> liste;// = print.GetList();
            //liste.First().Finished();
            liste = print.GetListFinished(10);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Run(new arsiv.Form1());
        }

        private void studyo_Click(object sender, RoutedEventArgs e)
        {
            istakip.ModulSiparis app = new istakip.ModulSiparis();
            app.Activate();
            app.Visibility = Visibility.Visible;
            this.Close();
        }
        private void openIsTakip() 
        {
            istakip.ModulSiparis istakipForm = new istakip.ModulSiparis();
            istakipForm.InitializeComponent();
            istakipForm.Show();
        }
        private void baski_Click(object sender, RoutedEventArgs e)
        {
            bas();
            //System.Windows.MessageBox.Show("Yapim Asamasinda:)");
        }
    }
}
