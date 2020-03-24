using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoAPI.Models
{
    public class Estudiante
    {
        [Key]

        public int EstudianteID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(250)")]

        public string Apellido { get; set; }
        [Column(TypeName = "int")]

        public int Edad { get; set; }
        [Column(TypeName = "nvarchar(250)")]

        public string Escuela { get; set; }
        [Column(TypeName = "nvarchar(250)")]

        public string Carrera { get; set; }
        [Column(TypeName = "int")]

        public int AutorID { get; set; }
        public Autor Autor { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Estudiante> mapeoEstudiante)
            {
                mapeoEstudiante.HasKey(x => x.EstudianteID);
                mapeoEstudiante.HasOne(x => x.Autor);
            }
        }
    }
}
