using Constancias.POCO;
using Constancias.Singleton;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Constancias.Views {
    /// <summary>
    /// Lógica de interacción para ProfessorDetails.xaml
    /// </summary>
    public partial class ProfessorDetails : Page {
        Employee employeeAux = new Employee ();
        public ProfessorDetails (Employee employee) {
            InitializeComponent ();
            this.employeeAux = employee;
            InitInformation (employeeAux);
        }

        private void goToRecords (object sender, MouseButtonEventArgs e) {
            ChangeWindow ();
        }

        private void lable_click (object sender, RoutedEventArgs e) {
            ChangeWindow ();
        }

        private void ChangeWindow () {
            this.NavigationService.Navigate (new Constancias.Views.AdminRecordsView ());
        }

        private void logout_click (object sender, RoutedEventArgs e) {
            LogOut ();
        }

        private void logout_label_click (object sender, RoutedEventArgs e) {
            LogOut ();
        }

        private void Back_Click (object sender, RoutedEventArgs e) {
            GoBack ();
        }

        private void Back_Label_Click (object sender, RoutedEventArgs e) {
            GoBack ();
        }

        public void InitInformation (Employee employee) {
            ProfessorName.Content = employee.FirstName;
            ProfessorMiddleName.Content = employee.MiddleName;
            ProfessorLastName.Content = employee.LastName;
            Email.Content = employee.Email;
            ProfessorTuition.Content = employee.Tuition;

            switch (employee.IdContractType) {
                case 1:
                    Category.Content = "Sin asignar";
                    break;
                case 2:
                    Category.Content = "Titular";
                    break;
                case 3:
                    Category.Content = "Asociado";
                    break;
                case 4:
                    Category.Content = "Asistente";
                    break;
                case 5:
                    Category.Content = "Adjunto";
                    break;
                case 6:
                    Category.Content = "Sustituo";
                    break;
            }

            switch (employee.IdProfesorCategory) {
                case 1:
                    ContractType.Content = "Sin asignar";
                    break;
                case 2:
                    ContractType.Content = "Tiempo completo";
                    break;
                case 3:
                    ContractType.Content = "Medio tiempo";
                    break;
                case 4:
                    ContractType.Content = "Por asignatura";
                    break;
                case 5:
                    ContractType.Content = "Temporal";
                    break;
                case 6:
                    ContractType.Content = "Honorarios";
                    break;
            }

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

        private void GoBack () {
            this.NavigationService.GoBack ();
        }
    }
}
