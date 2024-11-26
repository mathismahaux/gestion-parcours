using Domain;
using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface IPersonneRepository
{
    Task<IEnumerable<DbPersonne>> FetchAll();
    Task<DbPersonne> Create(string nom, string prenom);
    Task<bool> PersonExists(string nom, string prenom);
}