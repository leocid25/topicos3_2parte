using ClinVet.Entities;
using ClinVet.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ClinVet.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ClinVetDbContext _context;

        public PetController(ClinVetDbContext context)
        {
            _context = context;
        }

        // GET: api/pets
        [HttpGet]
        public IActionResult GetAll()
        {
            var pets = _context.Pets.Where(p => !p.IsDeleted).ToList();
            return Ok(pets);
        }

        // GET: api/pets/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id && !p.IsDeleted);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        // POST: api/pets
        [HttpPost]
        public IActionResult Post(Pet pet)
        {
            if (pet == null)
                return BadRequest("Dados do pet estão ausentes.");

            var proprietario = _context.Proprietarios
                .FirstOrDefault(p => p.Id == pet.ProprietarioId && !p.IsDelete);

            if (proprietario == null)
                return BadRequest("Proprietário não encontrado.");

            pet.Encontros ??= new List<Encontro>();

            // Validate the pet object before adding
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Pets.Add(pet);

            return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        // PUT: api/pets/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pet input)
        {
            // Comparação explícita
            if (id != input.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id && !p.IsDeleted);
            if (pet == null)
            {
                return NotFound();
            }
            var proprietario = _context.Proprietarios.FirstOrDefault(p => p.Id == pet.ProprietarioId);

            if (proprietario == null)
            {
                return BadRequest("Proprietário não encontrado.");
            }

            pet.Update(input.Nome, input.Especie, input.Raca, input.DataNascimento, input.Genero);
            return NoContent();
        }

        // DELETE: api/pets/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id && !p.IsDeleted);
            if (pet == null)
            {
                return NotFound();
            }

            pet.Delete();
            return NoContent();
        }
    }
}
