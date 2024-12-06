using ClinVet.Entities;
using ClinVet.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ClinVet.Controllers
{
    [Route("api/encontros")]
    [ApiController]
    public class EncontroController : ControllerBase
    {
        private readonly ClinVetDbContext _context;

        public EncontroController(ClinVetDbContext context)
        {
            _context = context;
        }

        // GET: api/encontros
        [HttpGet]
        public IActionResult GetAll()
        {
            var encontros = _context.Encontros.Where(e => !e.IsDeleted).ToList();
            return Ok(encontros);
        }

        // GET: api/encontros/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var encontro = _context.Encontros
                .SingleOrDefault(e => e.Id == id && !e.IsDeleted);

            if (encontro == null)
            {
                return NotFound();
            }
            return Ok(encontro);
        }

        // POST: api/encontros
        [HttpPost]
        public IActionResult Post(Encontro encontro)
        {
            if (encontro == null)
            {
                return BadRequest("Dados do encontro estão ausentes.");
            }
            // Busca o proprietário pelo ID
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == encontro.VeterinarioId);

            if (veterinario == null)
            {
                return BadRequest("Veterinario não encontrado.");
            }
            // Inicializar lista para evitar erros
            encontro.Tratamentos = encontro.Tratamentos ?? new List<Tratamento>();
            _context.Encontros.Add(encontro);
            return CreatedAtAction(nameof(GetById), new { id = encontro.Id }, encontro);
        }

        // PUT: api/encontros/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Encontro input)
        {
            var encontro = _context.Encontros
                .SingleOrDefault(e => e.Id == id && !e.IsDeleted);

            if (encontro == null)
            {
                return NotFound();
            }
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == encontro.VeterinarioId);

            if (veterinario == null)
            {
                return BadRequest("Veterinario não encontrado.");
            }
            encontro.Update(input.Nome, input.HoraInicio, input.TipoConsulta, input.ValorPagoConsulta, input.Descricao);
            return NoContent();
        }

        // DELETE: api/encontros/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var encontro = _context.Encontros
                .SingleOrDefault(e => e.Id == id && !e.IsDeleted);

            if (encontro == null)
            {
                return NotFound();
            }

            encontro.Delete();
            return NoContent();
        }
    }
}
