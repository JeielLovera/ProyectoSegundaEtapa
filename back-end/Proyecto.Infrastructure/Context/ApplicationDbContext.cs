using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using Proyecto.Infrastructure.Context.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder builder)
        {
            new CursoConfiguration(builder.Entity<Curso>());
            new GrupoGraduadoConfiguration(builder.Entity<GrupoGraduado>());            
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<GrupoGraduado> GrupoGraduados { get; set; }
    }
}
