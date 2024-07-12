using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LisaApi.Migrations
{
    /// <inheritdoc />
    public partial class TenantLeaseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantLeaseId",
                table: "TenantLeases",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantLeaseId",
                table: "TenantLeases");
        }
    }
}
