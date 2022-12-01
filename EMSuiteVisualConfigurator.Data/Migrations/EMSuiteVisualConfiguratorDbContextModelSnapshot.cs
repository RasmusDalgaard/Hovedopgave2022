﻿// <auto-generated />
using System;
using EMSuiteVisualConfigurator.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMSuiteVisualConfigurator.Data.Migrations
{
    [DbContext(typeof(EMSuiteVisualConfiguratorDbContext))]
    partial class EMSuiteVisualConfiguratorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("EntitySequence");

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Primitives.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [EntitySequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.AccessPoint", b =>
                {
                    b.HasBaseType("EMSuiteVisualConfigurator.CoreBusiness.Primitives.Entity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasIndex("ZoneId");

                    b.ToTable("accessPoints");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.EMSuiteConfiguration", b =>
                {
                    b.HasBaseType("EMSuiteVisualConfigurator.CoreBusiness.Primitives.Entity");

                    b.ToTable("emsuiteConfigurations");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Sensor", b =>
                {
                    b.HasBaseType("EMSuiteVisualConfigurator.CoreBusiness.Primitives.Entity");

                    b.ToTable("sensors");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Site", b =>
                {
                    b.HasBaseType("EMSuiteVisualConfigurator.CoreBusiness.Primitives.Entity");

                    b.Property<int?>("EMSuiteConfigurationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("EMSuiteConfigurationId");

                    b.ToTable("sites");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Zone", b =>
                {
                    b.HasBaseType("EMSuiteVisualConfigurator.CoreBusiness.Primitives.Entity");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int");

                    b.HasIndex("SiteId");

                    b.ToTable("zones");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.AccessPoint", b =>
                {
                    b.HasOne("EMSuiteVisualConfigurator.CoreBusiness.Entities.Zone", null)
                        .WithMany("AccessPoints")
                        .HasForeignKey("ZoneId");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Site", b =>
                {
                    b.HasOne("EMSuiteVisualConfigurator.CoreBusiness.Entities.EMSuiteConfiguration", null)
                        .WithMany("Sites")
                        .HasForeignKey("EMSuiteConfigurationId");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Zone", b =>
                {
                    b.HasOne("EMSuiteVisualConfigurator.CoreBusiness.Entities.Site", null)
                        .WithMany("Zones")
                        .HasForeignKey("SiteId");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.EMSuiteConfiguration", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Site", b =>
                {
                    b.Navigation("Zones");
                });

            modelBuilder.Entity("EMSuiteVisualConfigurator.CoreBusiness.Entities.Zone", b =>
                {
                    b.Navigation("AccessPoints");
                });
#pragma warning restore 612, 618
        }
    }
}