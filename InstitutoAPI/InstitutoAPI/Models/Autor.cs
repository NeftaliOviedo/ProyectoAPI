using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoAPI.Models
{
    public class Autor
    {
        [Key]

        public int AutorID { get; set; }
        [Column(TypeName = "nvarchar(250)")]

        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(250)")]

        public string Apellido { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Autor> mapeoAutor)
            {
                mapeoAutor.HasKey(x => x.AutorID);
            }
        }
    }
}
