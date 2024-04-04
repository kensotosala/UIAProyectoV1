using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Clientes
    {
        [Key]
        public int TN_IdCliente { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Ap1 { get; set; }
        public string TC_Ap2 { get; set; }
        public string TC_NumTelefono { get; set; }
        public string TC_CorreoElectronico { get; set; }
    }
}