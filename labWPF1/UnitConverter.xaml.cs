using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UnitConverter.xaml
    /// </summary>
    public partial class UnitConverter : Window
    {
        public UnitConverter()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CalculateBut(object sender, RoutedEventArgs e)
        {
            KiloLabel.Text = "" + Math.Round(Convert.ToDouble(PoundBox.Text) * 0.453592, 2);
        }
    }
}
