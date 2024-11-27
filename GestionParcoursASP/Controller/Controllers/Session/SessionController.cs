using Application.UseCases.Session;
using Application.UseCases.Session.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionParcoursASP.Controllers.Session;

[ApiController]
[Route("api/sessions")]
public class SessionController: ControllerBase
{
    private readonly UseCaseCreateSession _useCaseCreateSession;
    private readonly UseCaseCalculateAverageTime _useCaseCalculateAverageTime;
    private readonly UseCaseFetchByPersonneId _useCaseFetchByPersonneId;

    public SessionController(UseCaseCreateSession useCaseCreateSession, UseCaseCalculateAverageTime useCaseCalculateAverageTime, UseCaseFetchByPersonneId useCaseFetchByPersonneId)
    {
        _useCaseCreateSession = useCaseCreateSession;
        _useCaseCalculateAverageTime = useCaseCalculateAverageTime;
        _useCaseFetchByPersonneId = useCaseFetchByPersonneId;
    }

    [HttpPost]
    public async Task<ActionResult<DtoOutputSession>> Create (DtoInputSession dto)
    {
        var result = await _useCaseCreateSession.Execute(dto);
        return Ok(result);
    }
    
    [HttpGet("average-time")]
    public async Task<ActionResult<DtoOutputAverageTime>> GetAverageTime(int personneId, int parcoursId, string type)
    {
        var result = await _useCaseCalculateAverageTime.Execute(personneId, parcoursId, type);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpGet("get-by-person-id")]
    public async Task<ActionResult<IEnumerable<DtoOutputSession>>> FetchByPersonneId(int personneId)
    {
        var result = await _useCaseFetchByPersonneId.Execute(personneId);
        return Ok(result);
    }
}