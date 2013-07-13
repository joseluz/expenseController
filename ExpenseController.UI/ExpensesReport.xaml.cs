using ExpenseController.UI.ViewData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ExpenseController.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class ExpensesReport : Page
    {


        ObservableCollection<ExpenseViewData> Expenses = new ObservableCollection<ExpenseViewData>();
        

        public ExpensesReport()
        {
            this.InitializeComponent();

            Expenses.Add(new ExpenseViewData
            {
                Name = "test1",
                Value = 100
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test2",
                Value = 200
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test3",
                Value = 300
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test4",
                Value = 150
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test5",
                Value = 500
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test6",
                Value = 600
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test7",
                Value = 700
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test8",
                Value = 800
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test9",
                Value = 900
            });

            Expenses.Add(new ExpenseViewData
            {
                Name = "test10",
                Value = 1000
            });


            ((BarSeries)this.BarChart.Series[0]).ItemsSource = Expenses;

            ((PieSeries)this.PieChart.Series[0]).ItemsSource = Expenses;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
