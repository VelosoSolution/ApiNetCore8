using Microsoft.AspNetCore.Mvc;
using Aula01.Repositores.Interface;
using Aula01.Models;
using Microsoft.EntityFrameworkCore;
using Aula01.Data;

namespace Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _repository;
        private readonly DbContextAula01 _context;

        public ClientesController([FromServices] IClientes repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CientesModels>>> GetClientes()
        {
            return await _repository.GetClientes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CientesModels>> GetClientes(int id)
        {
            var cliente = await _repository.GetClientes(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<CientesModels>> AddClientes(CientesModels cliente)
        {
            await _repository.AddClientes(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, CientesModels cliente)
        {
            var result = await _repository.UpdateClientes(id, cliente);

            if (result)
            {
                return NoContent(); 
            }
            else
            {
                return NotFound("Cliente não encontrado"); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientes(int id)
        {
            var result = await _repository.DeleteClientes(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}