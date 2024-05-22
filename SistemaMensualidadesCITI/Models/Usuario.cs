using SistemaMensualidadesCITI.Dto;
using System.ComponentModel.DataAnnotations;

namespace SistemaMensualidadesCITI.Models
{
    public class Usuario
    {
        [Key] //Annotations
        public int Id { get; set; }
        [Required, MinLength(5)]
        public string? Email { get; set; }
        [Required, MinLength(5)]
        public string? Password { get; set; }
        [Required, MinLength(3)]
        public string? Nombre { get; set; }
        public RolEnum Rol { get; set; }

        //relaciones 1 ----> *
        public virtual List<Pago>? Pagos { get; set; }
    }
}
