using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface ISessionRepository
{
    Task<DbSession> Create(int idPersonne, int idParcours, string type, int tempsMinutes);
    Task<IEnumerable<DbSession>>  FetchByPersonneParcoursAndType(int personneId, int parcoursId, string type);
}