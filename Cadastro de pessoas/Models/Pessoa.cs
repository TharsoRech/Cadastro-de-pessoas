using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro_de_pessoas.Models { 

    public class Pessoa 
    {

        public string Id { get; set; }


        public string Nome { get; set; }


        public string DataDeNascimento { get; set; }


        public string Ativo { get; set; }
    }
}
