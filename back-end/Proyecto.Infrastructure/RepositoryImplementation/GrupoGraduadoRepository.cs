using Proyecto.Domain.Entities;
using Proyecto.Domain.Repository;
using Proyecto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Infrastructure.RepositoryImplementation
{
    public class GrupoGraduadoRepository : Repository<GrupoGraduado>, IGrupoGraduadoRepository
    {
        public GrupoGraduadoRepository(ApplicationDbContext context): base(context)
        {

        }

        public async Task<IEnumerable<object>> GetSumGraduadosByCursoAndYear(DateTime date)
        {
            var data = await _context.Set<GrupoGraduado>()
                                        .Include(x => x.Curso)
                                        .Where(x=>x.Anyo.Year == date.Year)
                                        .GroupBy(x => x.Curso.Nombre)
                                        .Select( gp => new { 
                                            curso = gp.Key, cantidad = gp.Sum(s=>s.Cantidad)
                                        }).OrderByDescending(x=>x.cantidad).ToListAsync();

            return data;
        }
    }
}
