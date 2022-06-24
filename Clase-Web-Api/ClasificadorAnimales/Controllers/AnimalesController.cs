using ClasificadorAnimales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClasificadorAnimales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesController : ControllerBase
    {
        private static List<Animal> Animales { get; set; } = new List<Animal>();
        // GET: api/<AnimalesController>
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return Animales;
        }

        // GET api/<AnimalesController>/5
        [HttpGet("{id}")]
        public Animal Get(int id)
        {
            return Animales.FirstOrDefault(a=> a.IdAnimal == id);
        }

        // POST api/<AnimalesController>
        [HttpPost]
        public void Post([FromBody] Animal model)
        {
            int maxId = Animales.Count == 0 ? 0 : Animales.Max(a => a.IdAnimal);
            model.IdAnimal = maxId + 1;
            Animales.Add(model);
        }

        // PUT api/<AnimalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal model)
        {
            Animal animal = Animales.FirstOrDefault(a => a.IdAnimal == id);
            animal.EdadPromedio = model.EdadPromedio;
            animal.NombreEspecie = model.NombreEspecie;
            animal.PesoPromedio = model.PesoPromedio;
        }

        // DELETE api/<AnimalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Animales.RemoveAll(a => a.IdAnimal == id);
        }
    }
}
