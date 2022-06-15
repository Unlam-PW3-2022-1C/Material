using ClaseEF.ClasificadorAnimales.Data.EF;
using ClaseEF.ClasificadorAnimales.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEF.ClasificadorAnimales.Servicios.Servicios
{
    public class TipoAnimalServicio : ITipoAnimalServicio
    {
        ITipoAnimalRepositorio _tipoAnimalRepositorio;
        public TipoAnimalServicio(ITipoAnimalRepositorio tipoAnimalRepositorio)
        {
            _tipoAnimalRepositorio = tipoAnimalRepositorio;
        }
        public List<TipoAnimal> ObtenerTodos()
        {
            return _tipoAnimalRepositorio.ObtenerTodos();
        }
    }
}
