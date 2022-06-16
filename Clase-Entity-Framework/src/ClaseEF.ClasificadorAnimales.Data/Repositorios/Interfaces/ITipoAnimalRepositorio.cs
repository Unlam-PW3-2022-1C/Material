using ClaseEF.ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEF.ClasificadorAnimales.Data.Repositorios
{
    public interface ITipoAnimalRepositorio
    {
        List<TipoAnimal> ObtenerTodos();
        void Insertar(TipoAnimal entidad);
        void SaveChanges();
    }
}
