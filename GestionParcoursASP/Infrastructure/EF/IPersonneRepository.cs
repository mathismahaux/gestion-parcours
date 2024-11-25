using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface IPersonneRepository
{
    Task<IEnumerable<DbPersonne>> FetchAll();
    Task<DbPersonne> Create(string nom, string prenom);
}