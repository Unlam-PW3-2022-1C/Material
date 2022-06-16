using ClaseEF.ClasificadorAnimales.Data.EF;
using System.Collections.Generic;

namespace ClaseEF.ClasificadorAnimales.Servicios.Servicios
{
    public interface ITipoAnimalServicio
    {
        List<TipoAnimal> ObtenerTodos();
        void Insertar(TipoAnimal entidad);
    }
}
