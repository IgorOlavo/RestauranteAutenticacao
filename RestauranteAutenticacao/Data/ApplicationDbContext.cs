using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestauranteAutenticacao.Models;

namespace RestauranteAutenticacao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RestauranteAutenticacao.Models.Bebida> Bebida { get; set; }
        public DbSet<RestauranteAutenticacao.Models.Cliente> Cliente { get; set; }
        public DbSet<RestauranteAutenticacao.Models.Marmita> Marmita { get; set; }
        public DbSet<RestauranteAutenticacao.Models.Pedido> Pedido { get; set; }
    }
}