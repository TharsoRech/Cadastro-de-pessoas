using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class AnimalRepository: IAnimalRepository
    {
        public Models.Animal GetAnimal()
        {
            return new Models.Animal();
        }
    }

    public interface IAnimalRepository
    {
        Models.Animal GetAnimal();
    }
}

