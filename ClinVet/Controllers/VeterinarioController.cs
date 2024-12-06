using ClinVet.Persistence;
using Microsoft.AspNetCore.Mvc;
using ClinVet.Entities;

namespace ClinVet.Controllers
{
    [Route("api/clinvet")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly ClinVetDbContext _context;
        public VeterinarioController(ClinVetDbContext context) {

            _context = context;

        }

        /// <summary>
        /// Retorna todos os vaterinarios cadastrados
        /// </summary>
        /// <remarks>
        /// Retorno:
        /// 
        /// GET
        ///   [
        ///     {
        ///       "id": 1,
        ///       "nome": "teste",
        ///       "email": "teste@gmail.com",
        ///       "telefone": "(63)99999-1111",
        ///       "cpf": "123.456.789-00",
        ///       "endereco": "Rua teste, número 05",
        ///       "especializacao": "Cirurgia geral",
        ///       "crmv": "123",
        ///       "isDeleted": false
        ///     }
        ///   ]
        ///
        /// </remarks>
        /// <response code ="200"> Retorna um IEnumerable de veterinarios cadastrados</response>
        /// <response code = "400">Se encontrar um erro</response>
        // GET: api/Veterinarios
        [HttpGet]
        public IActionResult GetAll()
        {
            var veterinarios = _context.Veterinarios.Where(v => !v.IsDeleted).ToList();
            return Ok(veterinarios);
        }

        /// <summary>
        /// Retorna um veterinário de acordo com o seu id
        /// </summary>
        /// <remarks>
        /// Retorno:
        /// 
        /// GET
        ///   [
        ///     {
        ///       "id": 1,
        ///       "nome": "teste",
        ///       "email": "teste@gmail.com",
        ///       "telefone": "(63)99999-1111",
        ///       "cpf": "123.456.789-00",
        ///       "endereco": "Rua teste, número 05",
        ///       "especializacao": "Cirurgia geral",
        ///       "crmv": "123",
        ///       "isDeleted": false
        ///     }
        ///   ]
        ///
        /// </remarks>
        /// <response code ="200"> Retorna um veterinario cadastrado</response>
        /// <response code = "400">Se encontrar um erro</response>
        // GET: api/Veterinarios/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var veterinario = _context.Veterinarios.SingleOrDefault(v => v.Id == id);
            if (veterinario == null)
            {
                return NotFound();
            }
            return Ok(veterinario);
        }

        /// <summary>
        /// Cadastra um novo veterinário
        /// </summary>
        /// <remarks>
        /// Insere:
        /// 
        /// POST
        ///   [
        ///     {
        ///       "id": 1,
        ///       "nome": "teste",
        ///       "email": "teste@gmail.com",
        ///       "telefone": "(63)99999-1111",
        ///       "cpf": "123.456.789-00",
        ///       "endereco": "Rua teste, número 05",
        ///       "especializacao": "Cirurgia geral",
        ///       "crmv": "123",
        ///       "isDeleted": false
        ///     }
        ///   ]
        ///
        /// </remarks>
        /// <response code ="200"> Retorna o veterinario cadastrado</response>
        /// <response code = "400">Se encontrar um erro</response>
        // POST: api/Veterinarios
        [HttpPost]
        public IActionResult Post(Veterinario veterinario)
        {
            if (veterinario == null)
            {
                return BadRequest("Dados do veterinário estão ausentes.");
            }

            // Inicializar listas para evitar erros
            veterinario.Encontros = veterinario.Encontros ?? new List<Encontro>();
            veterinario.Agendamentos = veterinario.Agendamentos ?? new List<Agendamento>();
            _context.Veterinarios.Add(veterinario);
            return CreatedAtAction(nameof(GetById), new { id = veterinario.Id }, veterinario);
        }


        /// <summary>
        /// Altera um veterinário já cadastrado
        /// </summary>
        /// <remarks>
        /// Insere:
        /// 
        /// PUT
        ///   [
        ///     {
        ///       "id": 1,
        ///       "nome": "teste",
        ///       "email": "teste@gmail.com",
        ///       "telefone": "(63)99999-1111",
        ///       "cpf": "123.456.789-00",
        ///       "endereco": "Rua teste, número 05",
        ///       "especializacao": "Cirurgia geral",
        ///       "crmv": "123",
        ///       "isDeleted": false
        ///     }
        ///   ]
        ///
        /// </remarks>
        /// <response code ="200"> Retorna o veterinario com dados alterados</response>
        /// <response code = "400">Se encontrar um erro</response>
        // PUT: api/Veterinarios/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Veterinario input)
        {
            // Comparação explícita
            if (id != input.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }

            var veterinario = _context.Veterinarios.SingleOrDefault(v => v.Id == id);
            if (veterinario == null)
            {
                return NotFound();
            }
            veterinario.Update(input.Nome, input.Email, input.Telefone, input.Cpf, input.Endereco, input.Especializacao, input.CRMV);
            return NoContent();
        }

        /// <summary>
        /// Apaga um veterinário
        /// </summary>
        /// <remarks>
        /// DELETE
        ///date: Fri,06 Dec 2024 02:18:03 GMT
        ///server: Kestrel
        /// </remarks>
        /// <response code ="200"> Retorna data e nome do servidor</response>
        /// <response code = "400">Se encontrar um erro</response>
        // DELETE: api/Veterinarios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var veterinario = _context.Veterinarios.SingleOrDefault(v => v.Id == id);
            if (veterinario == null)
            {
                return NotFound();
            }
            veterinario.Delete();
          
            return NoContent();
        }

    }
}
