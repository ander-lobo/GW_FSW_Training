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
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 letras.")]
        [MaxLength(100, ErrorMessage = "Nome muito longo.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [MinLength(3, ErrorMessage = "Favor inserir uma data válida.")]
        [MaxLength(10, ErrorMessage = "Favor inserir uma data válida.")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "O Rg é obrigatório.")]
        [MinLength(3, ErrorMessage = "Favor inserir um Rg válido.")]
        [MaxLength(20, ErrorMessage = "Favor inserir um Rg válido.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O Cpf é obrigatório.")]
        [MinLength(11, ErrorMessage = "Favor inserir um Cpf válido.")]
        [MaxLength(14, ErrorMessage = "Favor inserir um Cpf válido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [MinLength(3, ErrorMessage = "O endereço deve ter no mínimo 3 letras.")]
        [MaxLength(200, ErrorMessage = "Endereço muito longo.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 letras.")]
        [MaxLength(30, ErrorMessage = "Endereço muito longo.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O nome do estado é obrigatório.")]
        public string State { get; set; }

        [Required(ErrorMessage = "O cep é obrigatório.")]
        public int PostalCode { get; set; }
    }
}
