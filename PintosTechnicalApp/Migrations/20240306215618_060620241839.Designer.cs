﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PintosTechnicalApp.Config;

#nullable disable

namespace PintosTechnicalApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240306215618_060620241839")]
    partial class _060620241839
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PintosTechnicalApp.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Stadium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("StadiumId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TrainerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Player", b =>
                {
                    b.HasOne("PintosTechnicalApp.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Team", b =>
                {
                    b.HasOne("PintosTechnicalApp.Entities.Stadium", "Stadium")
                        .WithOne("Team")
                        .HasForeignKey("PintosTechnicalApp.Entities.Team", "StadiumId");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Trainer", b =>
                {
                    b.HasOne("PintosTechnicalApp.Entities.Team", "Team")
                        .WithOne("Trainer")
                        .HasForeignKey("PintosTechnicalApp.Entities.Trainer", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Stadium", b =>
                {
                    b.Navigation("Team");
                });

            modelBuilder.Entity("PintosTechnicalApp.Entities.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Trainer");
                });
#pragma warning restore 612, 618
        }
    }
}
