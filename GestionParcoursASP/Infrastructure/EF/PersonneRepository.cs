using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class PersonneRepository : IPersonneRepository
{
    private readonly GestionParcoursDbContext _context;

    public PersonneRepository(GestionParcoursDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DbPersonne>> FetchAll()
    {
        return await _context.Personnes.ToListAsync();
    }

    public async Task<DbPersonne> Create(string nom, string prenom)
    {
        var personne = new DbPersonne
        {
            Nom = nom,
            Prenom = prenom
        };
        _context.Personnes.Add(personne);
        await _context.SaveChangesAsync();
        return personne;
    }
}