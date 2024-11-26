using Application.UseCases.Personne;
using Application.UseCases.Personne.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionParcoursASP.Controllers.Personne;

[ApiController]
[Route("api/personnes")]
public class PersonneController : ControllerBase
{
    private readonly UseCaseFetchAllPersonnes _useCaseFetchAllPersonnes;
    private readonly UseCaseCreatePersonne _useCaseCreatePersonne;


    public PersonneController(UseCaseFetchAllPersonnes useCaseFetchAllPersonnes, UseCaseCreatePersonne useCaseCreatePersonne)
    {
        _useCaseFetchAllPersonnes = useCaseFetchAllPersonnes;
        _useCaseCreatePersonne = useCaseCreatePersonne;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DtoOutputPersonne>>> FetchAll()
    {
        var result = await _useCaseFetchAllPersonnes.Execute();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<DtoOutputPersonne>> Create([FromBody] DtoInputPersonne dto)
    {
        var result = await _useCaseCreatePersonne.Execute(dto);
        return Ok(result);
    }
}