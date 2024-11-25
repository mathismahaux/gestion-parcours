using Application.UseCases.Session.DTOs;
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
        Console.WriteLine($"Personne ID: {personneId}, Parcours ID: {parcoursId}, Type: {type}");

        var sessions = await _sessionRepository.FetchByPersonneParcoursAndType(personneId, parcoursId, type);
        if (!sessions.Any())
        {
            Console.WriteLine("No sessions found. Exiting.");
            return null;
        }
            

        var averageTime = sessions.Average(s => s.TempsMinutes);

        var parcours = await _parcoursRepository.GetById(parcoursId);
        Console.WriteLine($"Fetched parcours: {parcours}");
        Console.WriteLine($"Normalized Type: {type.ToLower()}");
        
        int standardTime = type.ToLower() == "marche"
            ? parcours.TempsMarcheMinutes
            : parcours.TempsCourseMinutes;
        
        Console.WriteLine($"Average Time: {averageTime}, Standard Time: {standardTime}");

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