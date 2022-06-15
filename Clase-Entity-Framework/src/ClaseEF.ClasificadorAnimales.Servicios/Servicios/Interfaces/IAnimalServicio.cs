using ClaseEF.ClasificadorAnimales.Data.EF;
using System.Collections.Generic;

namespace ClaseEF.ClasificadorAnimales.Servicios.Servicios
{
    public interface IAnimalServicio
    {
        void Insertar(Animal entidad);
        List<Animal> ObtenerPorTipo(int idTipoAnimal);
        List<Animal> ObtenerTodos();
    }
}
