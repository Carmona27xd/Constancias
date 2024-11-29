using Constancias.DTO;
using Constancias.POCO;
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
    /// Lógica de interacción para AdminView.xaml
    /// </summary>
    public partial class AdminView : Page
    {
        List<Employee> employees;
        EmployeeDAO employeeDAO = new EmployeeDAO();
        public AdminView()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                employees = employeeDAO.GetProfessors();
                if (employees == null)
                {
                    MessageBox.Show("No se han registrado profesores en el sistema");
                } 
                else
                {
                    ProfessorsDatagrid.ItemsSource = employees;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegistrarProfesor(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterProfessor());

        }

        private void IrAProfesores(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Constancias.Views.AdminView());
        }

        private void IrAConstancias(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Constancias.Views.AdminRecordsView());
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

        private void View_Details(object sender, RoutedEventArgs e)
        {
            if(ProfessorsDatagrid.SelectedItem is Employee professor)
            {
                try
                {
                    this.NavigationService.Navigate(new ProfessorDetails(professor));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProfessorsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
