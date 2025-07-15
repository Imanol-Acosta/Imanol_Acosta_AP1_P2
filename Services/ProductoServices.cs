using Imanol_Acosta_AP1_P2.DAL;
using Imanol_Acosta_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Imanol_Acosta_AP1_P2.Services;

public class ProductoService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Producto producto)
    {
        if (!await Existe(producto.ProductoID))
        {
            return await Insertar(producto);
        }
        else
        {
            return await Modificar(producto);
        }
    }

    public async Task<bool> Existe(int productoID)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos.AsNoTracking().AnyAsync(p => p.ProductoID == productoID);
    }

    private async Task<bool> Insertar(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Productos.Add(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Productos.Update(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Producto?> Buscar(int productoID)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.ProductoID == productoID);
    }

    public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos.AsNoTracking().Where(criterio).ToListAsync();
    }
}