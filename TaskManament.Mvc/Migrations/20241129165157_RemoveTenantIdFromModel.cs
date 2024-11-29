using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManament.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTenantIdFromModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Tenant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
