using Application.UseCases.Parcours.DTOs;
using Application.UseCases.Personne.DTOs;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Parcours;

public class UseCaseCreateParcours : IUseCaseWriter<Task<DtoOutputParcours>, DtoInputParcours>
{
    private readonly IParcoursRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseCreateParcours(IParcoursRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DtoOutputParcours> Execute(DtoInputParcours input)
    {
        var parcours = _mapper.Map<Domain.Parcours>(input);
        var dbParcours = await _repository.Create(parcours.Nom, parcours.TempsMarcheMinutes, parcours.TempsCourseMinutes);
        return _mapper.Map<DtoOutputParcours>(dbParcours);
    }
}