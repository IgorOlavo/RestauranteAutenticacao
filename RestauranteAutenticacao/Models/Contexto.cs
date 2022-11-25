using Microsoft.EntityFrameworkCore;
using RestauranteAutenticacao.Models.Consultas;

namespace RestauranteAutenticacao.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }
        
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Bebida> Bebida { get; set; }
        public DbSet<Marmita> Marmita { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<RestauranteAutenticacao.Models.Consultas.PedidoQuerry> PedidoQuerry { get; set; }
        public DbSet<RestauranteAutenticacao.Models.Consultas.PedidoGroupStatus> PedidoGroupStatus { get; set; }
    }

}
