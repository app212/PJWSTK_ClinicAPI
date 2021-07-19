using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor).HasName("Doctor_pk");

            builder.ToTable("Doctor");

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);

            IEnumerable<Doctor> doctors = new List<Doctor>
                {
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Test",
                        LastName = "Doktor",
                        Email = "test@doktor.pl"
                    }
                };
            builder.HasData(doctors);
        }
    }
}
