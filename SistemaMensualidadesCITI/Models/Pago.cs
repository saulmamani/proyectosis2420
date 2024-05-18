using System.ComponentModel.DataAnnotations;

namespace SistemaMensualidadesCITI.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public int NroRecibo { get; set; }
        public DateOnly Fecha { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public decimal Total { get; set; }

        //relaciones de * --> 1
        public int UsuarioId { get; set; }
        public int IngenieroId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Ingeniero? Ingeniero { get; set; }
    }
}
