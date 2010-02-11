using System;
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
using System.Timers;
using System.IO;

namespace AutoFileDelete
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            path = Properties.Settings.Default.path;
            labelYol.Content = path;
            numericDays.Value = 3;
        }
        string path;
        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
                Properties.Settings.Default.path = path;
                Properties.Settings.Default.Save();
            }
        }
        Timer timer;

        private double day2milliseconds(double days)
        {
            return days * 24 * 60 * 60 * 1000;
        }
        double zaman;
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (!(path == "" || path == null))
            {
                timer = new Timer(30 * 60 * 1000);//yarım saat
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                zaman = numericDays.Value;
                timer.Enabled = true;
                buttonStart.IsEnabled = false;
                buttonStop.IsEnabled = true;
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (string x in Directory.GetFiles(path))
            {
                FileInfo fInfo= new FileInfo(x);
                DateTime bir = fInfo.LastWriteTime;
                DateTime iki = DateTime.Now.AddDays(-zaman);
                if (bir < iki)
                {
                    File.Delete(x);
                }
                fInfo = null;
            }
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.IsEnabled = true;
            buttonStop.IsEnabled = false;
            timer.Enabled = false;
        }
    }
}
