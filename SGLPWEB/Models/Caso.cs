using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGLPWEB.Models
{
    public class Caso
    {
        [Key]
        public int idCaso { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroCaso { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreCaso { get; set; }

        [Required]
        public DateTime? FechaInicio { get; set; }

        [StringLength(500)]
        public string Nota { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int idCliente { get; set; }

        [ForeignKey("idCliente")]
        [ValidateNever]
        public Cliente Cliente { get; set; }

    }
}
