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

            modelBuilder.Entity("InformationSystemsDesign.Models.DovMt", b =>
                {
                    b.Property<string>("CdMt")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NmMt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdMt");

                    b.ToTable("DovMt", (string)null);
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.DovTO", b =>
                {
                    b.Property<string>("CdTO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NmTO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdTO");

                    b.ToTable("DovTO", (string)null);
                });

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

                    b.HasIndex(new[] { "CdTp" }, "IX_GLPR_CdTp");

                    b.ToTable("GLPR", (string)null);
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.PTRN", b =>
                {
                    b.Property<string>("CdPr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CdTO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Godin")
                        .HasColumnType("real");

                    b.Property<string>("NbTO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdPr", "CdTO");

                    b.HasIndex("CdTO");

                    b.ToTable("PTRN", (string)null);
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

                    b.HasIndex(new[] { "CdKp" }, "IX_Spec_CdKp");

                    b.ToTable("Spec", null, t =>
                        {
                            t.HasCheckConstraint("CK_Spec_CdKp", "[CdKp] != [CdSb]");

                            t.HasCheckConstraint("CK_Spec_CdSb", "[CdSb] != [CdKp]");

                            t.HasCheckConstraint("CK_Spec_QtyKp", "[QtyKp] >= 0");
                        });
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.StrRozv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CdKp")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CdSb")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CdVyr")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QtyKp")
                        .HasColumnType("int");

                    b.Property<string>("RivGrf")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("('.1')");

                    b.Property<int>("RivNb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Id");

                    b.HasIndex("CdKp");

                    b.HasIndex("CdSb");

                    b.HasIndex(new[] { "CdVyr" }, "IX_StrRozv_CdVyr");

                    b.ToTable("StrRozv", (string)null);
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.SumRozv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CdKp")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CdTp")
                        .HasColumnType("int");

                    b.Property<string>("CdVyr")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MinRv")
                        .HasColumnType("int");

                    b.Property<int>("SumKp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CdKp");

                    b.HasIndex("CdTp");

                    b.HasIndex("CdVyr");

                    b.ToTable("SumRozv", (string)null);
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.TechnNorm", b =>
                {
                    b.Property<string>("CdVyr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CdTO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NmTO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SumGodin")
                        .HasColumnType("real");

                    b.HasKey("CdVyr", "CdTO");

                    b.ToTable("TechNorm", (string)null);
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

                    b.ToTable("TypePr", (string)null);
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.ZastMt", b =>
                {
                    b.Property<string>("CdKp")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CdMt")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OdVym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("QtyMt")
                        .HasColumnType("real");

                    b.HasKey("CdKp", "CdMt");

                    b.HasIndex("CdMt");

                    b.ToTable("ZastMt", (string)null);
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.GLPR", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.TypePr", "CdTpNavigation")
                        .WithMany("GLPRNavigations")
                        .HasForeignKey("CdTp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CdTpNavigation");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.PTRN", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdPrNavigation")
                        .WithMany("PTRNCdPrNavigations")
                        .HasForeignKey("CdPr")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.DovTO", "CdTONavigation")
                        .WithMany("PTRNCdTONavigations")
                        .HasForeignKey("CdTO")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CdPrNavigation");

                    b.Navigation("CdTONavigation");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.Spec", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdKpNavigation")
                        .WithMany("SpecCdKpNavigations")
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdSbNavigation")
                        .WithMany("SpecCdSbNavigations")
                        .HasForeignKey("CdSb")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CdKpNavigation");

                    b.Navigation("CdSbNavigation");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.StrRozv", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdKpNavigation")
                        .WithMany("StrRozvCdKpNavigations")
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdSbNavigation")
                        .WithMany("StrRozvCdSbNavigations")
                        .HasForeignKey("CdSb")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdVyrNavigation")
                        .WithMany("StrRozvCdVyrNavigations")
                        .HasForeignKey("CdVyr")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CdKpNavigation");

                    b.Navigation("CdSbNavigation");

                    b.Navigation("CdVyrNavigation");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.SumRozv", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdKpNavigation")
                        .WithMany("SumRozvCdKpNavigations")
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.TypePr", "CdTpNavigation")
                        .WithMany("SumRozvNavigations")
                        .HasForeignKey("CdTp")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdVyrNavigation")
                        .WithMany("SumRozvCdVyrNavigations")
                        .HasForeignKey("CdVyr")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CdKpNavigation");

                    b.Navigation("CdTpNavigation");

                    b.Navigation("CdVyrNavigation");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.ZastMt", b =>
                {
                    b.HasOne("InformationSystemsDesign.Models.GLPR", "CdKpNavigation")
                        .WithMany("ZastMtCdKpNavigations")
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InformationSystemsDesign.Models.DovMt", "CdMtNavigation")
                        .WithMany("ZastMtCdMtNavigations")
                        .HasForeignKey("CdMt")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CdKpNavigation");

                    b.Navigation("CdMtNavigation");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.DovMt", b =>
                {
                    b.Navigation("ZastMtCdMtNavigations");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.DovTO", b =>
                {
                    b.Navigation("PTRNCdTONavigations");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.GLPR", b =>
                {
                    b.Navigation("PTRNCdPrNavigations");

                    b.Navigation("SpecCdKpNavigations");

                    b.Navigation("SpecCdSbNavigations");

                    b.Navigation("StrRozvCdKpNavigations");

                    b.Navigation("StrRozvCdSbNavigations");

                    b.Navigation("StrRozvCdVyrNavigations");

                    b.Navigation("SumRozvCdKpNavigations");

                    b.Navigation("SumRozvCdVyrNavigations");

                    b.Navigation("ZastMtCdKpNavigations");
                });

            modelBuilder.Entity("InformationSystemsDesign.Models.TypePr", b =>
                {
                    b.Navigation("GLPRNavigations");

                    b.Navigation("SumRozvNavigations");
                });
#pragma warning restore 612, 618
        }
    }
}
