using Constancias.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Constancias.Views
{
    /// <summary>
    /// Lógica de interacción para AdminRecordsView.xaml
    /// </summary>
    public partial class AdminRecordsView : Page
    {
        public AdminRecordsView()
        {
            InitializeComponent();
        }

        private void goToProfessors(object sender, MouseButtonEventArgs e)
        {
            ChangeWindow();
        }

        private void label_click(object sender, RoutedEventArgs e)
        {
            ChangeWindow();
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        private void logout_click_label(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        private void ChangeWindow()
        {
            this.NavigationService.Navigate(new Constancias.Views.AdminView());
        }

        private void LogOut()
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this)?.Close();
                SessionManager.Instance.logOut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
