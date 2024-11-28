using Constancias.POCO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;

namespace Constancias.Utils {
    public class ModifyWordTemplate {
        public static byte[] ParticipacionActualizacionEEProyectoIntegrador (Certificate newCertificate) {
            if (newCertificate?.Doc == null || newCertificate.Doc.Length == 0)
                throw new ArgumentException ("El documento base es inválido.");

            using (MemoryStream memoryStream = new MemoryStream (newCertificate.Doc)) {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open (memoryStream, true)) {
                    var body = wordDoc.MainDocumentPart.Document.Body;

                    // Recorrer y reemplazar solo el texto necesario
                    foreach (var paragraph in body.Descendants<Paragraph> ()) {
                        foreach (var text in paragraph.Descendants<Text> ()) {
                            text.Text = text.Text.Replace ("{{ProfesorG}}", newCertificate.Profesor.Gender.Equals ("H") ? "el profesor " : "la profesora ")
                                                 .Replace ("{{NombreDestinatario}}", newCertificate.Profesor.CompleteName)
                                                 .Replace ("{{ExperienciaEducativa}}", newCertificate.Profesor.EE)
                                                 .Replace ("{{Carrera}}", newCertificate.Profesor.Career)
                                                 .Replace ("{{fecha}}", DateTime.Now.ToString ("D"))
                                                 .Replace ("{{del profesor interesado}}", newCertificate.Profesor.Gender.Equals ("H") ? "del profesor interesado" : "de la profesora interesada")
                                                 .Replace ("{{dias}}", DateTime.Now.ToString ("d"))
                                                 .Replace ("{{mes}}", DateTime.Now.ToString ("MMMM"))
                                                 .Replace ("{{anio}}", DateTime.Now.ToString ("yyyy"));
                        }
                    }

                    wordDoc.MainDocumentPart.Document.Save ();
                }

                return memoryStream.ToArray ();
            }
        }

    }
}