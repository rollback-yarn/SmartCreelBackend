using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartCreelBackend.Model
{
    public partial class SmartcreeldbContext : DbContext
    {
        public SmartcreeldbContext()
        {
        }

        public SmartcreeldbContext(DbContextOptions<SmartcreeldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Creel> Creel { get; set; }
        public virtual DbSet<CreelSide> CreelSide { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=smartcreeldbserver.database.windows.net;Initial Catalog=SmartCreelDb;Persist Security Info=True;User ID=smartcreelAdmin;Password=hackthon+2019");
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Creel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreelSideAid).HasColumnName("CreelSideAId");

                entity.Property(e => e.CreelSideBid).HasColumnName("CreelSideBId");

                entity.HasOne(d => d.CreelSideA)
                    .WithMany(p => p.CreelCreelSideA)
                    .HasForeignKey(d => d.CreelSideAid)
                    .HasConstraintName("FK__Creel__CreelSide__534D60F1");

                entity.HasOne(d => d.CreelSideB)
                    .WithMany(p => p.CreelCreelSideB)
                    .HasForeignKey(d => d.CreelSideBid)
                    .HasConstraintName("FK__Creel__CreelSide__5441852A");
            });

            modelBuilder.Entity<CreelSide>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LoadingTime).HasColumnType("datetime");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.CreelSide)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("FK__CreelSide__Machi__5070F446");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}