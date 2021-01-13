using Proyecto.Domain.Entities;
using Proyecto.Domain.Repository;
using Proyecto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.RepositoryImplementation
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
