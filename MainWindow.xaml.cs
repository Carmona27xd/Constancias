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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkFields())
                {
                    Employee currentUser = employeeDAO.logIn(txtEmail.Text, txtPassword.Text);
                    if (currentUser != null)
                    {
                        MessageBox.Show("Bienvenido al sistema " + currentUser.FirstName);
                        SessionManager.Instance.login(currentUser);

                    }
                    else
                    {
                        MessageBox.Show("Por favor verifica las credenciales");
                    }
                }
                else
                {
                    MessageBox.Show("BASILIO ERES UNA PUTA");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
