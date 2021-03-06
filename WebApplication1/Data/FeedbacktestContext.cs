// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.Data
{
    public partial class FeedbacktestContext : DbContext
    {
        public FeedbacktestContext()
        {
        }

        public FeedbacktestContext(DbContextOptions<FeedbacktestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Behavior> Behavior { get; set; }
        public virtual DbSet<Competency> Competency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Behavior>(entity =>
            {
                entity.HasOne(d => d.Competency)
                    .WithMany(p => p.Behavior)
                    .HasForeignKey(d => d.CompetencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Behavior_ToCompetency");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}