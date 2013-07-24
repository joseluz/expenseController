using ExpenseController.UI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
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
    public sealed partial class MainPage : Page
    {
        Popup _settingsPopup;

        public MainPage()
        {
            this.InitializeComponent();
            SettingsPane.GetForCurrentView().CommandsRequested += Settings_CommandsRequested;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.SpecificLayoutFrame.Navigate(typeof(ExpensesReport));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new InsertExpenseFlyout().Open();
        }

        public void Settings_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            SettingsCommand cmd = new SettingsCommand("advancedConfiguration", "Configurações Avançadas", (x) =>
            {
                _settingsPopup = new Popup();
                _settingsPopup.Closed += OnPopupClosed;
                Window.Current.Activated += OnWindowActivated;
                _settingsPopup.IsLightDismissEnabled = true;
                _settingsPopup.Width = 400;
                _settingsPopup.Height = Window.Current.Bounds.Height;

                ExpenseSettings mypane = new ExpenseSettings();
                mypane.Width = 400;
                mypane.Height = Window.Current.Bounds.Height;

                _settingsPopup.Child = mypane;
                Canvas.SetLeft(_settingsPopup, Window.Current.Bounds.Width - _settingsPopup.Width + 5);
                // _settingsPopup.SetValue(Canvas.LeftProperty, Window.Current.Bounds.Width - _settingsPopup.Width);
                _settingsPopup.SetValue(Canvas.TopProperty, 0);
                _settingsPopup.IsOpen = true;
            });

            args.Request.ApplicationCommands.Add(cmd);
        }

        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                _settingsPopup.IsOpen = false;
            }
        }

        void OnPopupClosed(object sender, object e)
        {
            Window.Current.Activated -= OnWindowActivated;
        }
    }
}
