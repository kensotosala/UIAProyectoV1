using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Mascotas
    {
        [Key]
        public int TN_IdMascota { get; set; }

        public string TC_NombreMascota { get; set; }
        public Nullable<int> TN_IdCliente { get; set; }
        public List<Clientes> Clientes { get; set; }
    }
}