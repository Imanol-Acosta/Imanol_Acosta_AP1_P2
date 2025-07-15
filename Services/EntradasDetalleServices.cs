using Imanol_Acosta_AP1_P2.DAL;
using Imanol_Acosta_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Imanol_Acosta_AP1_P2.Services;

public class EntradaDetallesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(EntradaDetalle entradaDetalle)
    {
        if (!await Existe(entradaDetalle.Id))
        {
            return await Insertar(entradaDetalle);
        }
        else
        {
            return await Modificar(entradaDetalle);
        }
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaDetalles.AsNoTracking().AnyAsync(ed => ed.Id == id);
    }

    private async Task<bool> Insertar(EntradaDetalle entradaDetalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradaDetalles.Add(entradaDetalle);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradaDetalle entradaDetalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradaDetalles.Update(entradaDetalle);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<EntradaDetalle?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaDetalles.AsNoTracking().FirstOrDefaultAsync(ed => ed.Id == id);
    }

    public async Task<List<EntradaDetalle>> Listar(Expression<Func<EntradaDetalle, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaDetalles.AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entradaDetalle = await contexto.EntradaDetalles.FindAsync(id);
        if (entradaDetalle == null)
        {
            return false;
        }
        contexto.EntradaDetalles.Remove(entradaDetalle);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<EntradaDetalle>> ListarPorEntrada(int entradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaDetalles
            .AsNoTracking()
            .Include(ed => ed.Producto)
            .Where(ed => ed.EntradaId == entradaId)
            .ToListAsync();
    }
}