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

    public SessionController(UseCaseCreateSession useCaseCreateSession, UseCaseCalculateAverageTime useCaseCalculateAverageTime)
    {
        _useCaseCreateSession = useCaseCreateSession;
        _useCaseCalculateAverageTime = useCaseCalculateAverageTime;
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
}