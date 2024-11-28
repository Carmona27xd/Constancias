using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Constancias.Utils {
    internal class ShowPdfWebBrowser {
        public static void ShowPDF (string NameFile, byte[] PdfFile, WebBrowser PdfViewer) {
            try {
                if (PdfFile != null && PdfFile.Length > 0) {
                    string tempFilePath = System.IO.Path.Combine (System.IO.Path.GetTempPath (), NameFile);

                    System.IO.File.WriteAllBytes (tempFilePath, PdfFile);

                    PdfViewer.Navigate (new Uri (tempFilePath));
                } else {
                    MessageBox.Show ("El archivo PDF está vacío o no disponible.");
                }
            } catch (Exception ex) {
                MessageBox.Show ($"Error al mostrar el PDF: {ex.Message}");
            }
        }
        public static void ShowPdfInWebView2 (WebView2 webView, byte[] pdfBytes, string fileName = "temp.pdf") {
            string tempFilePath = Path.Combine (Path.GetTempPath (), fileName);
            File.WriteAllBytes (tempFilePath, pdfBytes);
            webView.Source = new Uri (tempFilePath);
        }
    }
}
