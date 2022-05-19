using FluentValidation;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Domain.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.Id).NotEmpty().NotEqual(new Guid());
            RuleFor(r => r.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
            RuleFor(r => r.BirthDate).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(r => r.Rg).NotEmpty().NotNull().MaximumLength(12);
            RuleFor(r => r.Cpf).NotEmpty().NotNull().MinimumLength(11).MaximumLength(14);
            RuleFor(r => r.Address).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(r => r.City).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(r => r.State).NotEmpty().NotNull().MaximumLength(2);
            RuleFor(r => r.PostalCode).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
