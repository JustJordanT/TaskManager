using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManament.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTenantIdFromApplicationUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ApplicationUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ApplicationUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
