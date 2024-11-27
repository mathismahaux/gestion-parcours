using Domain;
using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class SessionRepository : ISessionRepository
{
    private readonly GestionParcoursDbContext _context;

    public SessionRepository(GestionParcoursDbContext context)
    {
        _context = context;
    }

    public async Task<DbSession> Create(int idPersonne, int idParcours, string type, int tempsMinutes)
    {
        var session = new DbSession
        {
            PersonneId = idPersonne,
            ParcoursId = idParcours,
            Type = type,
            TempsMinutes = tempsMinutes
        };
        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();
        return session;
    }
    
    public async Task<IEnumerable<DbSession>> FetchByPersonneParcoursAndType(int personneId, int parcoursId, string type)
    {
        return await _context.Sessions
            .Where(s => s.PersonneId == personneId && s.ParcoursId == parcoursId && s.Type == type)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<DbSession>> FetchByPersonne(int personneId)
    {
        return await _context.Sessions
            .Where(s => s.PersonneId == personneId)
            .ToListAsync();
    }
}