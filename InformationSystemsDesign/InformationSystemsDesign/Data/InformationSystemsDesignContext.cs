using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InformationSystemsDesign.Models;
using System.Runtime.CompilerServices;

namespace InformationSystemsDesign.Data
{
    public class InformationSystemsDesignContext : DbContext
    {
        public InformationSystemsDesignContext(DbContextOptions<InformationSystemsDesignContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GLPR>(entity =>
        {
            entity.HasKey(e => e.CdPr);

            entity.ToTable("GLPR");

            entity.HasIndex(e => e.CdTp, "IX_GLPR_CdTp");

            entity.HasOne(d => d.CdTpNavigation).WithMany(p => p.GLPRs).HasForeignKey(d => d.CdTp);
        });

            modelBuilder.Entity<Spec>(entity =>
            {
                entity.HasKey(e => new { e.CdSb, e.CdKp });

                entity.ToTable("Spec");

                entity.HasIndex(e => e.CdKp, "IX_Spec_CdKp");

                entity.ToTable(t => t.HasCheckConstraint("CK_Spec_CdSb", "[CdSb] != [CdKp]"));
                entity.ToTable(t => t.HasCheckConstraint("CK_Spec_CdKp", "[CdKp] != [CdSb]"));
                entity.ToTable(t => t.HasCheckConstraint("CK_Spec_QtyKp", "[QtyKp] >= 0"));

                entity.HasOne(d => d.CdKpNavigation).WithMany(p => p.SpecCdKpNavigations)
                    .HasForeignKey(d => d.CdKp)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.CdSbNavigation).WithMany(p => p.SpecCdSbNavigations)
                    .HasForeignKey(d => d.CdSb)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<StrRozv>(entity =>
            {
                entity.HasKey(e => new { e.CdVyr, e.CdSb, e.CdKp });

                entity.ToTable("StrRozv");

                entity.HasIndex(e => e.CdVyr, "IX_StrRozv_CdVyr");

                entity.Property(e => e.RivGrf)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('.1')");
                entity.Property(e => e.RivNb).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CdVyrNavigation).WithMany(p => p.StrRozvCdVyrNavigations)
                    .HasForeignKey(d => d.CdVyr)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.CdSbNavigation).WithMany(p => p.StrRozvCdSbNavigations)
                    .HasForeignKey(d => d.CdSb)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.CdKpNavigation).WithMany(p => p.StrRozvCdKpNavigations)
                    .HasForeignKey(d => d.CdKp)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TypePr>(entity =>
            {
                entity.HasKey(e => e.CdTp);

                entity.ToTable("TypePr");
            });
        }
        public DbSet<InformationSystemsDesign.Models.GLPR> GLPR { get; set; } = default!;
        public DbSet<InformationSystemsDesign.Models.TypePr> TypePr { get; set; }
        public DbSet<InformationSystemsDesign.Models.Spec> Spec { get; set; }
        public DbSet<StrRozv> StrRozv { get; set; }

    }
}
