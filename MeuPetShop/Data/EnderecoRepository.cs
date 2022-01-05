using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Models.Endereco GetEndereco()
        {
            return new Models.Endereco();
        }
    }

    public interface IEnderecoRepository
    {
        Models.Endereco GetEndereco();
    }
}

