using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_pessoas.Models
{
    public class Endereco:Entity
    {

        public Guid PessoaId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Pessoa Pessoa { get; set; }

        public string Logradouro{ get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }

        public string Estado { get; set; }


    }
}
