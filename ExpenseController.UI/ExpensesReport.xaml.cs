using ExpenseController.UI.Model;
using ExpenseController.UI.ViewData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        ObservableCollection<CategoryExpenseViewData> CategoryExpenseCollection = new ObservableCollection<CategoryExpenseViewData>();
        ObservableCollection<ExpenseViewData> ExpenseCollection = new ObservableCollection<ExpenseViewData>();

        public ExpensesReport()
        {
            this.InitializeComponent();

            var categories = new[]
            {
                new ExpenseCategory() { Id = 1, Name = "Comida", Color = Color.FromArgb(255, 255, 0, 0) },
                new ExpenseCategory() { Id = 2, Name = "Farmácia", Color = Color.FromArgb(255, 0, 255, 0) },
                new ExpenseCategory() { Id = 3, Name = "Entretenimento", Color = Color.FromArgb(255, 0, 0, 255) },
                new ExpenseCategory() { Id = 4, Name = "Outros", Color = Color.FromArgb(255, 255, 255, 0) },
            };
            var expenses = Enumerable.Range(0, 20).Select(i => new Expense() { Id = i + 1, Category = categories[i % categories.Length], Date = DateTime.Today.AddDays(-i), Value = i * 100, Description = "Description " + i });

            var expensesViewDatas = expenses.Select(e => new ExpenseViewData(e)).ToArray();
            var categoryViewDatas = expenses.GroupBy(e => e.Category).Select(g => new CategoryExpenseViewData(g.Key.Name, g.Sum(e => e.Value))).ToArray();

            foreach (var expenseViewData in expensesViewDatas)
                ExpenseCollection.Add(expenseViewData);
            foreach (var categoryViewData in categoryViewDatas)
                CategoryExpenseCollection.Add(categoryViewData);

            ((BarSeries)this.BarChart.Series[0]).ItemsSource = CategoryExpenseCollection;
            ((PieSeries)this.PieChart.Series[0]).ItemsSource = CategoryExpenseCollection;
            ExpensesListView.ItemsSource = ExpenseCollection.OrderBy(e => e.Wrapped.Date).ToArray();
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
