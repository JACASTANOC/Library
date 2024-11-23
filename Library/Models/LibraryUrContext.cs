using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class LibraryUrContext : DbContext
    {
        // Constructor que usa la cadena de conexión "DefaultConnection"
        public LibraryUrContext()
            : base("DefaultConnection")
        {
        }

        //Invocar el metodo para impedir la eliminación en cascada

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        // Atributos - DbSets para cada modelo
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}