using Aula01.Data;
using Aula01.Models;
using Aula01.Repositores.Interface;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Repositores
{
    public class LoginRepositores: ILogin
    {
        private readonly DbContextAula01 _context;

        public LoginRepositores(DbContextAula01 context)
        {
            _context = context;
        }

        public async Task<List<LoginModels>> GetLogins()
        {
            return await _context.Logins.ToListAsync();
        }

        public async Task<LoginModels> GetLogin(int id)
        {
            return await _context.Logins.FindAsync(id);
        }

        public async Task<LoginModels> AddLogin(LoginModels login)
        {
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }

        public async Task<bool> UpdateLogin(int id, LoginModels login)
        {
            var LoginExistente = await _context.Logins.FindAsync(id);

            if (LoginExistente == null)
            {
                return false;
            }

            LoginExistente.Username = login.Username;
            LoginExistente.Password = login.Password;
            

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteLogin(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return false;
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
