using Constancias.DTO;
using Constancias.POCO;
using Constancias.Utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Constancias.Views {
    /// <summary>
    /// Interaction logic for DetailsCertificate.xaml
    /// </summary>
    public partial class DetailsCertificate : Page {
        private Certificate selectedCertificate;

        public DetailsCertificate (int idCertificate) {
            InitializeComponent ();

            RetrieveDataCertificate (idCertificate);
        }

        private void RetrieveDataCertificate (int idCertificate) {
            selectedCertificate = CertificateDAO.GetCertificate (idCertificate);
            if (selectedCertificate != null) {
                label_Profesor.Content = selectedCertificate.Profesor.CompleteName;
                label_DateEmited.Content = selectedCertificate.DateEmited.ToString ("D");
                label_TypeCertificate.Content = selectedCertificate.Type;

                GeneratePDF ();
            } else {
                MessageBox.Show ("No se pudo cargar los datos del certificado.\nIntente más tarde.", "Error al cargar los datos.");
            }
        }

        private void GeneratePDF () {
            try {
                selectedCertificate.Doc = ModifyWordTemplate.ParticipacionActualizacionEEProyectoIntegrador (selectedCertificate);
                if (selectedCertificate.Doc == null) {
                    label_StatusFile.Content = "No se pudo obtener el PDF.\nIntente más tarde.";
                } else {
                    PdfViewer.Visibility = Visibility.Visible;
                    ShowPdfWebBrowser.ShowPdfInWebView2(PdfViewer, selectedCertificate.Doc, selectedCertificate.Type);
                }
            } catch (Exception ex) {
                label_StatusFile.Content = "No se pudo obtener la constancia.\nIntente más tarde.";
                MessageBox.Show (ex.ToString());
            }
        }

        private void Back_Label_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack ();
        }

        private void Back_Click (object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack ();
        }
    }
}
