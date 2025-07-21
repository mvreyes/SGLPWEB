using System;
using System.ComponentModel.DataAnnotations;

namespace SGLPWEB.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [Required]
        [MaxLength(13)]
        public string Identificación { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string CorreoElectronico { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}