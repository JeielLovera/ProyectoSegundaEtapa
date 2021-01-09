using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Domain.Entities
{
    public class GrupoGraduado
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Anyo { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Sexo { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        public int CursoId { get; set; }

        [Column(TypeName = "int")]
        public int Cantidad { get; set; }

        public Curso Curso { get; set; }
    }
}