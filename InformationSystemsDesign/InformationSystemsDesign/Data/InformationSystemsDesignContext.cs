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
            modelBuilder.Entity<Spec>().HasKey(k => new { k.CdSb, k.CdKp });

            modelBuilder.Entity<Spec>().ToTable(entity 
                => entity.HasCheckConstraint("CK_Spec_CdSb", "[CdSb] != [CdKp]"));
            modelBuilder.Entity<Spec>().ToTable(entity
                => entity.HasCheckConstraint("CK_Spec_CdKp", "[CdKp] != [CdSb]"));
            modelBuilder.Entity<Spec>().ToTable(entity
                => entity.HasCheckConstraint("CK_Spec_QtyKp", "[QtyKp] >= 0"));
        }
        public DbSet<InformationSystemsDesign.Models.GLPR> GLPR { get; set; } = default!;
        public DbSet<InformationSystemsDesign.Models.TypePr> TypePr { get; set; }
        public DbSet<InformationSystemsDesign.Models.Spec> Spec { get; set; }

    }
}
