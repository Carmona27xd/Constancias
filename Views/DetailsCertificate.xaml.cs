using System.Threading.Tasks;
using System.Windows.Controls;

namespace Constancias.Views {
    /// <summary>
    /// Interaction logic for DetailsCertificate.xaml
    /// </summary>
    public partial class DetailsCertificate : Page {
        public DetailsCertificate (int idCertificate) {
            InitializeComponent ();

            _ = RetrieveDataCertificate ();
        }

        private async Task RetrieveDataCertificate () {
        
        }
    }
}
