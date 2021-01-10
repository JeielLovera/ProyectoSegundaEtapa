using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Domain.Models.Request
{
    public class GrupoGraduadoRequest
    {
        [Required]
        public DateTime Anyo { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string Sexo { get; set; }

        [Required]
        public int CursoId { get; set; }

        public int Cantidad { get; set; }
    }
}
