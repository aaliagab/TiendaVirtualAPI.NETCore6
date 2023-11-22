using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaAPI.Data.Entities;

namespace TiendaAPI.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProductoPedido> ProductoPedidos { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Cliente>()//
        //    .HasMany(c => c.PedidosRealizados)
        //    .WithOne(p => p.Cliente)
        //    .HasForeignKey(p => p.ClienteId);

        //modelBuilder.Entity<Pedido>()
        //    .HasMany(p => p.ProductosPedido)
        //    .WithOne()
        //    .HasForeignKey(pd => pd.PedidoId);

        // Otras configuraciones de entidades y relaciones...

        //base.OnModelCreating(modelBuilder);
        // }
    }
}
