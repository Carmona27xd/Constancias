using Constancias.POCO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;

namespace Constancias.Utils {
    public class ModifyWordTemplate {
        public static byte[] ParticipacionActualizacionEEProyectoIntegrador (Certificate newCertificate) {
            using (MemoryStream memoryStream = new MemoryStream (newCertificate.Doc)) {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open (memoryStream, true)) {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    string docText = body.InnerText;

                    docText = docText.Replace ("{{ProfesorG}}", newCertificate.Profesor.Gender.Equals ("H") ? "el profesor " : "la profesora ");
                    docText = docText.Replace ("{{NombreDestinatario}}", newCertificate.Profesor.CompleteName);
                    docText = docText.Replace ("{{ExperienciaEducativa}}", newCertificate.Profesor.EE);
                    docText = docText.Replace ("{{Carrera}}", newCertificate.Profesor.Career);
                    docText = docText.Replace ("{{fecha}}", DateTime.Now.ToString ("D"));
                    docText = docText.Replace ("{{del profesor interesado}}", newCertificate.Profesor.Gender.Equals ("H") ? "del profesor interesado" : "de la profesora interesada");
                    docText = docText.Replace ("{{dias}}", DateTime.Now.ToString ("d"));
                    docText = docText.Replace ("{{mes}}", DateTime.Now.ToString ("MMMM"));
                    docText = docText.Replace ("{{anio}}", DateTime.Now.ToString ("yyy"));


                    body.RemoveAllChildren<Paragraph> ();
                    body.Append (new Paragraph (new Run (new Text (docText))));
                    wordDoc.MainDocumentPart.Document.Save ();
                }
                return memoryStream.ToArray ();
            }
        }
    }
}