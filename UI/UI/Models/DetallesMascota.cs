using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI.Models
{
    public class DetallesMascota
    {
        [Key]
        [Required]
        [Display(Name = "Mascota")]
        public int TN_IdMascota { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "La raza es obligatoria.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "La raza solo puede contener letras.")]
        [StringLength(100, ErrorMessage = "La raza no puede tener más de 100 caracteres.")]
        public string TC_Raza { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "El peso debe estar entre 0 y 500 Kg.")]
        public decimal TN_Peso { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "El color es obligatoria.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El color solo puede contener letras.")]
        [StringLength(50, ErrorMessage = "El color no puede tener más de 50 caracteres.")]
        public string TC_Color { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Mascotas { get; set; }
    }
}