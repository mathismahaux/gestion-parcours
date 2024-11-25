using Application.UseCases.Parcours.DTOs;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Parcours;

public class UseCaseFetchAllParcours : IUseCaseQuery<Task<IEnumerable<DtoOutputParcours>>>
{
    private readonly IParcoursRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllParcours(IParcoursRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DtoOutputParcours>> Execute()
    {
        var parcours = await _repository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputParcours>>(parcours);
    }
}