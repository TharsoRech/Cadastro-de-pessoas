using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Models
{
    public class Animal:Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        public Pessoa Pessoa { get; set; }
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Genero Genero { get; set; }

        public Guid TipoId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Tipo Tipo { get; set; }

        public string Obs { get; set; }

        public IEnumerable<Evento> Eventos { get; set; }


    }
    
}
