﻿// <auto-generated />
using System;
using LisaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LisaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240629182723_TenantLeaseId")]
    partial class TenantLeaseId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LisaApi.Models.Lease", b =>
                {
                    b.Property<int>("LeaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LeaseId"));

                    b.Property<byte[]>("AgreementFormFileData")
                        .HasColumnType("bytea");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PlacedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("LeaseId");

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("LisaApi.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PropertyId"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("MeterImg")
                        .HasColumnType("text");

                    b.Property<string>("MeterNumber")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("RentalStatus")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PropertyId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("LisaApi.Models.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TenantId"));

                    b.Property<string>("AddressofNextofKin")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GhanaCard")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NextOfKin")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("LisaApi.Models.TenantLease", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LeaseDuration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LeaseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TenantLeaseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PropertyId", "TenantId");

                    b.HasIndex("LeaseId");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantLeases");
                });

            modelBuilder.Entity("LisaApi.Models.Witness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressofNextofKin")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NextOfKin")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<int?>("TenantLeasePropertyId")
                        .HasColumnType("integer");

                    b.Property<int?>("TenantLeaseTenantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TenantLeasePropertyId", "TenantLeaseTenantId");

                    b.ToTable("Witnesses");
                });

            modelBuilder.Entity("LisaApi.Models.TenantLease", b =>
                {
                    b.HasOne("LisaApi.Models.Lease", "Lease")
                        .WithMany()
                        .HasForeignKey("LeaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LisaApi.Models.Property", "Property")
                        .WithMany("TenantLease")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LisaApi.Models.Tenant", "Tenant")
                        .WithMany("TenantLease")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lease");

                    b.Navigation("Property");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("LisaApi.Models.Witness", b =>
                {
                    b.HasOne("LisaApi.Models.TenantLease", null)
                        .WithMany("Witnesses")
                        .HasForeignKey("TenantLeasePropertyId", "TenantLeaseTenantId");
                });

            modelBuilder.Entity("LisaApi.Models.Property", b =>
                {
                    b.Navigation("TenantLease");
                });

            modelBuilder.Entity("LisaApi.Models.Tenant", b =>
                {
                    b.Navigation("TenantLease");
                });

            modelBuilder.Entity("LisaApi.Models.TenantLease", b =>
                {
                    b.Navigation("Witnesses");
                });
#pragma warning restore 612, 618
        }
    }
}
