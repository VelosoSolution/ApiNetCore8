using Aula01.Data;
using Aula01.Models;
using Aula01.Repositores.Interface;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Repositores
{

    public class ClientesRepositores : IClientes
    {
        private readonly DbContextAula01 _context;

        public ClientesRepositores(DbContextAula01 context)
        {
            _context = context;
        }

        public async Task<List<CientesModels>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<CientesModels> GetClientes(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<CientesModels> AddClientes(CientesModels cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateClientes(int id, CientesModels cliente)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente == null)
            {
                return false;
            }

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Cep = cliente.Cep;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Bairro = cliente.Bairro;
            clienteExistente.Numero = cliente.Numero;
            clienteExistente.Complemento = cliente.Complemento;
            clienteExistente.Uf = cliente.Uf;
            clienteExistente.Telefone = cliente.Telefone;

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
          
        public async Task<bool> DeleteClientes(int id)
        {
            var cliente2 = await _context.Clientes.FindAsync(id);
            if (cliente2 == null)
            {
                return false;
            }

            _context.Clientes.Remove(cliente2);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
