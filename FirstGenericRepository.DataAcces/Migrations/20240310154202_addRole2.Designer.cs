﻿// <auto-generated />
using System;
using FirstGenericRepository.DataAcces.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstGenericRepository.DataAcces.Migrations
{
    [DbContext(typeof(FirstGenericRepositoryDbContext))]
    [Migration("20240310154202_addRole2")]
    partial class addRole2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Chuck",
                            LastName = "Norris"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Van",
                            LastName = "Damne"
                        });
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Biography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActorId")
                        .IsUnique();

                    b.ToTable("Biography");
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActorId = 1,
                            Description = "Box office coming",
                            Name = "WakandaForEver"
                        },
                        new
                        {
                            Id = 2,
                            ActorId = 2,
                            Description = "Box office coming two",
                            Name = "WakandaForEver2"
                        },
                        new
                        {
                            Id = 3,
                            ActorId = 3,
                            Description = "Box office coming three",
                            Name = "WakandaForEver3"
                        },
                        new
                        {
                            Id = 4,
                            ActorId = 2,
                            Description = "Box office coming two",
                            Name = "WakandaForEver2bis"
                        });
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Biography", b =>
                {
                    b.HasOne("FirstGenericRepository.Domain.Entity.Actor", "Actor")
                        .WithOne("Biography")
                        .HasForeignKey("FirstGenericRepository.Domain.Entity.Biography", "ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Movie", b =>
                {
                    b.HasOne("FirstGenericRepository.Domain.Entity.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("FirstGenericRepository.Domain.Entity.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstGenericRepository.Domain.Entity.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstGenericRepository.Domain.Entity.Actor", b =>
                {
                    b.Navigation("Biography");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
