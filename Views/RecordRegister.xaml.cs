using Constancias.POCO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Constancias.Views {
    /// <summary>
    /// Lógica de interacción para RecordRegister.xaml
    /// </summary>
    public partial class RecordRegister : Page {
        private ObservableCollection<Certificate> retrievedCertificates = new ObservableCollection<Certificate> ();
        public RecordRegister () {
            InitializeComponent ();
        }

        private void Back_Click (object sender, RoutedEventArgs e) {
            MessageBox.Show ("Registro cancelado");
            this.NavigationService.GoBack ();
        }

        private void Back_Label_Click (object sender, RoutedEventArgs e) {
            MessageBox.Show ("Registro cancelado");
            this.NavigationService.GoBack ();
        }

        private void Continue_Click (object sender, RoutedEventArgs e) {

        }

        private void Continue_Label_Click (Object sender, RoutedEventArgs e) {

        }
    }
}
