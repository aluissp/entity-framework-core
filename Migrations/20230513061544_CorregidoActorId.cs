using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroEFCore.Migrations
{
    /// <inheritdoc />
    public partial class CorregidoActorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Actores",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actores",
                newName: "ActorId");
        }
    }
}
