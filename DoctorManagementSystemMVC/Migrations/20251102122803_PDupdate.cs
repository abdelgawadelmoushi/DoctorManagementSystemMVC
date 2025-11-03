using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagementSystemMVC.Migrations
{
    /// <inheritdoc />
    public partial class PDupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prescription",
                table: "PatientDoctors",
                newName: "Prescription");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "PatientDoctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PatientDoctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctors_AppointmentId",
                table: "PatientDoctors",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Appointment_AppointmentId",
                table: "PatientDoctors",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Appointment_AppointmentId",
                table: "PatientDoctors");

            migrationBuilder.DropIndex(
                name: "IX_PatientDoctors_AppointmentId",
                table: "PatientDoctors");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "PatientDoctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PatientDoctors");

            migrationBuilder.RenameColumn(
                name: "Prescription",
                table: "PatientDoctors",
                newName: "prescription");
        }
    }
}
