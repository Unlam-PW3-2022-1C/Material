using ClaseEF.ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEF.ClasificadorAnimales.Data.Repositorios
{
    public interface IAnimalRepositorio
    {
        void Insertar(Animal entidad);
        List<Animal> ObtenerTodos();
        void SaveChanges();
    }
}
