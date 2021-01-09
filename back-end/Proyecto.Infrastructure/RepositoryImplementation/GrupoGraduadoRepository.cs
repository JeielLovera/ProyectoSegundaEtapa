using Proyecto.Domain.Entities;
using Proyecto.Domain.Repository;
using Proyecto.Infrastructure.Context;

namespace Proyecto.Infrastructure.RepositoryImplementation
{
    public class GrupoGraduadoRepository : Repository<GrupoGraduado>, IGrupoGraduadoRepository
    {
        public GrupoGraduadoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}