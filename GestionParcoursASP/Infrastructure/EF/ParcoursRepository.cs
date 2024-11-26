using System.Collections.Immutable;
using Domain;
using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class ParcoursRepository : IParcoursRepository
{
    private readonly GestionParcoursDbContext _context;

    public ParcoursRepository(GestionParcoursDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<DbParcours>> FetchAll()
    {
        return await _context.Parcours.ToListAsync();
    }

    public async Task<DbParcours> Create(string nom, int tempsMarcheMinutes, int tempsCourseMinutes)
    {
        var parcours = new DbParcours
        {
            Nom = nom,
            TempsMarcheMinutes = tempsMarcheMinutes,
            TempsCourseMinutes = tempsCourseMinutes,
        };
        _context.Parcours.Add(parcours);
        await _context.SaveChangesAsync();
        return parcours;
    }
    
    public async Task<DbParcours> GetById(int id)
    {
        return await _context.Parcours.SingleOrDefaultAsync(p => p.Id == id);
    }
}