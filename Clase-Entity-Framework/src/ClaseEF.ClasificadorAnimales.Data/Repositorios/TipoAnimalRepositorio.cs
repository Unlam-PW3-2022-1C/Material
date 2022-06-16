using ClaseEF.ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEF.ClasificadorAnimales.Data.Repositorios
{
    public class TipoAnimalRepositorio : BaseRepositorio, ITipoAnimalRepositorio
    {
        public TipoAnimalRepositorio(_20221CPracticaEFContext ctx) : base(ctx)
        {
        }

        public void Insertar(TipoAnimal entidad)
        {
            int idTipoAnimal = _Contexto.Animals.Max(a => a.IdTipoAnimal) + 1;
            entidad.IdTipoAnimal = idTipoAnimal;
            _Contexto.TipoAnimals.Add(entidad);
        }

        public List<TipoAnimal> ObtenerTodos()
        {
            return _Contexto.TipoAnimals.ToList();
        }
    }
}
