using Aula01.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Data
{
    public class DbContextAula01: DbContext
    {
        public DbContextAula01(DbContextOptions<DbContextAula01> options) : base(options)
        {
        }

        public DbSet<LoginModels> Logins { get; set; }
        public DbSet<CientesModels> Clientes { get; set; }
    }
}
