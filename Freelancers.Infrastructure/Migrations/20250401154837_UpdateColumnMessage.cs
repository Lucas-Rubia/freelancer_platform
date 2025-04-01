using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mesasage",
                table: "Proposals",
                newName: "Message");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Proposals",
                newName: "Mesasage");
        }
    }
}
