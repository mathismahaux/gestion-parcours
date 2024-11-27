using Application.UseCases.Session.DTOs;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Session;

public class UseCaseFetchByPersonneId
{
    private readonly ISessionRepository _repository;
    private readonly IMapper _mapper;
    
    public UseCaseFetchByPersonneId(ISessionRepository sessionRepository, IMapper mapper)
    {
        _repository = sessionRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DtoOutputSession>> Execute(int personneId)
    {
        var parcours = await _repository.FetchByPersonne(personneId);
        return _mapper.Map<IEnumerable<DtoOutputSession>>(parcours);
    }
}