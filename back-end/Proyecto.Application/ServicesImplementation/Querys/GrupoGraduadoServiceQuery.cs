using AutoMapper;
using Proyecto.Domain.Models.Response;
using Proyecto.Domain.Services.Querys;
using Proyecto.Infrastructure.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.ServicesImplementation.Querys
{
    public class GrupoGraduadoServiceQuery : IGrupoGraduadoServiceQuery
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrupoGraduadoServiceQuery(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IEnumerable<GrupoGraduadoResponse>> GetAll(string includeProperties = "")
        {
            var grupos = await _unitOfWork.grupoGraduadoRepository.Get(includeProperties: includeProperties);
            var gruposResponse = _mapper.Map<IEnumerable<GrupoGraduadoResponse>>(grupos);
            return gruposResponse;
        }

        public async Task<GrupoGraduadoResponse> GetById(int id, string includeProperties = "")
        {
            var grupo = await _unitOfWork.grupoGraduadoRepository.Get(filter: x => x.Id == id, includeProperties: includeProperties);
            var grupoResponse = _mapper.Map<GrupoGraduadoResponse>(grupo.FirstOrDefault());
            return grupoResponse;
        }
    }
}
