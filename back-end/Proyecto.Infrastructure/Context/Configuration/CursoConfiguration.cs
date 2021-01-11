using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Context.Configuration
{
    public class CursoConfiguration
    {
        public CursoConfiguration(EntityTypeBuilder<Curso> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Nombre).HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);

            var cursos = InitializeData();
            entityTypeBuilder.HasData(cursos);
        }

        private List<Curso> InitializeData()
        {
            var cursos = new List<Curso>();
            
            for( int i = 1; i <= Utilities.cursosCount; i++)
            {
                var curso = new Curso { Id = i, Nombre = Utilities.GetCursoName(i) };
                cursos.Add(curso);
            }

            return cursos;
        }
    }
}
