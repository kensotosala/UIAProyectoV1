using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UI.srvMascotas;

namespace UI.Models
{
    public class DetallesMascota
    {
        [Key]
        [Required]
        [Display(Name = "Mascota")]
        public int TN_IdMascota { get; set; }

        [Required]
        [Display(Name = "Raza")]
        public string TC_Raza { get; set; }

        [Required]
        [Display(Name = "Peso")]
        public decimal TN_Peso { get; set; }

        [Required]
        [Display(Name = "Color")]
        public string TC_Color { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Mascotas { get; set; }
    }
}