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
        public DbSet<GLPR> GLPR { get; set; } = default!;
        public DbSet<TypePr> TypePr { get; set; } = default!;
        public DbSet<Spec> Spec { get; set; } = default!;
        public DbSet<StrRozv> StrRozv { get; set; } = default!;
        public DbSet<SumRozv> SumRozv { get; set; } = default!;
        public DbSet<ZastMt> ZastMt { get; set; } = default!;
        public DbSet<DovMt> DovMt { get; set; } = default!;
        public DbSet<DovTO> DovTO { get; set; } = default!;
        public DbSet<PTRN> PTRN { get; set; } = default!;
        public DbSet<TechnNorm> TechNorm { get; set; } = default!;
        
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

                entity.HasOne(d => d.CdTpNavigation).WithMany(p => p.GLPRNavigations).HasForeignKey(d => d.CdTp);
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
                entity.HasKey(e => e.Id);

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

            modelBuilder.Entity<SumRozv>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SumRozv");

                entity.HasOne(d => d.CdVyrNavigation).WithMany(p => p.SumRozvCdVyrNavigations)
                    .HasForeignKey(d => d.CdVyr)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.CdKpNavigation).WithMany(p => p.SumRozvCdKpNavigations)
                    .HasForeignKey(d => d.CdKp)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.CdTpNavigation).WithMany(p => p.SumRozvNavigations)
                    .HasForeignKey(d => d.CdTp)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TypePr>(entity =>
            {
                entity.HasKey(e => e.CdTp);

                entity.ToTable("TypePr");
            });

            modelBuilder.Entity<ZastMt>(entity =>
            {
                entity.HasKey(e => new { e.CdKp, e.CdMt });

                entity.ToTable("ZastMt");

                entity.HasOne(d => d.CdKpNavigation).WithMany(p => p.ZastMtCdKpNavigations)
                    .HasForeignKey(d => d.CdKp)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.CdMtNavigation).WithMany(p => p.ZastMtCdMtNavigations)
                    .HasForeignKey(d => d.CdMt)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DovMt>(entity =>
            {
                entity.HasKey(e => e.CdMt);

                entity.ToTable("DovMt");
            });

            modelBuilder.Entity<DovTO>(entity =>
            {
                entity.HasKey(e => e.CdTO);

                entity.ToTable("DovTO");
            });

            modelBuilder.Entity<PTRN>(entity =>
            {
                entity.HasKey(e => new { e.CdPr, e.CdTO });

                entity.ToTable("PTRN");

                entity.HasOne(d => d.CdPrNavigation).WithMany(p => p.PTRNCdPrNavigations)
                    .HasForeignKey(d => d.CdPr)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.CdTONavigation).WithMany(p => p.PTRNCdTONavigations)
                    .HasForeignKey(d => d.CdTO)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TechnNorm>(entity =>
            {
                entity.HasKey(e => new { e.CdVyr, e.CdTO });

                entity.ToTable("TechNorm");
            });
        }
    }
}
