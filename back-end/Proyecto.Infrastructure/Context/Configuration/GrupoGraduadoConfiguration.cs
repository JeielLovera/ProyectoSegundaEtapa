using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Context.Configuration
{
    public class GrupoGraduadoConfiguration
    {
        public GrupoGraduadoConfiguration(EntityTypeBuilder<GrupoGraduado> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Anyo).HasColumnType("date").IsRequired();
            entityTypeBuilder.Property(x => x.Sexo).HasColumnType("varchar(10)").IsRequired().HasMaxLength(10);
            entityTypeBuilder.Property(x => x.CursoId).IsRequired();
            entityTypeBuilder.Property(x => x.Cantidad).HasColumnType("int").IsRequired(false);

            var grupos = InitializeData();

            entityTypeBuilder.HasData(grupos);
        }

        private List<GrupoGraduado> InitializeData()
        {
            var grupos = new List<GrupoGraduado>();
            grupos.Add(new GrupoGraduado { Id = 1, Anyo = new DateTime(1993, 1, 1), Sexo = "Males", CursoId = 1, Cantidad = 2000 });
            grupos.Add(new GrupoGraduado { Id = 2, Anyo = new DateTime(1993, 1, 1), Sexo = "Females", CursoId = 2, Cantidad = 1500 });
            return grupos;
        }
    }
}
