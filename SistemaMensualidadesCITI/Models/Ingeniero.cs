using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMensualidadesCITI.Models
{
    public class Ingeniero
    {
        [Key]
        public int id { get; set; }
        [Required]
        public uint Rni { get; set; }
        [Required, MinLength(7), MaxLength(8)]
        public string? Ci { get; set; }
        [Required, MinLength(3)]
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }
        public string? UrlFoto { get; set; }

        //relaciones 1 ----> *
        public virtual List<Pago>? Pagos { get; set; }
    }
}
