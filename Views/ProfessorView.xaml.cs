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
    /// Lógica de interacción para ProfessorView.xaml
    /// </summary>
    public partial class ProfessorView : Page
    {
        public ProfessorView()
        {
            InitializeComponent();
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
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
