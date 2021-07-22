using Microsoft.EntityFrameworkCore;
using SampleProjectDatabase.DatabaseModels;
using SampleProjectDatabase.DataSeeds;
using System.Collections.Generic;

namespace SampleProjectDatabase.DatabaseContext
{
    public class CompanyManagementDbContext:DbContext
    {
        public CompanyManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Company> Company { get; set; }
        DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValueSql("('')");

                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Company>(entity =>
            {

                entity.HasOne(d => d.Person)
                    .WithMany(p=>p.Company)
                    .HasForeignKey(d => d.CEO)
                    .HasConstraintName("FK_Person_Box");
            });

            Seeds.PersonSeeds(modelBuilder);
        }
    }
}
