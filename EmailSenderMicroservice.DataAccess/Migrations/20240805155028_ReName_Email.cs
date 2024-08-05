using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSenderMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReName_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToEmail",
                table: "Messages",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Messages",
                newName: "ToEmail");
        }
    }
}
