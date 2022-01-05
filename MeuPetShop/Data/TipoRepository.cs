using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class TipoRepository : ITipoRepository
    {
        public Models.Tipo GetTipo()
        {
            return new Models.Tipo();
        }
    }

    public interface ITipoRepository
    {
        Models.Tipo GetTipo();
    }
}

