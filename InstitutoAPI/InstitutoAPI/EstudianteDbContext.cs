using InstitutoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoAPI
{
    public class EstudianteDbContext : DbContext
    {
        public EstudianteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Estudiante> T_Estudiante { get; set; }
        public DbSet<Autor> T_Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelCreator)
        {
            new Estudiante.Mapeo(modelCreator.Entity<Estudiante>());
            new Autor.Mapeo(modelCreator.Entity<Autor>());

        }
    }
}
