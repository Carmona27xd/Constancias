using Constancias.DTO;
using Constancias.POCO;
using Constancias.Singleton;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Constancias.Views {
    /// <summary>
    /// Lógica de interacción para AdminView.xaml
    /// </summary>
    public partial class AdminView : Page {
        List<Employee> employees;
        EmployeeDAO employeeDAO = new EmployeeDAO ();
        public AdminView () {
            InitializeComponent ();
            LoadEmployees ();
        }

        private void LoadEmployees () {
            try {
                employees = employeeDAO.GetProfessors ();
                if (employees == null) {
                    MessageBox.Show ("No se han registrado profesores en el sistema");
                } else {
                    ProfessorsDatagrid.ItemsSource = employees;
                }
            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }

        private void Register_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate (new Constancias.Views.RegisterProfessor ());
        }

        private void Register_Label_Click (object obj, RoutedEventArgs e) {
            this.NavigationService.Navigate (new Constancias.Views.RegisterProfessor ());
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

        private void View_Details (object sender, RoutedEventArgs e) {
            if (ProfessorsDatagrid.SelectedItem is Employee professor) {
                try {
                    this.NavigationService.Navigate (new ProfessorDetails (professor));
                } catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }
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
    }
}
