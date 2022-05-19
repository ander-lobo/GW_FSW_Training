using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Tests.Builders
{
    public class CustomerBuilder
    {
        public Guid Id;
        public string Name;
        public string BirthDate;
        public string Rg;
        public string Cpf;
        public string Address;
        public string City;
        public string State;
        public int PostalCode;

        public static CustomerBuilder New()
        {
            return new CustomerBuilder
            {
                Id = Guid.NewGuid(),
                Name = "João Das Neves",
                BirthDate = "01/01/1990",
                Rg = "12345678",
                Cpf = "123.456.789-01",
                Address = "Rua de Casa, 10",
                City = "Itu",
                State = "SP",
                PostalCode = 13300005
            };
        }
        public CustomerBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public CustomerBuilder WithName(string name)
        {
            Name = name;
            return this;
        }
        public CustomerBuilder WithBirthDate(string birthDate)
        {
            BirthDate = birthDate;
            return this;
        }
        public CustomerBuilder WithRg(string rg)
        {
            Rg = rg;
            return this;
        }
        public CustomerBuilder WithCpf(string cpf)
        {
            Cpf = cpf;
            return this;
        }
        public CustomerBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }
        public CustomerBuilder WithCity(string city)
        {
            City = city;
            return this;
        }
        public CustomerBuilder WithState(string state)
        {
            State = state;
            return this;
        }
        public CustomerBuilder WithPostalCode(int postalCode)
        {
            PostalCode = postalCode;
            return this;
        }
        public Customer Build()
        {
            return new Customer(Id, Name, BirthDate, Rg, Cpf, Address, City, State, PostalCode);
        }
    }
}
