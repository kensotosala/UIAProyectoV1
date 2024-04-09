using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Clientes
    {
        [Key]
        [Required]
        public int TN_IdCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        [StringLength(60, ErrorMessage = "El nombre no puede tener más de 60 caracteres.")]
        public string TC_Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El apellido paterno solo puede contener letras.")]
        [StringLength(60, ErrorMessage = "El apellido paterno no puede tener más de 60 caracteres.")]
        public string TC_Ap1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "El apellido materno es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El apellido materno solo puede contener letras.")]
        [StringLength(60, ErrorMessage = "El apellido materno no puede tener más de 60 caracteres.")]
        public string TC_Ap2 { get; set; }

        [Display(Name = "Número de Teléfono")]
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El número de teléfono debe contener exactamente 8 dígitos.")]
        public string TC_NumTelefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "La dirección de correo electrónico es obligatoria.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres.")]
        public string TC_CorreoElectronico { get; set; }
    }
}