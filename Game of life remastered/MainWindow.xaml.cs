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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_of_life_remastered
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();

            Root fullTree = new Root(8, 8);

            fullTree.addPixel(1, 1);
            fullTree.addPixel(1, 2);

            fullTree.removePixel(1, 2);

            if (!fullTree.isPixelAlive(1, 2))
            {

                MessageBox.Show("1");

            }

            if (fullTree.isPixelAlive(1, 1))
            {

                MessageBox.Show("2");

            }

        }

        private void AddPixel(double x, double y)
        {

            Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y * 4);
            Canvas.SetLeft(rec, x * 4);
            rec.Width = 4;
            rec.Height = 4;
            rec.Fill = new SolidColorBrush(Colors.White);
            pixelCanvas.Children.Add(rec);

        }

    }

}
