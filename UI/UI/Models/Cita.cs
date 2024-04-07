using System;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Cita
    {
        [Required]
        [Display(Name = "Cita")]
        public int TN_IdCita { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public Nullable<int> TN_IdCliente { get; set; }

        [Required]
        [Display(Name = "Mascota")]
        public Nullable<int> TN_IdMascota { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public System.DateTime TF_FecCita { get; set; }

        public IEnumerable<SelectListItem> Clientes { get; set; }
        public IEnumerable<SelectListItem> Mascotas { get; set; }
    }
}