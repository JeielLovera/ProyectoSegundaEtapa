using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Domain.Entities;

namespace Proyecto.Infrastructure.Context.Configuration
{
    public class GrupoGraduadoConfiguration
    {
        public GrupoGraduadoConfiguration(EntityTypeBuilder<GrupoGraduado> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);

            var grupos = InitializeData();
            entityTypeBuilder.HasData(grupos);
        }

        private List<GrupoGraduado> InitializeData()
        {
            //cargar data del csv

            //codigo momentaneo
            var grupos = new List<GrupoGraduado>();
            grupos.Add(new GrupoGraduado { Id = 1, Anyo = new DateTime(1993, 1, 1), Sexo = "Males", CursoId = 1, Cantidad = 2000 });
            grupos.Add(new GrupoGraduado { Id = 2, Anyo = new DateTime(1993, 1, 1), Sexo = "Males", CursoId = 2, Cantidad = 1500 });
            return grupos;
        }
    }
}