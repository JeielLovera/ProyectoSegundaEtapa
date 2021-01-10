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
            //cargar data del csv

            //codigo momentaneo
            var cursos = new List<Curso>();
            cursos.Add(new Curso { Id = 1, Nombre = "Education" });
            cursos.Add(new Curso { Id = 2, Nombre = "Applied Arts" });
            return cursos;
        }
    }
}
