using Constancias.Connection;
using Constancias.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Constancias.DTO {
    internal class EmployeeDAO {
        string stringConnection = DBConnection.getStringConnection ();

        public Employee logIn (string email, string password) {
            Employee employee = null;
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                sqlConnection.Open ();
                string query = "SELECT IdEmployee, Tuition, FirstName, MiddleName, LastName, Email, Password, " +
                       "IdRole, IdContractType, IdProfesorCategory FROM Employee " +
                       "WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand (query, sqlConnection);
                command.Parameters.AddWithValue ("@email", email);
                command.Parameters.AddWithValue ("@Password", password);
                SqlDataReader reader = command.ExecuteReader ();

                if (reader.Read ()) {
                    employee = new Employee {
                        IdEmployee = reader.GetInt32 (0),
                        Tuition = reader.GetString (1),
                        FirstName = reader.GetString (2),
                        MiddleName = reader.GetString (3),
                        LastName = reader.GetString (4),
                        Email = reader.GetString (5),
                        Password = reader.GetString (6),
                        IdRole = reader.GetInt32 (7),
                        IdContractType = reader.GetInt32 (8),
                        IdProfesorCategory = reader.GetInt32 (9)
                    };
                }
            }
            return employee;
        }

        public List<Employee> GetProfessors () {
            List<Employee> employees = new List<Employee> ();
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                sqlConnection.Open ();
                string query = "SELECT IdEmployee, Tuition, FirstName, MiddleName, LastName, Email, Password, " +
                       "IdRole, IdContractType, IdProfesorCategory FROM Employee " +
                       "WHERE IdRole = 3";
                SqlCommand command = new SqlCommand (query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader ();
                while (reader.Read ()) {
                    Employee employee = new Employee ();
                    employee = new Employee {
                        IdEmployee = reader.GetInt32 (0),
                        Tuition = reader.GetString (1),
                        FirstName = reader.GetString (2),
                        MiddleName = reader.GetString (3),
                        LastName = reader.GetString (4),
                        Email = reader.GetString (5),
                        Password = reader.GetString (6),
                        IdRole = reader.GetInt32 (7),
                        IdContractType = reader.GetInt32 (8),
                        IdProfesorCategory = reader.GetInt32 (9)
                    };

                    employees.Add (employee);
                }

            }
            return employees;
        }

        public bool InsertEmployee (Employee employee) {
            bool isInserted = false;
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                try {
                    sqlConnection.Open ();
                    string query = "INSERT INTO Employee (Tuition, FirstName, MiddleName, LastName, Email, Password, " +
                                   "IdRole, IdContractType, IdProfesorCategory) " +
                                   "VALUES (@Tuition, @FirstName, @MiddleName, @LastName, @Email, @Password, @IdRole, @IdContractType, @IdProfesorCategory)";

                    using (SqlCommand command = new SqlCommand (query, sqlConnection)) {
                        // Agregar parámetros
                        command.Parameters.AddWithValue ("@Tuition", employee.Tuition);
                        command.Parameters.AddWithValue ("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue ("@MiddleName", employee.MiddleName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue ("@LastName", employee.LastName);
                        command.Parameters.AddWithValue ("@Email", employee.Email);
                        command.Parameters.AddWithValue ("@Password", employee.Password);
                        command.Parameters.AddWithValue ("@IdRole", employee.IdRole);
                        command.Parameters.AddWithValue ("@IdContractType", employee.IdContractType);
                        command.Parameters.AddWithValue ("@IdProfesorCategory", employee.IdProfesorCategory);

                        // Ejecutar el comando
                        int rowsAffected = command.ExecuteNonQuery ();
                        isInserted = rowsAffected > 0;
                    }
                } catch (Exception ex) {
                    // Manejar errores
                    Console.WriteLine ($"Error al insertar empleado: {ex.Message}");
                }
            }
            return isInserted;
        }

    }
}
