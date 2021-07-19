﻿// <auto-generated />
using System;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicAPI.Migrations
{
    [DbContext(typeof(ClinicContext))]
    [Migration("20210603172121_AdddClinicTables")]
    partial class AdddClinicTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicAPI.Models.Doctor", b =>
                {
                    b.Property<int>("idDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idDoctor")
                        .HasName("Doctor_pk");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            idDoctor = 1,
                            email = "test@doktor.pl",
                            firstName = "Test",
                            lastName = "Doktor"
                        });
                });

            modelBuilder.Entity("ClinicAPI.Models.Medicament", b =>
                {
                    b.Property<int>("idMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idMedicament")
                        .HasName("Medicament_pk");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            idMedicament = 1,
                            description = "Testowy lek",
                            name = "Meds1",
                            type = "typowy"
                        });
                });

            modelBuilder.Entity("ClinicAPI.Models.Patient", b =>
                {
                    b.Property<int>("idPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idPatient")
                        .HasName("Patient_pk");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            idPatient = 1,
                            birthdate = new DateTime(1999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Patient",
                            lastName = "Test"
                        });
                });

            modelBuilder.Entity("ClinicAPI.Models.Prescription", b =>
                {
                    b.Property<int>("idPresciption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("idDoctor")
                        .HasColumnType("int");

                    b.Property<int>("idPatient")
                        .HasColumnType("int");

                    b.HasKey("idPresciption")
                        .HasName("Prescription_pk");

                    b.HasIndex("idDoctor");

                    b.HasIndex("idPatient");

                    b.ToTable("Prescription");

                    b.HasData(
                        new
                        {
                            idPresciption = 1,
                            date = new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            dueDate = new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            idDoctor = 1,
                            idPatient = 1
                        });
                });

            modelBuilder.Entity("ClinicAPI.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("idMedicament")
                        .HasColumnType("int");

                    b.Property<int>("idPrescription")
                        .HasColumnType("int");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("dose")
                        .HasColumnType("int");

                    b.HasKey("idMedicament", "idPrescription")
                        .HasName("PrescriptionMedicament_pk");

                    b.HasIndex("idPrescription");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            idMedicament = 1,
                            idPrescription = 1,
                            details = "opis",
                            dose = 5
                        });
                });

            modelBuilder.Entity("ClinicAPI.Models.Prescription", b =>
                {
                    b.HasOne("ClinicAPI.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("idDoctor")
                        .HasConstraintName("Doctor_Prescription")
                        .IsRequired();

                    b.HasOne("ClinicAPI.Models.Patient", "IdPatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("idPatient")
                        .HasConstraintName("Patient_Prescription")
                        .IsRequired();

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("ClinicAPI.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("ClinicAPI.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("idMedicament")
                        .HasConstraintName("Medicament_PrescriptionMedicament")
                        .IsRequired();

                    b.HasOne("ClinicAPI.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("idPrescription")
                        .HasConstraintName("Prescription_PrescriptionMedicament")
                        .IsRequired();

                    b.Navigation("IdMedicamentNavigation");

                    b.Navigation("IdPrescriptionNavigation");
                });

            modelBuilder.Entity("ClinicAPI.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("ClinicAPI.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("ClinicAPI.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("ClinicAPI.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}