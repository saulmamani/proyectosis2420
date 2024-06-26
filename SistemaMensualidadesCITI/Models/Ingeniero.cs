﻿using System.ComponentModel.DataAnnotations;
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

        //para archivos (foto)
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; }

        //atributos computados
        [NotMapped]
        public string? Info { get { return $"{Ci} - {Nombre}"; } }

        //relaciones 1 ----> *
        public virtual List<Pago>? Pagos { get; set; }
    }
}
