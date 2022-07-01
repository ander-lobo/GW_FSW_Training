using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Webapi.UseCases.Customers.Request
{
    public class CustomerRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name is too short.")]
        [MaxLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        [MinLength(3, ErrorMessage = "BirthDate is too short.")]
        [MaxLength(10, ErrorMessage = "BirthDate is too long.")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Rg is required.")]
        [MinLength(3, ErrorMessage = "Rg is too short.")]
        [MaxLength(20, ErrorMessage = "Rg is too long.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Cpf is required.")]
        [MinLength(11, ErrorMessage = "Cpf is too short.")]
        [MaxLength(14, ErrorMessage = "Cpf is too long.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MinLength(3, ErrorMessage = "Address is too short.")]
        [MaxLength(200, ErrorMessage = "Address is too long.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MinLength(3, ErrorMessage = "City is too short.")]
        [MaxLength(30, ErrorMessage = "City is too long.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "PostalCode is required.")]
        public int PostalCode { get; set; }
    }
}
