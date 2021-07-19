using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class AdddClinicTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    idDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_pk", x => x.idDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    idMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_pk", x => x.idMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    idPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_pk", x => x.idPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    idPresciption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPatient = table.Column<int>(type: "int", nullable: false),
                    idDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_pk", x => x.idPresciption);
                    table.ForeignKey(
                        name: "Doctor_Prescription",
                        column: x => x.idDoctor,
                        principalTable: "Doctor",
                        principalColumn: "idDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Patient_Prescription",
                        column: x => x.idPatient,
                        principalTable: "Patient",
                        principalColumn: "idPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    idMedicament = table.Column<int>(type: "int", nullable: false),
                    idPrescription = table.Column<int>(type: "int", nullable: false),
                    dose = table.Column<int>(type: "int", nullable: false),
                    details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescriptionMedicament_pk", x => new { x.idMedicament, x.idPrescription });
                    table.ForeignKey(
                        name: "Medicament_PrescriptionMedicament",
                        column: x => x.idMedicament,
                        principalTable: "Medicament",
                        principalColumn: "idMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_PrescriptionMedicament",
                        column: x => x.idPrescription,
                        principalTable: "Prescription",
                        principalColumn: "idPresciption",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "idDoctor", "email", "firstName", "lastName" },
                values: new object[] { 1, "test@doktor.pl", "Test", "Doktor" });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "idMedicament", "description", "name", "type" },
                values: new object[] { 1, "Testowy lek", "Meds1", "typowy" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "idPatient", "birthdate", "firstName", "lastName" },
                values: new object[] { 1, new DateTime(1999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "Test" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "idPresciption", "date", "dueDate", "idDoctor", "idPatient" },
                values: new object[] { 1, new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "idMedicament", "idPrescription", "details", "dose" },
                values: new object[] { 1, 1, "opis", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_idDoctor",
                table: "Prescription",
                column: "idDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_idPatient",
                table: "Prescription",
                column: "idPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_idPrescription",
                table: "Prescription_Medicament",
                column: "idPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
