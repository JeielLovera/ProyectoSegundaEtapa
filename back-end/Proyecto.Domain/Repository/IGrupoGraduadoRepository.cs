using Proyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Domain.Repository
{
    public interface IGrupoGraduadoRepository : IRepository<GrupoGraduado>
    {
        Task<IEnumerable<object>> GetSumGraduadosByCursoAndYear(DateTime date);
        Task<IEnumerable<GrupoGraduado>> GetAllPaged(int skip, int take);

        Task<int> GetCount();
    }
}
