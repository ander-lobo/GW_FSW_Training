using FluentAssertions;
using Gcsb.Connect.Training.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gcsb.Connect.Training.Tests.Cases.Domain
{
    public class CustomerDomainTest
    {
        [Fact(DisplayName = "Should Create Customer Domain")]
        public void ShouldCreateCustomerDomain()
        {
            var customer = CustomerBuilder.New().Build();
            customer.ValidationResult.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Should Not Create Customer Domain With Invalid Id")]
        public void ShouldNotCreateCustomerDomainWithInvalidId()
        {
            var customer = CustomerBuilder.New().WithId(new Guid()).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without Name")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutName(string name)
        {
            var customer = CustomerBuilder.New().WithName(name).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without BirthDate")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutBirthDate(string birthDate)
        {
            var customer = CustomerBuilder.New().WithBirthDate(birthDate).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without Rg")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutRg(string rg)
        {
            var customer = CustomerBuilder.New().WithRg(rg).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without Cpf")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutCpf(string cpf)
        {
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without Address")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutAddress(string address)
        {
            var customer = CustomerBuilder.New().WithAddress(address).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without City")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutCity(string city)
        {
            var customer = CustomerBuilder.New().WithCity(city).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without State")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCustomerDomainWithoutState(string state)
        {
            var customer = CustomerBuilder.New().WithState(state).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory(DisplayName = "Should Not Create Customer Domain Without PostalCode")]
        [InlineData(0)]
        [InlineData(-1)]
        public void ShouldNotCreateCustomerDomainWithoutPostalCode(int postalCode)
        {
            var customer = CustomerBuilder.New().WithPostalCode(postalCode).Build();
            customer.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
