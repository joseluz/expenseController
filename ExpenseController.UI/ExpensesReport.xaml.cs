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


        ObservableCollection<ExpenseViewData> CategoryExpenseCollection = new ObservableCollection<ExpenseViewData>();

        ObservableCollection<ExpenseViewData> ExpenseCollection = new ObservableCollection<ExpenseViewData>();

        string CurrencySymbol = "$"; // add to ViewData if needed

        public ExpensesReport()
        {
            this.InitializeComponent();

            #region CategoryExpenses

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Comida",
                Value = 100,
                Date = DateTime.Today.AddDays(1)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Cinema",
                Value = 200,
                Date = DateTime.Today.AddDays(2)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Brinquedos",
                Value = 300,
                Date = DateTime.Today.AddDays(3)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Roupas",
                Value = 150,
                Date = DateTime.Today.AddDays(4)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Água",
                Value = 500,
                Date = DateTime.Today.AddDays(5)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Carro",
                Value = 600,
                Date = DateTime.Today.AddDays(6)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Luz",
                Value = 700,
                Date = DateTime.Today.AddDays(5)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Supermercado",
                Value = 800,
                Date = DateTime.Today.AddDays(1)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Presentes",
                Value = 900,
                Date = DateTime.Today.AddDays(-1)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Telephone",
                Value = 1000,
                Date = DateTime.Today.AddDays(-2)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Escola",
                Value = 100,
                Date = DateTime.Today.AddDays(11)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Internet",
                Value = 100,
                Date = DateTime.Today.AddDays(2)
            });

            CategoryExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Outros",
                Value = 100,
                Date = DateTime.Today.AddDays(3)
            });
            #endregion

            #region Expenses

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Coca-Cola",
                Value = 1.60,
                Date = DateTime.Today.AddDays(-1)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Pepsi",
                Value = 1.20,
                Date = DateTime.Today.AddDays(-1)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Chocolate",
                Value = 1.20,
                Date = DateTime.Today.AddDays(-5)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Sorvete",
                Value = 3.20,
                Date = DateTime.Today.AddDays(0)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Almoço",
                Value = 15.60,
                Date = DateTime.Today.AddDays(-3)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Jantar",
                Value = 12.20,
                Date = DateTime.Today.AddDays(-3)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Supermercado",
                Value = 250.20,
                Date = DateTime.Today.AddDays(0)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Mouse",
                Value = 17.30,
                Date = DateTime.Today.AddDays(0)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Material Escolar",
                Value = 150.89,
                Date = DateTime.Today.AddDays(-20)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Livros",
                Value = 42,
                Date = DateTime.Today.AddDays(0)
            });

            ExpenseCollection.Add(new ExpenseViewData
            {
                Name = "Celular",
                Value = 70.26,
                Date = DateTime.Today.AddDays(1)
            });

            #endregion

            ((BarSeries)this.BarChart.Series[0]).ItemsSource = CategoryExpenseCollection;

            ((PieSeries)this.PieChart.Series[0]).ItemsSource = CategoryExpenseCollection;

            ExpensesListView.ItemsSource = ExpenseCollection.OrderBy(e => e.Date).Take(10).Select(e => e.Date + ": " + e.Value + CurrencySymbol + " " + e.Name);
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
