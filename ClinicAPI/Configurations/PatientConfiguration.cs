using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("Patient_pk");

            builder.ToTable("Patient");

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Birthdate).IsRequired();

            IEnumerable<Patient> patients = new List<Patient>
                {
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Patient",
                        LastName = "Test",
                        Birthdate = new DateTime(1999, 12, 31)
                    }
                };
            builder.HasData(patients);
        }
    }
}
