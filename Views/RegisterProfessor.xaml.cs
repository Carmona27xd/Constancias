using Constancias.DTO;
using Constancias.POCO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Constancias.Views {
    /// <summary>
    /// Lógica de interacción para RegisterProfessor.xaml
    /// </summary>
    public partial class RegisterProfessor : Page {
        EmployeeDAO employeeDAO = new EmployeeDAO ();
        public RegisterProfessor () {
            InitializeComponent ();
            LoadCategoryCB ();
            LoadContractTypeCB ();
        }

        private void Register_Click (object sender, RoutedEventArgs e) {
            Register ();
        }

        private void Register_Label_Click (object sender, RoutedEventArgs e) {
            Register ();
        }

        private void Back_Click (object sender, RoutedEventArgs e) {
            GoBack ();
        }

        private void Back_Label_Click (object sender, RoutedEventArgs e) {
            GoBack ();
        }

        private void Register () {
            // Validar primero los campos de texto
            if (CheckFields ()) {
                MessageBox.Show ("Por favor complete todos los campos obligatorios.");
                return;
            }

            // Validar después los ComboBox
            if (CheckCB ()) {
                MessageBox.Show ("Por favor seleccione una categoría y un tipo de contrato.");
                return;
            }

            // Si pasa las validaciones, intentar registrar
            try {
                string category = cbCategory.Text;
                string contractType = cbContractType.Text;
                Employee newProfessor = CreateProfessor (category, contractType);
                InsertProfessor (newProfessor);
                this.NavigationService.GoBack ();
            } catch (Exception ex) {
                MessageBox.Show ($"Ocurrió un error al registrar al profesor: {ex.Message}");
            }
        }

        private Employee CreateProfessor (string category, string contractType) {
            Employee newEmployee = new Employee ();
            newEmployee.FirstName = txtName.Text.Trim ();
            newEmployee.MiddleName = txtMiddleName.Text.Trim ();
            newEmployee.LastName = txtLastname.Text.Trim ();
            newEmployee.Tuition = txtTuition.Text.Trim ();
            newEmployee.Email = Email.Text.Trim ();
            newEmployee.Password = txtPassword.Text.Trim ();
            newEmployee.IdRole = 3;

            switch (category) {
                case "Titular":
                    newEmployee.IdProfesorCategory = 2;
                    break;
                case "Asociado":
                    newEmployee.IdProfesorCategory = 3;
                    break;
                case "Asistente":
                    newEmployee.IdProfesorCategory = 4;
                    break;
                case "Adjunto":
                    newEmployee.IdProfesorCategory = 5;
                    break;
                case "Sustituto":
                    newEmployee.IdProfesorCategory = 6;
                    break;
            }

            switch (contractType) {
                case "Tiempo completo":
                    newEmployee.IdContractType = 2;
                    break;
                case "Medio tiempo":
                    newEmployee.IdContractType = 3;
                    break;
                case "Por asignatura":
                    newEmployee.IdContractType = 4;
                    break;
                case "Temporal":
                    newEmployee.IdContractType = 5;
                    break;
                case "Honorarios":
                    newEmployee.IdContractType = 6;
                    break;
            }
            return newEmployee;
        }

        private void LoadCategoryCB () {
            List<String> categories = new List<String> { "Titular", "Asociado", "Asistente", "Adjunto", "Sustituto" };
            cbCategory.ItemsSource = categories;
        }

        private void LoadContractTypeCB () {
            List<String> contractTypes = new List<String> { "Tiempo completo", "Medio tiempo", "Por signatura",
            "Temporal", "Honorarios"};
            cbContractType.ItemsSource = contractTypes;
        }

        private void InsertProfessor (Employee employee) {
            bool confirmation = employeeDAO.InsertEmployee (employee);
            if (confirmation) {
                MessageBox.Show ("Profesor registrado con exito");
            } else {
                MessageBox.Show ("No se ha podido registrar el profesor");
            }
        }

        private bool CheckFields () {
            // Verificar que todos los campos obligatorios estén completos
            return string.IsNullOrWhiteSpace (txtName.Text) ||
                   string.IsNullOrWhiteSpace (txtMiddleName.Text) ||
                   string.IsNullOrWhiteSpace (txtLastname.Text) ||
                   string.IsNullOrWhiteSpace (txtTuition.Text) ||
                   string.IsNullOrWhiteSpace (Email.Text) ||
                   string.IsNullOrWhiteSpace (txtPassword.Text);
        }


        private bool CheckCB () {
            if (cbCategory.SelectedValue == null || cbContractType.SelectedValue == null) {
                return true;
            } else {
                return false;
            }
        }

        private void GoBack () {
            MessageBox.Show ("Registro cancelado");
            this.NavigationService.GoBack ();
        }
    }
}
