using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LabWPF2
{
    /// <summary>
    /// Interaction logic for WindowOil.xaml
    /// </summary>
    public partial class WindowOil : Window
    {

        Dictionary<string, double> fuelOptions = new Dictionary<string, double>();
        Dictionary<string, double> miniCafeOptionList = new Dictionary<string, double>();
        Dictionary<CheckBox, DockPanel> miniCafeOptions = new Dictionary<CheckBox, DockPanel>();

        public WindowOilFinal windowOilFinal = new WindowOilFinal();
        double totalEarnings = 0;
        public WindowOil()
        {

            InitializeComponent();

            //Gas Station
            fuelOptions.Add("87 Octane", 0.85);
            fuelOptions.Add("89 Octane", 0.96);
            fuelOptions.Add("90 Octane", 1.11);
            fuelOptions.Add("91 Octane", 1.19);
            fuelOptions.Add("92 Octane", 1.27);
            fuelOptions.Add("93 Octane", 1.43);
            fuelOptions.Add("94 Octane", 1.62);
            fuelOptions.Add("Diesel", 1.9);
            fuelOptions.Add("LPG", 1.62);

            foreach (var item in fuelOptions)
            {
                GasComboBox.Items.Add(item.Key);
            }

            GasComboBox.SelectedIndex = 0;

            //Mini Cafe
            miniCafeOptionList.Add("Hotdog", 4);
            miniCafeOptionList.Add("Hamburger", 5.4);
            miniCafeOptionList.Add("Chickenburger", 5.8);
            miniCafeOptionList.Add("Fries", 7.2);
            miniCafeOptionList.Add("CocaCola", 4.4);
            miniCafeOptionList.Add("MiniPizza", 4.6);

            foreach (var item in miniCafeOptionList)
            {
                MiniCafeOption option = new MiniCafeOption(item.Key, (decimal)item.Value);

                Dictionary<CheckBox, DockPanel> dict = option.AddOption();

                CheckBox checkBox = dict.ElementAt(0).Key;
                DockPanel dockPanel = dict.ElementAt(0).Value;
                TextBox amountBox = (TextBox)dockPanel.Children[1];

                amountBox.PreviewTextInput += TextBox_AmountPreview;

                CafeOptionCheckStack.Children.Add(checkBox);
                CafeOptionNumberStack.Children.Add(dockPanel);

                miniCafeOptions.Add(checkBox, dockPanel);
            }

        }

        private void GasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GasPriceBox.Text = fuelOptions.GetValueOrDefault(GasComboBox.SelectedItem.ToString()).ToString();
        }

        private void GasByAmountRadio_Click(object sender, RoutedEventArgs e)
        {
            GasByAmountTextbox.IsReadOnly = false;
            GasByAmountTextbox.Background = Brushes.Transparent;
            GasByPriceTextbox.IsReadOnly = true;
            GasByPriceTextbox.Background = Brushes.LightGray;
        }

        private void GasByPriceRadio_Click(object sender, RoutedEventArgs e)
        {
            GasByAmountTextbox.IsReadOnly = true;
            GasByAmountTextbox.Background = Brushes.LightGray;
            GasByPriceTextbox.IsReadOnly = false;
            GasByPriceTextbox.Background = Brushes.Transparent;
        }

        private void GasByAmountTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GasByPriceTextbox == null || GasPriceTotalBox == null || GasByAmountTextbox.IsReadOnly) return;

            double gasPrice, amount, result;

            Double.TryParse(GasPriceBox.Text, out gasPrice);
            Double.TryParse(GasByAmountTextbox.Text, out amount);

            result = gasPrice * amount;

            GasByPriceTextbox.Text = $"{String.Format(result % 1 == 0 ? "{0:0}" : "{0:0.###}", result)}";
        }

        private void GasByPriceTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GasByAmountTextbox == null || GasPriceTotalBox == null || GasByPriceTextbox.IsReadOnly) return;

            double gasPrice, price, result;

            Double.TryParse(GasPriceBox.Text, out gasPrice);
            Double.TryParse(GasByPriceTextbox.Text, out price);

            result = price / gasPrice;

            GasByAmountTextbox.Text = $"{String.Format(result % 1 == 0 ? "{0:0}" : "{0:0.###}", result)}";
        }

        private void Btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double totalGasPrice, totalCafePrice = 0, result;
            double gasPrice, gasAmount, gasByPrice;
            double cafeOptionPrice, cafeOptionAmount;

            Double.TryParse(GasPriceBox.Text, out gasPrice);

            if (!GasByAmountTextbox.IsReadOnly)
            {
                Double.TryParse(GasByAmountTextbox.Text, out gasAmount);
            }
            else
            {
                Double.TryParse(GasByPriceTextbox.Text, out gasByPrice);
                gasAmount = gasByPrice / gasPrice;
            }

            totalGasPrice = gasPrice * gasAmount;

            for (int i = 0; i < CafeOptionCheckStack.Children.Count; i++)
            {
                if (((CheckBox)CafeOptionCheckStack.Children[i]).IsChecked == false) continue;

                DockPanel dockPanel = (DockPanel)CafeOptionNumberStack.Children[i];
                Double.TryParse(((TextBox)dockPanel.Children[0]).Text, out cafeOptionPrice);
                Double.TryParse(((TextBox)dockPanel.Children[1]).Text, out cafeOptionAmount);

                totalCafePrice += cafeOptionPrice * cafeOptionAmount;
            }

            result = totalGasPrice + totalCafePrice;

            GasPriceTotalBox.Text = $"{String.Format(totalGasPrice % 1 == 0 ? "{0:0}" : "{0:0.###}", totalGasPrice)}";
            CafePriceTotalBox.Text = $"{String.Format(totalCafePrice % 1 == 0 ? "{0:0}" : "{0:0.###}", totalCafePrice)}";
            TotalPriceBox.Text = $"{String.Format(result % 1 == 0 ? "{0:0}" : "{0:0.###}", result)}";

            totalEarnings += result;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            windowOilFinal.TotalEarnings.Text = $"{totalEarnings}";
            windowOilFinal.Show();
        }

        private void TextBox_AmountPreview(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_DoublePreview(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
