using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Configurations
{
    public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("PrescriptionMedicament_pk");

            builder.ToTable("Prescription_Medicament");

            builder.Property(e => e.Dose);
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.IdMedicamentNavigation)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_PrescriptionMedicament");

            builder.HasOne(d => d.IdPrescriptionNavigation)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_PrescriptionMedicament");

            IEnumerable<PrescriptionMedicament> prescriptionMedicaments = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 5,
                    Details = "opis"
                }
            };
            builder.HasData(prescriptionMedicaments);
        }
    }
}
