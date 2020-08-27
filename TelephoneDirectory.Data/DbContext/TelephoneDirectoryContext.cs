using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Data
{
    public partial class TelephoneDirectoryContext : DbContext
    {
        private IConfiguration _configuration;

        public TelephoneDirectoryContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        
        public TelephoneDirectoryContext(DbContextOptions<TelephoneDirectoryContext> options)
            :base(options)
        {
                
        }
        public DbSet<PhoneBook> PhoneBook { get; set; }
        public DbSet<Entry> Entry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseSqlite("Filename=TelephoneDirectory.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBook>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);
                
            });
            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(e => e.PhoneBookId).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(10);
                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasOne(d => d.PhoneBook)
                    .WithMany(d => d.Entry)
                    .HasForeignKey(d => d.PhoneBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entry_PhoneBook");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
