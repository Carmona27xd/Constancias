using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Constancias.Connection {
    public class DBConnection {
        public static string connectionString = 
            ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public static string getStringConnection () {
            return connectionString;
        }

        public void openConnection () {
            using (SqlConnection connection = new SqlConnection (connectionString)) {
                try {
                    connection.Open ();
                    MessageBox.Show ("Conexion exitosa");
                } catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }
            }
        }
    }
}
