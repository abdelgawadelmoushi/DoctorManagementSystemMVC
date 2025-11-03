using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagementSystemMVC.Migrations
{
    /// <inheritdoc />
    public partial class PatientUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_specializations_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specializations",
                table: "specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.RenameTable(
                name: "specializations",
                newName: "Specialization");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_DoctorId",
                table: "Appointment",
                newName: "IX_Appointment_DoctorId");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientDoctors",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    prescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagonse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDoctors", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_PatientDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDoctors_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctors_DoctorId",
                table: "PatientDoctors",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctors_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialization_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctors_DoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialization_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "PatientDoctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Specialization",
                newName: "specializations");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_DoctorId",
                table: "appointments",
                newName: "IX_appointments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specializations",
                table: "specializations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_Doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
