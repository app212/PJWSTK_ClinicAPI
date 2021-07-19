using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Configurations
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament).HasName("Medicament_pk");

            builder.ToTable("Medicament");

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);

            IEnumerable<Medicament> medicaments = new List<Medicament>
                {
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "Meds1",
                        Description = "Testowy lek",
                        Type = "typowy"
                    }
                };
            builder.HasData(medicaments);
        }
    }
}
