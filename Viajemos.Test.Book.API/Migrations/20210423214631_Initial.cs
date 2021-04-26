using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajemos.Test.Book.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editorials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sede = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    editoriales_id = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    sinopsis = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    n_paginas = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Editorials_editoriales_id",
                        column: x => x.editoriales_id,
                        principalTable: "Editorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorHasBook",
                columns: table => new
                {
                    Autores_Id = table.Column<int>(type: "int", nullable: false),
                    Libros_ISBN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorHasBook", x => new { x.Autores_Id, x.Libros_ISBN });
                    table.ForeignKey(
                        name: "FK_AuthorHasBook_Author_Autores_Id",
                        column: x => x.Autores_Id,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorHasBook_Books_Libros_ISBN",
                        column: x => x.Libros_ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorHasBook_Libros_ISBN",
                table: "AuthorHasBook",
                column: "Libros_ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Books_editoriales_id",
                table: "Books",
                column: "editoriales_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorHasBook");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Editorials");
        }
    }
}
