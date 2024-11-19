using Constancias.DTO;
using Constancias.POCO;
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
    /// Lógica de interacción para RegisterProfessor.xaml
    /// </summary>
    public partial class RegisterProfessor : Page
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();
        public RegisterProfessor()
        {
            InitializeComponent();
            LoadCategoryCB();
            LoadContractTypeCB();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Register_Label_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void Back_Label_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        
        private Employee CreateProfessor(string category, string contractType)
        {
            Employee newEmployeed = new Employee();
            newEmployeed.FirstName = txtName.Text.Trim();
            newEmployeed.MiddleName = txtMiddleName.Text.Trim();
            newEmployeed.LastName = txtLastname.Text.Trim();
            newEmployeed.Tuition = txtTuition.Text.Trim();
            newEmployeed.Email = Email.Text.Trim();
            newEmployeed.Password = txtPassword.Text.Trim();
            newEmployeed.IdRole = 3;

            return newEmployeed;
        }

        private void LoadCategoryCB()
        {
            List<String> categories = new List<String> { "Titular", "Asociado", "Asistente", "Adjunto", "Sustituto" };
            cbCategory.ItemsSource = categories;
        }

        private void LoadContractTypeCB()
        {
            List<String> contractTypes = new List<String> { "Tiempo completo", "Medio tiempo", "Por signatura",
            "Temporal", "Honorarios"};
            cbContractType.ItemsSource = contractTypes;
        }
        
        private void InsertProfessor(Employee employee)
        {
            bool confirmation = employeeDAO.InsertEmployee(employee);
            if (confirmation)
            {
                MessageBox.Show("Profesor registrado con exito");
            }
            else
            {
                MessageBox.Show("No se ha podido registrar el profesor");
            }
        }

        private bool CheckFields()
        {
            if(txtName.Text.Trim().Length > 0 || txtMiddleName.Text.Trim().Length >0
                || txtLastname.Text.Trim().Length >0 || txtTuition.Text.Trim().Length >0 
                || Email.Text.Trim().Length >0)
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

        private bool CheckCB()
        {
            if(cbCategory.SelectedValue == null || cbContractType.SelectedValue == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GoBack()
        {
            MessageBox.Show("Registro cancelado");
            this.NavigationService.GoBack();
        }
    }
}
