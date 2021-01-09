using System.ComponentModel.DataAnnotations;

namespace Proyecto.Domain.Models.Request
{
    public class CursoRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Nombre { get; set; }
    }
}