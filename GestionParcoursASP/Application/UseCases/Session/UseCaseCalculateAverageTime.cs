using Application.UseCases.Session.DTOs;
using Domain;
using Infrastructure.EF;

namespace Application.UseCases.Session;

public class UseCaseCalculateAverageTime
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IParcoursRepository _parcoursRepository;

    public UseCaseCalculateAverageTime(ISessionRepository sessionRepository, IParcoursRepository parcoursRepository)
    {
        _sessionRepository = sessionRepository;
        _parcoursRepository = parcoursRepository;
    }

    public async Task<DtoOutputAverageTime> Execute(int personneId, int parcoursId, string type)
    {
        var sessions = await _sessionRepository.FetchByPersonneParcoursAndType(personneId, parcoursId, type);
        if (!sessions.Any())
        {
            return null;
        }
            

        var averageTime = sessions.Average(s => s.TempsMinutes);

        var parcours = await _parcoursRepository.GetById(parcoursId);
        
        int standardTime = type.ToLower() == "marche"
            ? parcours.TempsMarcheMinutes
            : parcours.TempsCourseMinutes;
        
        return new DtoOutputAverageTime
        {
            ParcoursId = parcoursId,
            Type = type,
            AverageTime = averageTime,
            StandardTime = standardTime,
            IsBetterThanStandard = averageTime < standardTime
        };
    }
}