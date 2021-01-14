using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Domain.Services.Querys
{
    public interface IGrupoGraduadoServiceQuery : IServiceQuery<GrupoGraduadoResponse>
    {
        public Task<IEnumerable<object>> GetSumGraduadosByCursoAndYear(DateTime date);

        public Task<PagedResponse<GrupoGraduadoResponse>> GetAllPaged(PaginationFilter paginationFilter);
    }
}
