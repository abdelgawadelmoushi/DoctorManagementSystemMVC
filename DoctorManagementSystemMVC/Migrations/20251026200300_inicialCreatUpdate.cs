using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagementSystemMVC.Migrations
{
    /// <inheritdoc />
    public partial class inicialCreatUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "specializations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "specializations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
