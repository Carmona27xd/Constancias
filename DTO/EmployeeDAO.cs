using Constancias.Connection;
using Constancias.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constancias.DTO
{
    internal class EmployeeDAO
    {
        string stringConnection = DBConnection.getStringConnection();

        public Employee logIn(string email, string password)
        {
            Employee employee = null;
            using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
            {
                sqlConnection.Open();
                string query = "SELECT IdEmployee, Tuition, FirstName, MiddleName, LastName, Email, Password, " +
                       "IdRole, IdContractType, IdProfesorCategory FROM Employee " +
                       "WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        IdEmployee = reader.GetInt32(0),
                        Tuition = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        MiddleName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Email = reader.GetString(5),
                        Password = reader.GetString(6),
                        IdRole = reader.GetInt32(7),
                        IdContractType = reader.GetInt32(8),
                        IdProfesorCategory = reader.GetInt32(9)
                    };
                }
            }
            return employee;
        }
    }
}
