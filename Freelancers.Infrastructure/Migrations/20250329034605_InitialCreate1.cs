using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancers.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Users_UserId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_UserId",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "FreelancerID",
                table: "Proposals",
                newName: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_FreelancerId",
                table: "Proposals",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Users_FreelancerId",
                table: "Proposals",
                column: "FreelancerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Users_FreelancerId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_FreelancerId",
                table: "Proposals");

            migrationBuilder.RenameColumn(
                name: "FreelancerId",
                table: "Proposals",
                newName: "FreelancerID");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Proposals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_UserId",
                table: "Proposals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Users_UserId",
                table: "Proposals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
