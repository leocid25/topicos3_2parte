using ClinVet.Persistence;
using Microsoft.AspNetCore.Mvc;
using ClinVet.Entities;

namespace ClinVet.Controllers
{
    [Route("api/tratamentos")]
    [ApiController]
    public class TratamentoController : ControllerBase
    {
        private readonly ClinVetDbContext _context;

        public TratamentoController(ClinVetDbContext context)
        {
            _context = context;
        }

        // GET: api/tratamentos
        [HttpGet]
        public IActionResult GetAll()
        {
            var tratamentos = _context.Tratamentos.Where(t => !t.IsDeleted).ToList();
            return Ok(tratamentos);
        }

        // GET: api/tratamentos/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tratamento = _context.Tratamentos.SingleOrDefault(t => t.Id == id && !t.IsDeleted);
            if (tratamento == null)
            {
                return NotFound();
            }
            return Ok(tratamento);
        }

        // POST: api/tratamentos
        [HttpPost]
        public IActionResult Post(Tratamento tratamento)
        {
            if (tratamento == null)
            {
                return BadRequest("Dados do tratamento estão ausentes.");
            }
            var encontro = _context.Encontros.FirstOrDefault(e => e.Id == tratamento.EncontroId);

            if (encontro == null)
            {
                return BadRequest("Encontro não encontrado.");
            }
            _context.Tratamentos.Add(tratamento);
            return CreatedAtAction(nameof(GetById), new { id = tratamento.Id }, tratamento);
        }

        // PUT: api/tratamentos/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Tratamento input)
        {
            var tratamento = _context.Tratamentos.SingleOrDefault(t => t.Id == id && !t.IsDeleted);
            if (tratamento == null)
            {
                return NotFound();
            }
            var encontro = _context.Encontros.FirstOrDefault(e => e.Id == tratamento.EncontroId);

            if (encontro == null)
            {
                return BadRequest("Encontro não encontrado.");
            }
            tratamento.Update(input.Descricao, input.HoraInicio, input.HoraTermino, input.ValorPagoTratamento);
            return NoContent();
        }

        // DELETE: api/tratamentos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tratamento = _context.Tratamentos.SingleOrDefault(t => t.Id == id && !t.IsDeleted);
            if (tratamento == null)
            {
                return NotFound();
            }

            tratamento.Delete();
            return NoContent();
        }
    }
}
