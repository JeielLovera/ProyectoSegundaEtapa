using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

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
            //var grupos = new List<GrupoGraduado>();
            //grupos.Add(new GrupoGraduado { Id = 1, Anyo = new DateTime(1993, 1, 1), Sexo = "Males", CursoId = 1, Cantidad = 2000 });
            //grupos.Add(new GrupoGraduado { Id = 2, Anyo = new DateTime(1993, 1, 1), Sexo = "Females", CursoId = 2, Cantidad = 1500 });
            //return grupos;

            string filepath = @"./../Proyecto.Infrastructure/Files/datafile.csv";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAt(0);

            List<GrupoGraduado> grupos = new List<GrupoGraduado>();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] registers = lines[i].Split(',');

                int anyo = int.Parse(registers[0]);

                int? cantidad = 0;
                if (registers[3] == "na") cantidad = null;
                else cantidad = int.Parse(registers[3]);

                string curso = registers[2];
                if (curso.Contains("\""))
                {
                    curso = curso.Replace("\"", " ").Trim();
                }
                var grupo = new GrupoGraduado
                {
                    Id = i + 1,
                    Anyo = new DateTime(anyo, 1, 1),
                    Sexo = registers[1],
                    CursoId = Utilities.GetCursoId(curso),
                    Cantidad = cantidad
                };

                grupos.Add(grupo);
            }

            return grupos;
        }
    }
}
