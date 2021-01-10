using AutoMapper;
using Proyecto.Domain.Models.Response;
using Proyecto.Domain.Services.Querys;
using Proyecto.Infrastructure.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Application.ServicesImplementation.Querys
{
    public class CursoServiceQuery : ICursoServiceQuery
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CursoServiceQuery(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IEnumerable<CursoResponse>> GetAll(string includeProperties = "")
        {
            var cursos = await _unitOfWork.cursoReposotory.GetAll();
            var cursosResponse = _mapper.Map<IEnumerable<CursoResponse>>(cursos);
            return cursosResponse;
        }

        public async Task<CursoResponse> GetById(int id, string includeProperties = "")
        {
            var curso = await _unitOfWork.cursoReposotory.Get(filter: x=>x.Id == id, includeProperties: includeProperties);
            var cursoResponse = _mapper.Map<CursoResponse>(curso.FirstOrDefault());
            return cursoResponse;
        }
    }
}
