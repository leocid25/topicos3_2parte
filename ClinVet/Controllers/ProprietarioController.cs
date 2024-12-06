using ClinVet.Persistence;
using Microsoft.AspNetCore.Mvc;
using ClinVet.Entities;
using System.Drawing;


namespace ClinVet.Controllers
{
        [Route("api/proprietarios")]
        [ApiController]
        public class ProprietarioController : ControllerBase
        {
            private readonly ClinVetDbContext _context;

            public ProprietarioController(ClinVetDbContext context)
            {
                _context = context;
            }

            // GET: api/proprietarios
            [HttpGet]
            public IActionResult GetAll()
            {
                var proprietarios = _context.Proprietarios.Where(p => !p.IsDelete).ToList();
                return Ok(proprietarios);
            }

            // GET: api/proprietarios/{id}
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var proprietario = _context.Proprietarios.SingleOrDefault(p => p.Id == id && !p.IsDelete);
                if (proprietario == null)
                {
                    return NotFound();
                }
                return Ok(proprietario);
            }

            // POST: api/proprietarios
            [HttpPost]
            public IActionResult Post(Proprietario proprietario)
            {
            if (proprietario == null)
            {
                return BadRequest("Dados do proprietario estão ausentes.");
            }
            // Inicializando a lista de Pets para evitar erros
            proprietario.Pets = proprietario.Pets ?? new List<Pet>();
            _context.Proprietarios.Add(proprietario);
                return CreatedAtAction(nameof(GetById), new { id = proprietario.Id }, proprietario);
            }

            // PUT: api/proprietarios/{id}
            [HttpPut("{id}")]
            public IActionResult Update(int id, Proprietario input)
            {
            // Comparação explícita
            if (id != input.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }
            var proprietario = _context.Proprietarios.SingleOrDefault(p => p.Id == id && !p.IsDelete);
                if (proprietario == null)
                {
                    return NotFound();
                }

                proprietario.Update(input.Nome, input.Cpf, input.Email, input.Telefone, input.Endereco);
                return NoContent();
            }

            // DELETE: api/proprietarios/{id}
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var proprietario = _context.Proprietarios.SingleOrDefault(p => p.Id == id && !p.IsDelete);
                if (proprietario == null)
                {
                    return NotFound();
                }

                proprietario.Delete();
                return NoContent();
            }
        }
    }
