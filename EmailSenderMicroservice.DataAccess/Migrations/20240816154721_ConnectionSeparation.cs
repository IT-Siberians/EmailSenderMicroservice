using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSenderMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionSeparation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Connection",
                table: "Settings",
                newName: "ServerAddress");

            migrationBuilder.AddColumn<long>(
                name: "ServerPort",
                table: "Settings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerPort",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "ServerAddress",
                table: "Settings",
                newName: "Connection");
        }
    }
}
