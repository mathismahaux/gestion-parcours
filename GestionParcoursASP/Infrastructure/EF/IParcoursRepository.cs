using Domain;
using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface IParcoursRepository
{
    Task<IEnumerable<DbParcours>> FetchAll();
    Task<DbParcours> Create(string nom, int tempsMarcheMinutes, int tempsCourseMinutes);
    Task<DbParcours> GetById(int id);
}