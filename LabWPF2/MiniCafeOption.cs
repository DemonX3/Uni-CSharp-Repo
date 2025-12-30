using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LabWPF2
{
    class MiniCafeOption
    {
        private string OptionName { get; set; }
        private decimal Price { get; set; }

        public MiniCafeOption(string name, decimal price)
        {
            OptionName = name;
            Price = price;
        }

        public Dictionary<CheckBox, DockPanel> AddOption()
        {
            Dictionary<CheckBox, DockPanel> result = new Dictionary<CheckBox, DockPanel>();
            /*
            CheckBox checkBox = new CheckBox() { Name = $"CafeOptionCheck_{item.Key}" };
            TextBox amountBox = new TextBox() { Name = $"CafeOptionAmount_{item.Key}" };
            TextBox priceBox = new TextBox() { Name = $"CafeOptionPrice_{item.Key}" };
            DockPanel dockPanel = new DockPanel() { Name = $"CafeOptionDock_{item.Key}" };
            checkBox.Click += CheckBox_Click;
            CafeOptionCheckStack.Children.Add(checkBox);
            CafeOptionNumberStack.Children.Add(priceBox);

            dockPanel.Children.Add(priceBox);
            dockPanel.Children.Add(amountBox);
            */

            CheckBox checkBox = new CheckBox() { Name = $"CafeOptionCheck_{OptionName}", Content = $"{OptionName}", Height = 20 };
            DockPanel dockPanel = new DockPanel() { Name = $"CafeNumbersDock_{OptionName}", LastChildFill = false };
            TextBox priceBox = new TextBox() { Name = $"CafeOptionPrice_{OptionName}", Text = $"{Price}", IsReadOnly = true, Width = 60, Height = 20 };
            TextBox amountBox = new TextBox() { Name = $"CafeOptionAmount_{OptionName}", Text = "0", Width = 60, Height = 20 };

            priceBox.Background = Brushes.LightGray;
            amountBox.MaxLength = 3;

            dockPanel.Children.Add(priceBox);
            dockPanel.Children.Add(amountBox);
            DockPanel.SetDock(dockPanel.Children[1], Dock.Right);

            result.Add(checkBox, dockPanel);

            return result;
        }
    }
}
