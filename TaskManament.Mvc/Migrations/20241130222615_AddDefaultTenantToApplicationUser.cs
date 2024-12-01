using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManament.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultTenantToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultTenant",
                table: "ApplicationUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultTenant",
                table: "ApplicationUser");
        }
    }
}
