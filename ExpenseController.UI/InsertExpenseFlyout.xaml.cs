using ExpenseController.UI.DAO;
using ExpenseController.UI.Model;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ExpenseController.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InsertExpenseFlyout : Page
    {
        private BaseDAO<Expense> expenseDao;

        public InsertExpenseFlyout()
        {
            this.InitializeComponent();
            expenseDao = new BaseDAO<Expense>();
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
            if (!addExpensePopUp.IsOpen)
            {
                BindCategoryList();
                popupBorder.Height = Window.Current.Bounds.Height + 10;
                addExpensePopUp.IsOpen = true;

                Canvas.SetLeft(addExpensePopUp, Window.Current.Bounds.Width - popupBorder.Width + 5);

                valueTextBox.Text = "0,00";
                expenseDatePicker.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
                Window.Current.Activated += OnWindowActivated;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (addExpensePopUp.IsOpen)
                addExpensePopUp.IsOpen = false;
        }

        public void BindCategoryList()
        {
            var baseUri = new Uri("ms-appx:///");
            var categories = new List<ExpenseCategory>();
            categories.Add(new ExpenseCategory() { Id = 1, Name = "Transporte", Image = new BitmapImage(new Uri(baseUri, "Images/bus-48.png")), BackColor = new SolidColorBrush(Colors.LightGreen), });
            categories.Add(new ExpenseCategory() { Id = 2, Name = "Farmacia", Image = new BitmapImage(new Uri(baseUri, "Images/apartment-48.png")), BackColor = new SolidColorBrush(Colors.LightYellow), });
            categories.Add(new ExpenseCategory() { Id = 3, Name = "Almoco", BackColor = new SolidColorBrush(Colors.LightSteelBlue), });
            categories.Add(new ExpenseCategory() { Id = 4, Name = "Mercado", BackColor = new SolidColorBrush(Colors.LightGray), });
            categories.Add(new ExpenseCategory() { Id = 5, Name = "Feira", BackColor = new SolidColorBrush(Colors.LightCoral), });
            categories.Add(new ExpenseCategory() { Id = 6, Name = "Moradia", Image = new BitmapImage(new Uri(baseUri, "Images/log_cabin-48.png")), BackColor = new SolidColorBrush(Colors.LightPink), });
            categoriesListView.ItemsSource = categories;
            categoriesListView.SelectedIndex = 0;
        }

        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                Hide();
            }
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            Hide();
        }

        public void Hide()
        {
            OnClosingEvent(this);
            Window.Current.Activated -= OnWindowActivated;
            Canvas.SetLeft(addExpensePopUp, Window.Current.Bounds.Width);

            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            Window.Current.Activated -= OnWindowActivated;
        }

        public void OnClosingEvent(object sender)
        {
            try
            {
                addExpensePopUp.IsOpen = false;
                Canvas.SetLeft(addExpensePopUp, Window.Current.Bounds.Width + 10);
            }
            catch { }
        }

        private void saveExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var expense = new Expense()
            {
                Category = (ExpenseCategory)categoriesListView.SelectedItem,
                Description = descriptionTextBox.Text,
            };
            decimal value;
            expense.Value = decimal.TryParse(valueTextBox.Text, out value) ? value : 0;
            DateTime date;
            expense.Date = DateTime.TryParse(expenseDatePicker.Text, out date) ? date : DateTime.Now;

            expenseDao.Save(expense);

            if (addExpensePopUp.IsOpen)
                addExpensePopUp.IsOpen = false;
        }

        private void descriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            descriptionTextBox.Foreground = new SolidColorBrush(Colors.Black);
            descriptionTextBox.Text = string.Empty;
        }

        private void descriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                descriptionTextBox.Foreground = new SolidColorBrush(Colors.LightGray);
                descriptionTextBox.Text = "Descrição";
            }
        }
    }
}
