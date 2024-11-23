using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int LibroId { get; set; }

        [Required]
        [Display(Name = "Fecha de Préstamo")]
        [DataType(DataType.Date)]
        public DateTime FechaPrestamo { get; set; }

        [Required]
        [Display(Name = "Fecha de Devolución")]
        [DataType(DataType.Date)]
        public DateTime FechaDevolucion { get; set; }

        [Display(Name = "Fecha de Devolución Real")]
        [DataType(DataType.Date)]
        public DateTime? FechaDevolucionReal { get; set; }

        [Display(Name = "Estado del Préstamo")]
        public EstadoPrestamo Estado { get; set; }

        // Propiedades de navegación
        [ForeignKey("EstudianteId")]
        public virtual Estudiante Estudiante { get; set; }

        [ForeignKey("LibroId")]
        public virtual Libro Libro { get; set; }
    }

    public enum EstadoPrestamo
    {
        Activo,
        Devuelto,
        Vencido
    }
}