using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class AtendentesRepository: IAtendentesRepository
    {
        public Models.Atendente GetAtendente()
        {
            return new Models.Atendente();
        }
    }

    public interface IAtendentesRepository
    {
        Models.Atendente GetAtendente();
    }
}

