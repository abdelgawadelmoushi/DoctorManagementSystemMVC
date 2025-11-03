using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagementSystemMVC.Migrations
{
    /// <inheritdoc />
    public partial class PatientUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientPageId",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "PatientPageId",
                table: "Appointment",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PatientPageId",
                table: "Appointment",
                newName: "IX_Appointment_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointment",
                newName: "PatientPageId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                newName: "IX_Appointment_PatientPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientPageId",
                table: "Appointment",
                column: "PatientPageId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
