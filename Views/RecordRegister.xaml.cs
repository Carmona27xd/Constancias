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
    /// Lógica de interacción para RecordRegister.xaml
    /// </summary>
    public partial class RecordRegister : Page
    {
        public RecordRegister()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registro cancelado");
            this.NavigationService.GoBack();
        }

        private void Back_Label_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registro cancelado");
            this.NavigationService.GoBack();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Continue_Label_Click(Object sender, RoutedEventArgs e)
        {

        }
    }
}
