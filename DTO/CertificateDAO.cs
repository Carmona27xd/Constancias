using Constancias.Connection;
using Constancias.POCO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Constancias.DTO {
    internal class CertificateDAO {
        private static string stringConnection = DBConnection.getStringConnection ();

        public static List<Certificate> GetCertificates () {
            List<Certificate> certificates = new List<Certificate> ();
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                sqlConnection.Open ();
                string query = "SELECT crt.IdCertifcade, crtty.Type, CONCAT(empl.FirstName, ' ', empl.MiddleName) AS ProfesorName, " +
                               "crt.DateApplied AS DateEmited " +
                               "FROM Certificade crt " +
                               "LEFT JOIN CertificadeType crtty ON crt.IdCertifiedType = crtty.IdCertificadeType " +
                               "LEFT JOIN Employee empl ON crt.IdProfesor = empl.IdEmployee;";

                using (SqlCommand command = new SqlCommand (query, sqlConnection)) {
                    using (SqlDataReader reader = command.ExecuteReader ()) {
                        while (reader.Read ()) {
                            Certificate certificate = new Certificate {
                                idCertificate = reader.GetInt32 (0),
                                Type = reader.GetString (1),
                                ProfesorName = reader.GetString (2),
                                DateEmited = reader.GetDateTime (3)
                            };
                            certificates.Add (certificate);
                        }
                    }
                }
            }
            
            return certificates; // Devuelve la lista de certificados
        }
    }
}
