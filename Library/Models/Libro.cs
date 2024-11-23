using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexISBN", IsUnique = true)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Año de Publicación")]
        [Range(1800, 2024, ErrorMessage = "El año debe estar entre {1} y {2}")]
        public int AnioPublicacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a 0")]
        [Display(Name = "Copias Disponibles")]
        public int CopiasDisponibles { get; set; }

        // Propiedades de navegación para la relación con Préstamo
        public virtual ICollection<Prestamo> Prestamos { get; set; }

        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }
    }
}