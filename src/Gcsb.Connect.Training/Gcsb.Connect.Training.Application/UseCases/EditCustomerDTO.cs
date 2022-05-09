using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.UseCases
{
    public class EditCustomerDTO
    {
        [Required]
        public Guid Id { get; set; }

        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 letras.")]
        [MaxLength(100, ErrorMessage = "Nome muito longo.")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "Favor inserir uma data válida.")]
        [MaxLength(10, ErrorMessage = "Favor inserir uma data válida.")]
        public string BirthDate { get; set; }

        [MinLength(3, ErrorMessage = "Favor inserir um Rg válido.")]
        [MaxLength(20, ErrorMessage = "Favor inserir um Rg válido.")]
        public string Rg { get; set; }

        [MinLength(3, ErrorMessage = "O endereço deve ter no mínimo 3 letras.")]
        [MaxLength(200, ErrorMessage = "Endereço muito longo.")]
        public string Address { get; set; }

        [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 letras.")]
        [MaxLength(30, ErrorMessage = "Endereço muito longo.")]
        public string City { get; set; }

        public string State { get; set; }

        public int PostalCode { get; set; }
    }
}
