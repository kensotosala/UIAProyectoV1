using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI.Models
{
    public class Mascotas
    {
        [Key]
        public int TN_IdMascota { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string TC_NombreMascota { get; set; }

        [Display(Name = "Cliente")]
        public Nullable<int> TN_IdCliente { get; set; }

        public IEnumerable<SelectListItem> Clientes { get; set; }
    }
}