using ClaseEF.ClasificadorAnimales.Data.EF;
using ClaseEF.ClasificadorAnimales.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEF.ClasificadorAnimales.Servicios.Servicios
{
    public class AnimalServicio : IAnimalServicio
    {
        IAnimalRepositorio _animalRepositorio;
        public AnimalServicio(IAnimalRepositorio animalRepositorio)
        {
            _animalRepositorio = animalRepositorio;
        }
        public void Insertar(Animal entidad)
        {
            _animalRepositorio.Insertar(entidad);
            _animalRepositorio.SaveChanges();
        }

        public List<Animal> ObtenerPorTipo(int idTipoAnimal)
        {
            return _animalRepositorio.ObtenerPorTipo(idTipoAnimal);
        }

        public List<Animal> ObtenerTodos()
        {
            return _animalRepositorio.ObtenerTodos();
        }
    }
}
