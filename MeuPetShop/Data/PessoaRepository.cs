using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class PessoaRepository: IPessoaRepository
    {
        public Models.Tipo GetTipo()
        {
            return new Models.Tipo();
        }
    }

    public interface IPessoaRepository
    {
        Models.Tipo GetTipo();
    }
}

