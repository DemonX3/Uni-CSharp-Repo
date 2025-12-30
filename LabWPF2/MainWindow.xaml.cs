using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LabWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string? lastOperation;
        public bool isResult = false;

        public MainWindow()
        {
            WindowOil oilium = new WindowOil();
            oilium.Show();

            InitializeComponent();
        }

        private void Btn_CE_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Main.Text = "0";
            isResult = false;
        }

        private void Btn_C_Click(object sender, RoutedEventArgs e)
        {
            TextBox_History.Text = "";
            TextBox_Main.Text = "0";
            isResult = false;
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Main.Text == "0") return;
            TextBox_Main.Text = TextBox_Main.Text.Remove(TextBox_Main.Text.Length - 1);

            isResult = false;
        }

        private void Btn_Operation_Click(object sender, RoutedEventArgs e)
        {
            if (isResult) TextBox_History.Text = $"{TextBox_Main.Text} {((Button)sender).Content} ";
            else TextBox_History.Text += $"{TextBox_Main.Text} {((Button)sender).Content} ";
            TextBox_Main.Text = "0";
            lastOperation = $"{((Button)sender).Content}";
            isResult = false;
        }

        private void Btn_Result_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_History.Text == "" || TextBox_Main.Text == "0" || isResult == true) return;
            else TextBox_History.Text += $"{TextBox_Main.Text}";
            TextBox_Main.Text = "0";

            double result = Convert.ToDouble(new DataTable().Compute(TextBox_History.Text.Replace(',', '.'), null).ToString()); //thanks compute for existing, doing calculator manually was driving me to kill myself
            TextBox_Main.Text = $"{String.Format(result % 1 == 0 ? "{0:0}" : "{0:0.##########}", result)}";
            isResult = true;
        }

        private void Btn_Dot_Click(object sender, RoutedEventArgs e)
        {
            string decimalSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (TextBox_Main.Text.Contains(decimalSymbol)) return;
            TextBox_Main.Text += decimalSymbol;
            isResult = false;
        }

        private void Btn_Num_0_Click(object sender, RoutedEventArgs e)
        {
            if (isResult) Btn_C_Click(sender, e);
            if (TextBox_Main.Text != "0") TextBox_Main.Text += "0";
            isResult = false;
        }

        private void Btn_Num_Click(object sender, RoutedEventArgs e)
        {
            if (isResult) Btn_C_Click(sender, e);
            if (TextBox_Main.Text == "0") TextBox_Main.Text = "";
            TextBox_Main.Text += $"{((Button)sender).Content}";
            isResult = false;
        }
    }
}