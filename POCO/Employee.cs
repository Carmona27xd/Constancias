using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constancias.POCO
{
    internal class Employee
    {
        private int idEmployee;
        private string tuition;
        private string firstName;
        private string middleName;
        private string lastName;
        private string email;
        private string password;
        private int idRole;
        private int idContractType;
        private int idProfesorCategory;

        // Getter and Setter for idEmployee
        public int IdEmployee
        {
            get { return idEmployee; }
            set { idEmployee = value; }
        }

        // Getter and Setter for tuition
        public string Tuition
        {
            get { return tuition; }
            set { tuition = value; }
        }

        // Getter and Setter for firstName
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        // Getter and Setter for middleName
        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        // Getter and Setter for lastName
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // Getter and Setter for email
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Getter and Setter for password
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        // Getter and Setter for idRole
        public int IdRole
        {
            get { return idRole; }
            set { idRole = value; }
        }

        // Getter and Setter for idContractType
        public int IdContractType
        {
            get { return idContractType; }
            set { idContractType = value; }
        }

        // Getter and Setter for idProfesorCategory
        public int IdProfesorCategory
        {
            get { return idProfesorCategory; }
            set { idProfesorCategory = value; }
        }

    }
}
