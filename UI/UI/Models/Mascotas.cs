using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Models
{
    public class Mascotas
    {
        [Key]
        public int TN_IdMascota { get; set; }

        [Display(Name = "Mascota")]
        public string TC_NombreMascota { get; set; }

        [Display(Name = "Cliente")]
        public Nullable<int> TN_IdCliente { get; set; }

        public IEnumerable<SelectListItem> Clientes { get; set; } 

    }
}