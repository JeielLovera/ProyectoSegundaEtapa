using System;

namespace Proyecto.Domain.Models.Response
{
    public class GrupoGraduadoResponse
    {
        public int Id { get; set; }

        public DateTime Anyo { get; set; }

        public string Sexo { get; set; }

        public int Cantidad { get; set; }

        public CursoResponse Curso { get; set; }
    }
}
