using Constancias.Connection;
using Constancias.DTO;
using Constancias.POCO;
using Constancias.Singleton;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Constancias
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        EmployeeDAO employeeDAO;
        public MainWindow()
        {
            InitializeComponent();
            txtEmail.Text ="administrador@example.com";
            txtPassword.Text = "1234";
            employeeDAO = new EmployeeDAO();

        }

        private void Button_Aceptar(object sender, RoutedEventArgs e)
        {
            if (!checkFields())
            {
                MessageBox.Show("Por favor ingrese sus credenciales", "Campos fatantes");
            }
            else
            {
                try
                {
                    Employee employee = new Employee();
                    employee = employeeDAO.LogIn(txtEmail.Text, txtPassword.Text);
                    if (employee != null)
                    {
                        SessionManager.Instance.login(employee);

                        if(employee.IdEmployee == 1)
                        {
                            MessageBox.Show("Bienvenido/a al sistema administrativo " + employee.FirstName + " " + employee.MiddleName + " " + employee.LastName);
                            MainFrame.Navigate(new Constancias.Views.AdminRecordsView());
                        }

                        else if(employee.IdEmployee == 3)
                        {
                            MessageBox.Show("Bienvenido/a al sistema profesor " + employee.FirstName + " " + employee.MiddleName + " " + employee.LastName);
                            MainFrame.Navigate(new Constancias.Views.ProfessorView());

                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas", "Iniciar sesion");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la sesion", "Error");
                }
            }
        }

        private bool checkFields()
        {
            if (txtEmail.Text.Length == 0 || txtPassword.Text.Length == 0) { return false; }
            else
            {
                return true;
            }
        }

        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
