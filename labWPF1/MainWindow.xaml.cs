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
using System.Windows.Shapes;

namespace labWPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickButtonWindow1 (object sender, RoutedEventArgs e)
        {
            WindowsTask1 windowsTask1 = new WindowsTask1();
            windowsTask1.Show();
        }
        private void ClickButtonWindow2(object sender, RoutedEventArgs e)
        {
            WindowTask4 windowsTask4 = new WindowTask4();
            windowsTask4.Show();
        }
        private void ClickButtonWindow3(object sender, RoutedEventArgs e)
        {
            WindowTask6 windowsTask6 = new WindowTask6();
            windowsTask6.Show();
        }
        private void ClickButtonConverter(object sender, RoutedEventArgs e)
        {
            UnitConverter unitConverter = new UnitConverter();
            unitConverter.Show();
        }
    }
}
