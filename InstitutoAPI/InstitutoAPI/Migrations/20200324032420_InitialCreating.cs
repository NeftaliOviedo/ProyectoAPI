using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitutoAPI.Migrations
{
    public partial class InitialCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Autor", x => x.AutorID);
                });

            migrationBuilder.CreateTable(
                name: "T_Estudiante",
                columns: table => new
                {
                    EstudianteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Escuela = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Carrera = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AutorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Estudiante", x => x.EstudianteID);
                    table.ForeignKey(
                        name: "FK_T_Estudiante_T_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "T_Autor",
                        principalColumn: "AutorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Estudiante_AutorID",
                table: "T_Estudiante",
                column: "AutorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Estudiante");

            migrationBuilder.DropTable(
                name: "T_Autor");
        }
    }
}
