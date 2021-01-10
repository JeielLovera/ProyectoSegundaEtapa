using AutoMapper;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Models.Response;

namespace Proyecto.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoResponse>();
            CreateMap<CursoRequest, Curso>().ReverseMap();

            CreateMap<GrupoGraduado, GrupoGraduadoResponse>();
            CreateMap<GrupoGraduadoRequest, GrupoGraduado>().ReverseMap();
        }
    }
}
