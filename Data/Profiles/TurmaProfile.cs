using AutoMapper;
using CrossCutting.Dtos.Turma;
using Domain;

namespace Data.Profiles
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            CreateMap<Turma, TurmaDto>();
            CreateMap<Turma, TurmaAtualizarDto>();
            CreateMap<TurmaCriarDto, Turma>();
            CreateMap<TurmaAtualizarDto, Turma>();
            CreateMap<TurmaDto, TurmaAtualizarDto>();
        }
    }
}