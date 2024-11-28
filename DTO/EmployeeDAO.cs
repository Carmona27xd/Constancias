using Constancias.Connection;
using Constancias.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Constancias.DTO {
    internal class EmployeeDAO {
        string stringConnection = DBConnection.getStringConnection ();

        public Employee LogIn (string email, string password) {
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                sqlConnection.Open ();
                string query =
                    "SELECT e.IdEmployee, e.Tuition, e.FirstName, e.MiddleName, e.LastName, e.Gender, e.Email, e.Password, " +
                    "er.IdEmployeeRole, er.Role, ect.IdContractType, ect.Type, epc.IdProfesorCategory, epc.Category FROM Employee e " +
                    "LEFT JOIN EmployeeRole er ON e.IdRole = er.IdEmployeeRole " +
                    "LEFT JOIN EmployeeContractType ect ON e.IdContractType = ect.IdContractType " +
                    "LEFT JOIN EmployeeProfesorCategory epc ON e.IdProfesorCategory = epc.IdProfesorCategory " +
                    "WHERE e.Email = @Email AND e.Password = @Password;";
                using (SqlCommand command = new SqlCommand (query, sqlConnection)) {
                    command.Parameters.AddWithValue ("@Email", email);
                    command.Parameters.AddWithValue ("@Password", password);
                    using (SqlDataReader reader = command.ExecuteReader ()) {
                        if (reader.Read ()) {
                            return new Employee {
                                IdEmployee = reader.GetInt32 (0),
                                Tuition = reader.GetString (1),
                                FirstName = reader.GetString (2),
                                MiddleName = reader.GetString (3),
                                LastName = reader.GetString (4),
                                Gender = reader.GetString (5),
                                Email = reader.GetString (6),
                                Password = reader.GetString (7),
                                IdRole = reader.GetInt32 (8),
                                Rol = reader.GetString (9),
                                IdContractType = reader.GetInt32 (10),
                                ContractType = reader.GetString (11),
                                IdProfesorCategory = reader.GetInt32 (12),
                                ProfesorCategory = reader.GetString (13)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Employee> GetProfesor () {
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                sqlConnection.Open ();
                string query =
                    "SELECT e.IdEmployee, e.Tuition, e.FirstName, e.MiddleName, e.LastName, e.Gender, e.Email, e.Password, " +
                    "er.IdEmployeeRole, er.Role, ect.IdContractType, ect.Type, epc.IdProfesorCategory, epc.Category FROM Employee e " +
                    "LEFT JOIN EmployeeRole er ON e.IdRole = er.IdEmployeeRole" +
                    "LEFT JOIN EmployeeContractType ect ON e.IdContractType = ect.IdContractType" +
                    "LEFT JOIN EmployeeProfesorCategory epc ON e.IdProfesorCategory = epc.IdProfesorCategory;";
                SqlCommand command = new SqlCommand (query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader ();
                List<Employee> employees = new List<Employee> ();
                while (reader.Read ()) {
                    employees.Add (new Employee {
                        IdEmployee = reader.GetInt32 (0),
                        Tuition = reader.GetString (1),
                        FirstName = reader.GetString (2),
                        MiddleName = reader.GetString (3),
                        LastName = reader.GetString (4),
                        Gender = reader.GetString (5),
                        Email = reader.GetString (6),
                        Password = reader.GetString (7),
                        IdRole = reader.GetInt32 (8),
                        Rol = reader.GetString (9),
                        IdContractType = reader.GetInt32 (10),
                        ContractType = reader.GetString (11),
                        IdProfesorCategory = reader.GetInt32 (12),
                        ProfesorCategory = reader.GetString (13)
                    });
                }
                return employees;
            }
        }

        public bool InsertEmployee (Employee employee) {
            using (SqlConnection sqlConnection = new SqlConnection (stringConnection)) {
                bool isInserted = false;
                try {
                    sqlConnection.Open ();
                    string query =
                        "INSERT INTO Employee (Tuition, FirstName, MiddleName, LastName, Gender, Email, Password, " +
                        "IdRole, IdContractType, IdProfesorCategory, IdCareer) " +
                        "VALUES (@Tuition, @FirstName, @MiddleName, @LastName, @Gender, @Email, @Password, @IdRole, @IdContractType, @IdProfesorCategory, @IdCareer);";
                    using (SqlCommand command = new SqlCommand (query, sqlConnection)) {
                        command.Parameters.AddWithValue ("@Tuition", employee.Tuition);
                        command.Parameters.AddWithValue ("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue ("@MiddleName", employee.MiddleName);
                        command.Parameters.AddWithValue ("@LastName", employee.LastName);
                        command.Parameters.AddWithValue ("@Gender", employee.Gender);
                        command.Parameters.AddWithValue ("@Email", employee.Email);
                        command.Parameters.AddWithValue ("@Password", employee.Password);
                        command.Parameters.AddWithValue ("@IdRole", employee.IdRole);
                        command.Parameters.AddWithValue ("@IdContractType", employee.IdContractType);
                        command.Parameters.AddWithValue ("@IdProfesorCategory", employee.IdProfesorCategory);
                        if (employee.IdCareer <=0 || employee.IdCareer == null) {
                            command.Parameters.AddWithValue ("@IdCareer", DBNull.Value);
                        } else {
                            command.Parameters.AddWithValue ("@IdCareer", employee.IdCareer);
                        }

                        int rowsAffected = command.ExecuteNonQuery ();
                        isInserted = rowsAffected > 0;
                    }
                } catch (Exception ex) {
                    Console.WriteLine ($"Error al insertar empleado: {ex.Message}");
                }
                return isInserted;
            }
        }

    }
}
