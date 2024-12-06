using ClinVet.Entities;
using ClinVet.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ClinVet.Controllers
{
    [Route("api/agendamentos")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly ClinVetDbContext _context;

        public AgendamentoController(ClinVetDbContext context)
        {
            _context = context;
        }

        // GET: api/agendamentos
        [HttpGet]
        public IActionResult GetAll()
        {
            var agendamentos = _context.Agendamentos
                .Where(a => !a.IsDeleted)
                .ToList();

            return Ok(agendamentos);
        }

        // GET: api/agendamentos/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var agendamento = _context.Agendamentos
                .SingleOrDefault(a => a.Id == id && !a.IsDeleted);

            if (agendamento == null)
            {
                return NotFound();
            }

            return Ok(agendamento);
        }

        // POST: api/agendamentos
        [HttpPost]
        public IActionResult Post(Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest("Dados do agendamento estão ausentes.");
            }
            // Busca o veterinario pelo ID
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == agendamento.VeterinarioId);

            if (veterinario == null)
            {
                return BadRequest("Veterinario não encontrado.");
            }
            _context.Agendamentos.Add(agendamento);

            return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, agendamento);
        }

        // PUT: api/agendamentos/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Agendamento input)
        {
            // Comparação explícita
            if (id != input.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }
            var agendamento = _context.Agendamentos
                .SingleOrDefault(a => a.Id == id && !a.IsDeleted);

            if (agendamento == null)
            {
                return NotFound();
            }

            if (agendamento.VeterinarioId != input.VeterinarioId)
            {
                return BadRequest("O ID informado não corresponde ao ID do Veterinario.");
            }

            agendamento.Update(
                input.DataInicio,
                input.DataFim,
                input.Titulo,
                input.Descricao,
                input.NomeCliente,
                input.TelefoneCliente
            );

            return NoContent();
        }

        // DELETE: api/agendamentos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var agendamento = _context.Agendamentos
                .SingleOrDefault(a => a.Id == id && !a.IsDeleted);

            if (agendamento == null)
            {
                return NotFound();
            }

            agendamento.Delete();
            return NoContent();
        }
    }
}
