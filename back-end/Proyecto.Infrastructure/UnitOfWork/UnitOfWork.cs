using Proyecto.Domain.Entities;
using Proyecto.Domain.Repository;
using Proyecto.Infrastructure.Context;
using Proyecto.Infrastructure.RepositoryImplementation;
using System;

namespace Proyecto.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public IRepository<GrupoGraduado> grupoGraduadoRepository { get; private set; }
        public IRepository<Curso> cursoReposotory { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            grupoGraduadoRepository = new Repository<GrupoGraduado>(_context);
            cursoReposotory = new Repository<Curso>(_context);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
        
    }
}
