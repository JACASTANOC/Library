using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo {0}, debe tener entre {2} y {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "El campo {0}, debe tener entre {2} y {1} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "El campo {0}, debe tener entre {2} y {1} caracteres")]
        [Index("IndexMatricula", IsUnique = true)]
        public string Matricula { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "El campo {0}, debe tener entre {2} y {1} caracteres")]
        [Index("IndexCorreo", IsUnique = true)]
        public string Email { get; set; }

        // Relación con Prestamo
        //  public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}