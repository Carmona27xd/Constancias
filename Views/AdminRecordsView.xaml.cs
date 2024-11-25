using Constancias.Singleton;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Constancias.Views {
    /// <summary>
    /// Lógica de interacción para AdminRecordsView.xaml
    /// </summary>
    public partial class AdminRecordsView : Page {
        public AdminRecordsView () {
            InitializeComponent ();
        }

        private void Records_Label_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate (new RecordRegister ());
        }

        private void Records_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate (new RecordRegister ());
        }

        private void History_Label_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate (new HistoryCertificades ());
        }

        private void History_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate (new HistoryCertificades ());
        }

        private void goToProfessors (object sender, MouseButtonEventArgs e) {
            ChangeWindow ();
        }

        private void label_click (object sender, RoutedEventArgs e) {
            ChangeWindow ();
        }

        private void logout_click (object sender, RoutedEventArgs e) {
            LogOut ();
        }

        private void logout_click_label (object sender, RoutedEventArgs e) {
            LogOut ();
        }

        private void ChangeWindow () {
            this.NavigationService.Navigate (new Constancias.Views.AdminView ());
        }

        private void LogOut () {
            try {
                MainWindow mainWindow = new MainWindow ();
                mainWindow.Show ();
                Window.GetWindow (this)?.Close ();
                SessionManager.Instance.logOut ();
            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }
    }
}
