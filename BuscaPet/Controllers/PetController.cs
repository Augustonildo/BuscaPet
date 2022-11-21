using BuscaPet.Domain;
using BuscaPet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _petService.GetPets();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PetController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
