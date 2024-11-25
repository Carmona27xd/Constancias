using Constancias.DTO;
using Constancias.POCO;
using Constancias.Singleton;
using System;
using System.Windows;

namespace Constancias {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        EmployeeDAO employeeDAO;
        public MainWindow () {
            InitializeComponent ();
            txtEmail.Text = "administrador@example.com";
            txtPassword.Text = "1234";
            employeeDAO = new EmployeeDAO ();

        }

        private void Button_Click (object sender, RoutedEventArgs e) {
            if (!checkFields ()) {
                MessageBox.Show ("Por favor ingrese sus credenciales", "Campos fatantes");
            } else {
                try {
                    Employee employee = new Employee ();
                    employee = employeeDAO.logIn (txtEmail.Text, txtPassword.Text);
                    if (employee != null) {
                        SessionManager.Instance.login (employee);
                        MessageBox.Show ("Bienvenido/a al sistema " + employee.FirstName);
                        MainFrame.Navigate (new Constancias.Views.AdminRecordsView ());
                    } else {
                        MessageBox.Show ("Credenciales incorrectas", "Iniciar sesion");
                    }
                } catch (Exception ex) {
                    MessageBox.Show ("Error al obtener la sesion", "Error");
                }
            }
        }

        private bool checkFields () {
            if (txtEmail.Text.Length == 0 || txtPassword.Text.Length == 0) {
                return false;
            } else {
                return true;
            }
        }
    }
}
