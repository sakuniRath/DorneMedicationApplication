using DroneForMedication.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.DataContext
{
    internal class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase(databaseName:"DorneDb");
            
        }
        public DbSet<Dorne> Dornes { get; set; }
        public DbSet<Medication> Medications { get; set; }

        public DbSet<DorneMedication> DorneMedications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<DorneMedication>().HasKey(dr => new { dr.DorneId, dr.MedicationId,dr.CurrentDate });
            modelBuilder.Entity<DorneMedication>().HasOne(dr=>dr.Dorne).WithMany(m=>m.DorneMedications).HasForeignKey(dr => dr.DorneId);
            modelBuilder.Entity<DorneMedication>().HasOne(mc => mc.Medication).WithMany(m => m.DorneMedications).HasForeignKey(mc => mc.MedicationId);


        }

    }
}
