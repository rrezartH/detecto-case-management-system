// <auto-generated />
using System;
using Detecto.API.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Detecto.API.Migrations
{
    [DbContext(typeof(DetectoDbContext))]
    [Migration("20230127200237_caseId_DCase_Edit")]
    partial class caseId_DCase_Edit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Detecto.API.Case.Models.DCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.Detective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Detectives");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.DTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DTask");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DCaseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DCaseId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.Deklarata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("KohaEMarrjes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Permbajtja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deklaratat");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.GjurmaBiologjike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Emertimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lloji")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GjurmetBiologjike");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.Personi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int?>("DCaseId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EKaluara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GjendjaMendore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gjinia")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Profesioni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statusi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendbanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DCaseId");

                    b.ToTable("Personat");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personi");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.Prova", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Attachment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KohaENxjerrjes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vendndodhja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provat");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Prova");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.CaseTask", b =>
                {
                    b.HasBaseType("Detecto.API.Case.Models.DTask");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int?>("DCaseId")
                        .HasColumnType("int");

                    b.HasIndex("DCaseId");

                    b.HasDiscriminator().HasValue("CaseTask");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.Deshmitari", b =>
                {
                    b.HasBaseType("Detecto.API.Data.Models.Personi");

                    b.Property<bool>("Dyshohet")
                        .HasColumnType("bit");

                    b.Property<string>("RaportiMeViktimen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vezhgohet")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Deshmitari");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.iDyshuari", b =>
                {
                    b.HasBaseType("Detecto.API.Data.Models.Personi");

                    b.Property<string>("Dyshimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("iDyshuari");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.ProvaBiologjike", b =>
                {
                    b.HasBaseType("Detecto.API.Data.Models.Prova");

                    b.Property<string>("TeknikaENxjerrjes")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ProvaBiologjike");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.ProvaFizike", b =>
                {
                    b.HasBaseType("Detecto.API.Data.Models.Prova");

                    b.Property<bool>("DuhetEkzaminim")
                        .HasColumnType("bit");

                    b.Property<bool>("EPerdorurNeKrim")
                        .HasColumnType("bit");

                    b.Property<bool>("KaGjurmeBiologjike")
                        .HasColumnType("bit");

                    b.Property<string>("Klasifikimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rrezikshmeria")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ProvaFizike");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.Viktima", b =>
                {
                    b.HasBaseType("Detecto.API.Data.Models.Personi");

                    b.Property<string>("Gjendja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Koha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Menyra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Viktima");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.File", b =>
                {
                    b.HasOne("Detecto.API.Case.Models.DCase", null)
                        .WithMany("Files")
                        .HasForeignKey("DCaseId");
                });

            modelBuilder.Entity("Detecto.API.Data.Models.Personi", b =>
                {
                    b.HasOne("Detecto.API.Case.Models.DCase", null)
                        .WithMany("Palet")
                        .HasForeignKey("DCaseId");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.CaseTask", b =>
                {
                    b.HasOne("Detecto.API.Case.Models.DCase", null)
                        .WithMany("CaseTasks")
                        .HasForeignKey("DCaseId");
                });

            modelBuilder.Entity("Detecto.API.Case.Models.DCase", b =>
                {
                    b.Navigation("CaseTasks");

                    b.Navigation("Files");

                    b.Navigation("Palet");
                });
#pragma warning restore 612, 618
        }
    }
}
