using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_pessoas.Models
{
    public class Tipo:Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
    
}
