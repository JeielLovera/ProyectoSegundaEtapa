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
        public IGrupoGraduadoRepository grupoGraduadoRepository { get; private set; }
        public ICursoRepository cursoReposotory { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            grupoGraduadoRepository = new GrupoGraduadoRepository(_context);
            cursoReposotory = new CursoRepository(_context);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
        
    }
}
