using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ExpenseController.UI
{
    public sealed partial class ExpenseSettings : UserControl
    {
        public ExpenseSettings()
        {
            this.InitializeComponent();
        }

        private void MySettingsBackClicked(object sender, RoutedEventArgs e)
        {
            if (this.Parent.GetType() == typeof(Popup))
            {
                ((Popup)this.Parent).IsOpen = false;
            }
            SettingsPane.Show();
        }

        private void currencyCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void groupExpensesForCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void applyExpensesLimit_Toggled(object sender, RoutedEventArgs e)
        {
            var toggler = sender as ToggleSwitch;
            if (toggler != null)
            {
                expenseLimitValueTextbox.IsEnabled = toggler.IsOn;
            }
        }

        private void expenseLimitValueTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            expenseLimitValueTextbox.Text = "0,00";
            expenseLimitValueTextbox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void expenseLimitValueTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(expenseLimitValueTextbox.Text) || expenseLimitValueTextbox.Text == "0,00")
            {
                expenseLimitValueTextbox.Text = "Valor limite";
                expenseLimitValueTextbox.Foreground = new SolidColorBrush(Colors.LightGray);
            }
        }
    }
}
