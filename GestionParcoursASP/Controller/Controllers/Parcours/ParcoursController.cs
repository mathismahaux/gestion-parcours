using Application.UseCases.Parcours;
using Application.UseCases.Parcours.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionParcoursASP.Controllers.Parcours;

[ApiController]
[Route("api/parcours")]
public class ParcoursController: ControllerBase
{
    private readonly UseCaseFetchAllParcours _useCaseFetchAllParcours;
    private readonly UseCaseCreateParcours _useCaseCreateParcours;


    public ParcoursController(UseCaseFetchAllParcours useCaseFetchAllParcours, UseCaseCreateParcours useCaseCreateParcours)
    {
        _useCaseFetchAllParcours = useCaseFetchAllParcours;
        _useCaseCreateParcours = useCaseCreateParcours;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DtoOutputParcours>>>FetchAll()
    {
        var result = await _useCaseFetchAllParcours.Execute();
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<DtoOutputParcours>> Create([FromBody]DtoInputParcours dto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new { message = string.Join(", ", errors) });
        }
        
        var result = await _useCaseCreateParcours.Execute(dto);
        return Ok(result);
    }
}