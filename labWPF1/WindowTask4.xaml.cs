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
    /// Interaction logic for WindowTask4.xaml
    /// </summary>
    public partial class WindowTask4 : Window
    {
        public WindowTask4()
        {
            InitializeComponent();
        }

        private void B1(object sender, RoutedEventArgs e)
        {
            if(Button1.Visibility == Visibility.Visible) Button1.Visibility = Visibility.Collapsed;
            else Button1.Visibility = Visibility.Visible;
            if (Button3.Visibility == Visibility.Visible) Button3.Visibility = Visibility.Collapsed;
            else Button3.Visibility = Visibility.Visible;
            if (Button4.Visibility == Visibility.Visible) Button4.Visibility = Visibility.Collapsed;
            else Button4.Visibility = Visibility.Visible;

            if (Button1.Visibility == Visibility.Collapsed
                && Button2.Visibility == Visibility.Collapsed
                && Button3.Visibility == Visibility.Collapsed
                && Button4.Visibility == Visibility.Collapsed
                && Button5.Visibility == Visibility.Collapsed) VictoryLabel.Visibility = Visibility.Visible;
        }
        private void B2(object sender, RoutedEventArgs e)
        {
            if (Button2.Visibility == Visibility.Visible) Button2.Visibility = Visibility.Collapsed;
            else Button2.Visibility = Visibility.Visible;
            if (Button5.Visibility == Visibility.Visible) Button5.Visibility = Visibility.Collapsed;
            else Button5.Visibility = Visibility.Visible;
            if (Button1.Visibility == Visibility.Visible) Button1.Visibility = Visibility.Collapsed;
            else Button1.Visibility = Visibility.Visible;

            if (Button1.Visibility == Visibility.Collapsed
                && Button2.Visibility == Visibility.Collapsed
                && Button3.Visibility == Visibility.Collapsed
                && Button4.Visibility == Visibility.Collapsed
                && Button5.Visibility == Visibility.Collapsed) VictoryLabel.Visibility = Visibility.Visible;
        }
        private void B3(object sender, RoutedEventArgs e)
        {
            if (Button3.Visibility == Visibility.Visible) Button3.Visibility = Visibility.Collapsed;
            else Button3.Visibility = Visibility.Visible;
            if (Button5.Visibility == Visibility.Visible) Button5.Visibility = Visibility.Collapsed;
            else Button5.Visibility = Visibility.Visible;

            if (Button1.Visibility == Visibility.Collapsed
                && Button2.Visibility == Visibility.Collapsed
                && Button3.Visibility == Visibility.Collapsed
                && Button4.Visibility == Visibility.Collapsed
                && Button5.Visibility == Visibility.Collapsed) VictoryLabel.Visibility = Visibility.Visible;
        }
        private void B4(object sender, RoutedEventArgs e)
        {
            if (Button4.Visibility == Visibility.Visible) Button4.Visibility = Visibility.Collapsed;
            else Button4.Visibility = Visibility.Visible;
            if (Button2.Visibility == Visibility.Visible) Button2.Visibility = Visibility.Collapsed;
            else Button2.Visibility = Visibility.Visible;

            if (Button1.Visibility == Visibility.Collapsed
                && Button2.Visibility == Visibility.Collapsed
                && Button3.Visibility == Visibility.Collapsed
                && Button4.Visibility == Visibility.Collapsed
                && Button5.Visibility == Visibility.Collapsed) VictoryLabel.Visibility = Visibility.Visible;
        }
        private void B5(object sender, RoutedEventArgs e)
        {
            if (Button1.Visibility == Visibility.Visible) Button1.Visibility = Visibility.Collapsed;
            else Button1.Visibility = Visibility.Visible;
            if (Button3.Visibility == Visibility.Visible) Button3.Visibility = Visibility.Collapsed;
            else Button3.Visibility = Visibility.Visible;
            if (Button5.Visibility == Visibility.Visible) Button5.Visibility = Visibility.Collapsed;
            else Button5.Visibility = Visibility.Visible;

            if (Button1.Visibility == Visibility.Collapsed
                && Button2.Visibility == Visibility.Collapsed
                && Button3.Visibility == Visibility.Collapsed
                && Button4.Visibility == Visibility.Collapsed
                && Button5.Visibility == Visibility.Collapsed) VictoryLabel.Visibility = Visibility.Visible;
        }
    }
}
