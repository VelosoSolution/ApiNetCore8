using Aula01.Models;
namespace Aula01.Repositores.Interface
{
    public interface IClientes
    {
        Task<List<CientesModels>> GetClientes();
        Task<CientesModels> GetClientes(int id);
        Task<CientesModels> AddClientes(CientesModels cliente);
        Task<bool> UpdateClientes(int id, CientesModels cliente);
        Task<bool> DeleteClientes(int id);
    }
}
