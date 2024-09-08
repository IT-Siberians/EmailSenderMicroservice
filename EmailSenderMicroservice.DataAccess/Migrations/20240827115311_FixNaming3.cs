using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSenderMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Settings",
                newName: "CreattionDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Messages",
                newName: "CreattionDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreattionDate",
                table: "Settings",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreattionDate",
                table: "Messages",
                newName: "CreatedDate");
        }
    }
}
