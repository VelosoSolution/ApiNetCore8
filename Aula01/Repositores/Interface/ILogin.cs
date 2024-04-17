using Aula01.Models;
namespace Aula01.Repositores.Interface
{
    public interface ILogin
    {
        Task<List<LoginModels>> GetLogins();
        Task<LoginModels> GetLogin(int id);
        Task<LoginModels> AddLogin(LoginModels login);
        Task<bool> UpdateLogin(int id, LoginModels login);
        Task<bool> DeleteLogin(int id);
    }
}
