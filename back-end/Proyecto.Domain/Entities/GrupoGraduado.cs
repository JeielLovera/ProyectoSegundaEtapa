using System;

namespace Proyecto.Domain.Entities
{
    public class GrupoGraduado
    {
        public int Id { get; set; }
        public DateTime Anyo { get; set; }
        public string Sexo { get; set; }
        public int CursoId { get; set; }
        public int? Cantidad { get; set; }

        public Curso Curso { get; set; }
    }
}
