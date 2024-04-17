using Microsoft.AspNetCore.Mvc;
using Aula01.Repositores.Interface;
using Aula01.Models;

namespace Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _repository;

        public LoginController([FromServices] ILogin repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<LoginModels>>> GetLogins()
        {
            return await _repository.GetLogins();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoginModels>> GetLogin(int id)
        {
            var login = await _repository.GetLogin(id);
            if (login == null)
            {
                return NotFound();
            }
            return login;
        }

        [HttpPost]
        public async Task<ActionResult<LoginModels>> AddLogin(LoginModels login)
        {
            await _repository.AddLogin(login);
            return CreatedAtAction(nameof(GetLogin), new { id = login.Id }, login);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, LoginModels login)
        {
            var result = await _repository.UpdateLogin(id, login);

            if (result)
            {
                return NoContent(); 
            }
            else
            {
                return NotFound("Login não encontrado"); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLogin(int id)
        {
            var result = await _repository.DeleteLogin(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
