using Application.UseCases.Parcours.DTOs;
using Application.UseCases.Personne.DTOs;
using Application.UseCases.Session.DTOs;
using AutoMapper;
using Domain;
using Infrastructure.EF;
using Infrastructure.EF.DbEntities;

namespace Application;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<Personne, DtoOutputPersonne>();
        CreateMap<DbPersonne, DtoOutputPersonne>();
        CreateMap<DbPersonne, Personne>();
        CreateMap<DtoInputPersonne, Personne>();
        
        CreateMap<Parcours, DtoOutputParcours>();
        CreateMap<DbParcours, DtoOutputParcours>();
        CreateMap<DbParcours, Parcours>();
        CreateMap<DtoInputParcours, Parcours>();
        
        CreateMap<Session, DtoOutputSession>();
        CreateMap<DbSession, DtoOutputSession>();
        CreateMap<DbSession, Session>();
        CreateMap<DtoInputSession, Session>();
    }
}