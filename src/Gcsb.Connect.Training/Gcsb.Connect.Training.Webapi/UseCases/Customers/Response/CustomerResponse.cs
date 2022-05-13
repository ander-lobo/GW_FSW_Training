using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Webapi.UseCases.Customers.Response
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int PostalCode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        public CustomerResponse(Guid id, string name, string birthDate, string rg, string cpf, string address, string city, string state, int postalCode, DateTime registrationDate, bool isActive)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Rg = rg;
            Cpf = cpf;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            RegistrationDate = registrationDate;
            IsActive = isActive;
        }
    }
}
