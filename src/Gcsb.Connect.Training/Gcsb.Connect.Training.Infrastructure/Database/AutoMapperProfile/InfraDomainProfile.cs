using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gcsb.Connect.Training.Application.UseCases;
using Gcsb.Connect.Training.Domain.Entities;

namespace Gcsb.Connect.Training.Infrastructure.Database.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Customer, Entities.Customer>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, EditCustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
        }
    }
}
