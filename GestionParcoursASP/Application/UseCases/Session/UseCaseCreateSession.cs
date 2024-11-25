using Application.UseCases.Session.DTOs;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Session;

public class UseCaseCreateSession
{
    private readonly ISessionRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseCreateSession(ISessionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<DtoOutputSession> Execute(DtoInputSession input)
    {
        var session = _mapper.Map<Domain.Session>(input);
        var dbSession = await _repository.Create(session.PersonneId, session.ParcoursId, session.Type, session.TempsMinutes);
        return _mapper.Map<DtoOutputSession>(dbSession);
    }
}