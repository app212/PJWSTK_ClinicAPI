using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class SmallFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dose",
                table: "Prescription_Medicament",
                newName: "Dose");

            migrationBuilder.RenameColumn(
                name: "details",
                table: "Prescription_Medicament",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "idPrescription",
                table: "Prescription_Medicament",
                newName: "IdPrescription");

            migrationBuilder.RenameColumn(
                name: "idMedicament",
                table: "Prescription_Medicament",
                newName: "IdMedicament");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_Medicament_idPrescription",
                table: "Prescription_Medicament",
                newName: "IX_Prescription_Medicament_IdPrescription");

            migrationBuilder.RenameColumn(
                name: "idPatient",
                table: "Prescription",
                newName: "IdPatient");

            migrationBuilder.RenameColumn(
                name: "idDoctor",
                table: "Prescription",
                newName: "IdDoctor");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "Prescription",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Prescription",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "idPresciption",
                table: "Prescription",
                newName: "IdPresciption");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_idPatient",
                table: "Prescription",
                newName: "IX_Prescription_IdPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_idDoctor",
                table: "Prescription",
                newName: "IX_Prescription_IdDoctor");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Patient",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Patient",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Patient",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "idPatient",
                table: "Patient",
                newName: "IdPatient");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Medicament",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Medicament",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Medicament",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "idMedicament",
                table: "Medicament",
                newName: "IdMedicament");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Doctor",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Doctor",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Doctor",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "idDoctor",
                table: "Doctor",
                newName: "IdDoctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dose",
                table: "Prescription_Medicament",
                newName: "dose");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Prescription_Medicament",
                newName: "details");

            migrationBuilder.RenameColumn(
                name: "IdPrescription",
                table: "Prescription_Medicament",
                newName: "idPrescription");

            migrationBuilder.RenameColumn(
                name: "IdMedicament",
                table: "Prescription_Medicament",
                newName: "idMedicament");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                newName: "IX_Prescription_Medicament_idPrescription");

            migrationBuilder.RenameColumn(
                name: "IdPatient",
                table: "Prescription",
                newName: "idPatient");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Prescription",
                newName: "idDoctor");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Prescription",
                newName: "dueDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Prescription",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "IdPresciption",
                table: "Prescription",
                newName: "idPresciption");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                newName: "IX_Prescription_idPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                newName: "IX_Prescription_idDoctor");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Patient",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Patient",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Patient",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "IdPatient",
                table: "Patient",
                newName: "idPatient");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Medicament",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Medicament",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Medicament",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "IdMedicament",
                table: "Medicament",
                newName: "idMedicament");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Doctor",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Doctor",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Doctor",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Doctor",
                newName: "idDoctor");
        }
    }
}
