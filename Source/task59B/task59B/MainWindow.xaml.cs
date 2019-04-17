using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task59B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point point;
        Ellipse ellipse;

        public MainWindow()
        {
            InitializeComponent();
            point = new Point();
            this.DataContext = point;

            #region ellipse

            ellipse = new Ellipse();
            ellipse.Width = 8;
            ellipse.Height = 8;
            canvasGraph.Children.Add(ellipse);

            #endregion
        }

        private void TextBoxX_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                point.X=double.Parse(textBoxX.Text.Replace('.', ','));
            }
            catch
            {
                textBoxX.Text = point.X.ToString();
            }
        }

        private void TextBoxY_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                point.Y = double.Parse(textBoxY.Text.Replace('.',','));
            }
            catch
            {
                textBoxY.Text = point.Y.ToString();
            }
        }

        private void ButtonCheckPoint_Click(object sender, RoutedEventArgs e)
        {
            if ((point.X <= 1 && point.X >= -1) && (point.Y <= 1 && point.Y >= -1))
                labelStatus.Content = "Принадлежит";
            else
            {
                labelStatus.Content = "Не принадлежит";
                ellipse.Fill=Brushes.Transparent;
            }
            if ((point.X <= 2 && point.X >= -2) && (point.Y <= 2 && point.Y >= -2))
                DrowPoint(point.X, point.Y);
        }
        public void DrowPoint(double x, double y)
        {
            int centrX = 150;
            int centrY = 150;

            ellipse.Fill = Brushes.Black;
            Canvas.SetLeft(ellipse, centrX + x*75-4);
            Canvas.SetBottom(ellipse, centrY + y*75-4);
        }
    }
}
