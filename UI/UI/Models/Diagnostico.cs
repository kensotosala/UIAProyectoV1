using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI.Models
{
    public class Diagnostico
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public int TN_IdDiagnostico { get; set; }

        [Required]
        [Display(Name = "Cita")]
        public int TN_IdCita { get; set; }

        [Display(Name = "Diagnóstico")]
        [StringLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El diagnóstico es obligatori0.")]
        public string TC_DscDiagnostico { get; set; }

        public IEnumerable<SelectListItem> Citas { get; set; }
    }
}