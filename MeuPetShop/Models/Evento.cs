using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_pessoas.Models
{
    public class Evento:Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        public string DataCriada { get; set; }

        public string CriadoPor { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Concluido { get; set; }

        public Status Status { get; set; }

        public Atendente Atendente { get; set; }

        public Guid AtendenteId { get; set; }

        public Guid AnimalId { get; set; }

        public Animal Animal { get; set; }



    }

    
}
