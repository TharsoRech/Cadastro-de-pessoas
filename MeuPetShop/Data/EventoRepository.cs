using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class EventoRepository : IEventoRepository
    {
        public Models.Evento GetEvento()
        {
            return new Models.Evento();
        }
    }

    public interface IEventoRepository
    {
        Models.Evento GetEvento();
    }
}

