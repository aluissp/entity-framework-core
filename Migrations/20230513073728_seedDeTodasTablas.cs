using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroEFCore.Migrations
{
    /// <inheritdoc />
    public partial class seedDeTodasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "Id", "FechaNacimiento", "Fortuna", "Nombre" },
                values: new object[,]
                {
                    { 2, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200000m, "Samuel L. Jackson" },
                    { 3, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000000m, "Robert Downey Jr." },
                    { 4, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000000m, "Chris Evans" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 6, "Animación" },
                    { 7, "Ciencia Ficción" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Id", "EnCines", "FechaEstreno", "Titulo" },
                values: new object[,]
                {
                    { 3, false, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: Endgame" },
                    { 4, false, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spiderman No Way Home" },
                    { 6, false, new DateTime(2016, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Capitán América: Civil War" }
                });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "Id", "Contenido", "PeliculaId", "Recomendar" },
                values: new object[,]
                {
                    { 5, "Excelente película", 3, false },
                    { 6, "Muy buena película", 4, false },
                    { 7, "Buena película", 6, false }
                });

            migrationBuilder.InsertData(
                table: "GeneroPelicula",
                columns: new[] { "GenerosId", "PeliculasId" },
                values: new object[,]
                {
                    { 6, 4 },
                    { 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculaId", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 2, 3, 2, "Nick Fury" },
                    { 2, 4, 1, "Nick Fury" },
                    { 3, 3, 1, "Tony Stark" },
                    { 3, 6, 1, "Tony Stark" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
