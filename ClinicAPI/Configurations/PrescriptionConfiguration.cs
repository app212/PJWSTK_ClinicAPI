using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPresciption).HasName("Prescription_pk");

            builder.ToTable("Prescription");

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(d => d.IdPatientNavigation)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Patient_Prescription");

            builder.HasOne(d => d.IdDoctorNavigation)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Doctor_Prescription");

            IEnumerable<Prescription> prescriptions = new List<Prescription>
                {
                    new Prescription
                    {
                        IdPresciption = 1,
                        Date = new DateTime(2021, 6, 3),
                        DueDate = new DateTime(2021, 7, 3),
                        IdPatient = 1,
                        IdDoctor = 1
                    }
                };
            builder.HasData(prescriptions);
        }
    }
}
