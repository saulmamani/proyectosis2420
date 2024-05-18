using SistemaMensualidadesCITI.Dto;
using System.ComponentModel.DataAnnotations;

namespace SistemaMensualidadesCITI.Models
{
    public class Usuario
    {
        [Key] //Annotations
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public RolEnum Rol { get; set; }

        //relaciones 1 ----> *
        public virtual List<Pago>? Pagos { get; set; }
    }
}
