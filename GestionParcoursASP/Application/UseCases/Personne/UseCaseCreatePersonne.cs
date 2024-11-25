using Application.UseCases.Personne.DTOs;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.EF;
using Infrastructure.EF.DbEntities;

namespace Application.UseCases.Personne;

public class UseCaseCreatePersonne : IUseCaseWriter<Task<DtoOutputPersonne>, DtoInputPersonne>
{
    private readonly IPersonneRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseCreatePersonne(IPersonneRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DtoOutputPersonne> Execute(DtoInputPersonne input)
    {
        var personne = _mapper.Map<Domain.Personne>(input);
        var dbPersonne = await _repository.Create(personne.Nom, personne.Prenom);
        return _mapper.Map<DtoOutputPersonne>(dbPersonne);

    }
}