using Imanol_Acosta_AP1_P2.DAL;
using Imanol_Acosta_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Imanol_Acosta_AP1_P2.Services;

public class EntradaService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Entrada entrada)
    {
        if (!await Existe(entrada.EntradaId))
        {
            return await Insertar(entrada);
        }
        else
        {
            return await Modificar(entrada);
        }
    }

    public async Task<bool> Existe(int entradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Entradas.AsNoTracking().AnyAsync(e => e.EntradaId == entradaId);
    }

    private async Task<bool> Insertar(Entrada entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Entradas.Add(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Entrada entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Entradas.Update(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Entrada?> Buscar(int entradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Entradas.AsNoTracking().FirstOrDefaultAsync(e => e.EntradaId == entradaId);
    }

    public async Task<List<Entrada>> Listar(Expression<Func<Entrada, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Entradas.AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<bool> Eliminar(int entradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entrada = await contexto.Entradas.FindAsync(entradaId);
        if (entrada == null)
        {
            return false;
        }
        contexto.Entradas.Remove(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }
}