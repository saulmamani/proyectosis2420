using System.ComponentModel.DataAnnotations;

namespace SistemaMensualidadesCITI.Models
{
    public class Ingeniero
    {
        [Key]
        public int id { get; set; }
        public uint Rni { get; set; }
        public string? Ci { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public DateTime FechaRegistro { get; set; }

        //relaciones 1 ----> *
        public virtual List<Pago>? Pagos { get; set; }
    }
}
