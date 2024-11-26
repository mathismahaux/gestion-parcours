using Application.UseCases.Personne.DTOs;
using Application.UseCases.Utils;
using AutoMapper;
using Domain;
using Infrastructure.EF;

namespace Application.UseCases.Personne;

public class UseCaseFetchAllPersonnes : IUseCaseQuery<Task<IEnumerable<DtoOutputPersonne>>>
{
    private readonly IPersonneRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllPersonnes(IPersonneRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DtoOutputPersonne>> Execute()
    {
        var personnes = await _repository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputPersonne>>(personnes);
    }
}