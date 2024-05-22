using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMensualidadesCITI.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public int NroRecibo { get; set; }
        [Column(TypeName = "date")]
        public DateOnly Fecha { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public decimal Total { get; set; }

        //relaciones de * --> 1
        public int UsuarioId { get; set; }
        public int IngenieroId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Ingeniero? Ingeniero { get; set; }
    }
}
