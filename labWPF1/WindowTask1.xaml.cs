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

namespace labWPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowsTask1 : Window
    {
        public WindowsTask1()
        {
            InitializeComponent();
        }

        private void ClickButtonHello(object sender, RoutedEventArgs e)
        {
            LabelTask1.Content = "Hello";
        }
        private void ClickButtonGoodbye(object sender, RoutedEventArgs e)
        {
            LabelTask1.Content = "Goodbye";
        }
        private void ClickButtonHide2(object sender, RoutedEventArgs e)
        {
            TextBlockTask2.Visibility = Visibility.Collapsed;
        }
        private void ClickButtonShow2(object sender, RoutedEventArgs e)
        {
            TextBlockTask2.Visibility = Visibility.Visible;
        }
        private void ClickButtonHide3(object sender, RoutedEventArgs e)
        {
            TextBoxTask3.Visibility = Visibility.Collapsed;
        }
        private void ClickButtonShow3(object sender, RoutedEventArgs e)
        {
            TextBoxTask3.Visibility = Visibility.Visible;
        }
        private void ClickButtonClear3(object sender, RoutedEventArgs e)
        {
            TextBoxTask3.Text = "";
        }
    }
}