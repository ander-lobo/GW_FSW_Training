using Gcsb.Connect.Training.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string BirthDate { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int PostalCode { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool IsActive { get; private set; }

        public Customer(string name, string birthDate, string rg, string cpf, string address, string city, string state, int postalCode)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            Rg = rg;
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            RegistrationDate = DateTime.Today;
            IsActive = true;

            Validate(this, new CustomerValidator());
        }
        public Customer(Guid id, string name, string birthDate, string rg, string cpf, string address, string city, string state, int postalCode)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Rg = rg;
            Cpf = Regex.Replace(cpf, "[^0-9]", "");
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            RegistrationDate = DateTime.Today;
            IsActive = true;

            Validate(this, new CustomerValidator());
        }
    }
}
