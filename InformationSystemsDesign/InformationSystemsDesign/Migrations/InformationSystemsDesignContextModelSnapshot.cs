﻿// <auto-generated />
using InformationSystemsDesign.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    [DbContext(typeof(InformationSystemsDesignContext))]
    partial class InformationSystemsDesignContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InformationSystemsDesign.Models.GLPR", b =>
                {
                    b.Property<string>("CdPr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CdTp")
                        .HasColumnType("int");

                    b.Property<string>("NmPr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdPr");

                    b.HasIndex("CdTp");

                    b.ToTable("GLPR");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.Spec", b =>
                {
                    b.Property<string>("CdSb")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CdKp")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QtyKp")
                        .HasColumnType("int");

                    b.HasKey("CdSb", "CdKp");

                    b.HasIndex("CdKp");

                    b.ToTable("Spec", t =>
                        {
                            t.HasCheckConstraint("CK_Spec_CdKp", "[CdKp] != [CdSb]");

                            t.HasCheckConstraint("CK_Spec_CdSb", "[CdSb] != [CdKp]");

                            t.HasCheckConstraint("CK_Spec_QtyKp", "[QtyKp] >= 0");
                        });
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.TypePr", b =>
                {
                    b.Property<int>("CdTp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdTp"));

                    b.Property<string>("NmTp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdTp");

                    b.ToTable("TypePr");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.GLPR", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.TypePr", "TypePr")
                        .WithMany()
                        .HasForeignKey("CdTp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypePr");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.Spec", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.GLPR", "GLPR_CdKp")
                        .WithMany()
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.GLPR", "GLPR_CdSb")
                        .WithMany()
                        .HasForeignKey("CdSb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GLPR_CdKp");

                    b.Navigation("GLPR_CdSb");
                });
#pragma warning restore 612, 618
        }
    }
}
