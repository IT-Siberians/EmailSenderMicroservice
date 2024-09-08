using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSenderMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreattionDate",
                table: "Settings",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreattionDate",
                table: "Messages",
                newName: "CreationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Settings",
                newName: "CreattionDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Messages",
                newName: "CreattionDate");
        }
    }
}
