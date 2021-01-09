using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Domain.Entities;

namespace Proyecto.Infrastructure.Context.Configuration
{
    public class CursoConfiguration
    {
        public CursoConfiguration(EntityTypeBuilder<Curso> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);

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