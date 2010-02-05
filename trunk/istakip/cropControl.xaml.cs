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

namespace istakip
{
    /// <summary>
    /// Interaction logic for cropControl.xaml
    /// </summary>
    public partial class cropControl : UserControl
    {
        public cropControl()
        {
            InitializeComponent();
            mainGrid.MouseDown += new MouseButtonEventHandler(mainGrid_MouseDown);
            mainGrid.MouseUp += new MouseButtonEventHandler(mainGrid_MouseUp);
            doldur();
        }

        private void doldur()
        {
            group.FillRule = FillRule.EvenOdd;

            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush = Brushes.Black;
            myPath.Fill = mySolidColorBrush;
            myPath.Opacity = 0.5;

            area.Rect = new Rect();
            group.Children.Add(dis);
            group.Children.Add(area);
            myPath.Data = group;
            
        }

        void mainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mainGrid.MouseMove -= new MouseEventHandler(mainGrid_MouseMove);
            if (!IsSelected)
            { IsSelected = true; }
        }
        RectangleGeometry area = new RectangleGeometry();
        Path myPath = new Path();
        GeometryGroup group = new GeometryGroup();
        RectangleGeometry dis = new RectangleGeometry(new Rect(0, 0, 300, 300));
        Point start;

        bool IsSelected = false;
        void mainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            start = e.GetPosition(this);
            if (!IsSelected)
            {
                area.Rect = new Rect(start, start);
                mainGrid.Children.Add(myPath);
                
            }
            else
            {
                if ((e.GetPosition(this).X > area.Rect.TopLeft.X && e.GetPosition(this).X < area.Rect.TopRight.X)
                    &&
                    (e.GetPosition(this).Y > area.Rect.TopLeft.Y && e.GetPosition(this).Y < area.Rect.BottomLeft.Y)
                    )
                {
                    IsMove = true;
                }
            }
            mainGrid.MouseMove += new MouseEventHandler(mainGrid_MouseMove);
        }

        bool IsMove = false;

        void mainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsSelected)
            {
                area.Rect = new Rect(start, e.GetPosition(this));
            }
            else
            {
                if (IsMove)
                {
                    Rect rect = new Rect();
                    rect = area.Rect;
                    rect.X += e.GetPosition(this).X - start.X;
                    rect.Y += e.GetPosition(this).Y - start.Y;
                    area.Rect = rect;
                }

            }
        }
    }
}
