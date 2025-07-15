using Imanol_Acosta_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Imanol_Acosta_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Entrada> Entradas { get; set; }

    public DbSet<EntradaDetalle> EntradaDetalles { get; set; }

}