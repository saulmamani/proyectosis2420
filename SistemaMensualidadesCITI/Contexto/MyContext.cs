using Microsoft.EntityFrameworkCore;
using SistemaMensualidadesCITI.Models;

namespace SistemaMensualidadesCITI.Contexto
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ingeniero> Ingenieros { get; set; }
        public DbSet<Pago> Pagos { get; set; }
    }
}
