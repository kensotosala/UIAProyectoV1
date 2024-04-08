using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI.Models
{
    public class Cita
    {
        [Key]
        [Required]
        [Display(Name = "Cita")]
        public int TN_IdCita { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int TN_IdCliente { get; set; }

        [Required]
        [Display(Name = "Mascota")]
        public int TN_IdMascota { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime TF_FecCita { get; set; }

        public IEnumerable<SelectListItem> Clientes { get; set; }
        public IEnumerable<SelectListItem> Mascotas { get; set; }
    }
}