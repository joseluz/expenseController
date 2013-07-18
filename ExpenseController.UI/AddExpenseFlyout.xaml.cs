using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExpenseController.UI.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ExpenseController.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddExpenseFlyout : Page
    {

        public AddExpenseFlyout()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void Open()
        {
            BindCategoryList();

            addExpensePopUp.HorizontalOffset = Window.Current.Bounds.Width - popupBorder.Width + 5;
            popupBorder.Height = Window.Current.Bounds.Height + 10;
            addExpensePopUp.IsOpen = true;
        }

        public void BindCategoryList()
        {
            var categories = new List<ExpenseCategory>();
            categories.Add(new ExpenseCategory() { Id = 1, Name = "Transporte", });
            categories.Add(new ExpenseCategory() { Id = 2, Name = "Farmacia" });
            categories.Add(new ExpenseCategory() { Id = 3, Name = "Almoco" });
            categories.Add(new ExpenseCategory() { Id = 4, Name = "Mercado" });
            categories.Add(new ExpenseCategory() { Id = 5, Name = "Feira" });
            categories.Add(new ExpenseCategory() { Id = 6, Name = "Café" });
            categoriesListView.ItemsSource = categories;
        }
    }

}
