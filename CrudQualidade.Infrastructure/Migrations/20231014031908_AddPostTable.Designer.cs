﻿// <auto-generated />
using System;
using CrudQualidade.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudQualidade.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231014031908_AddPostTable")]
    partial class AddPostTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("CrudQualidade.Domain.Entities.Friendship", b =>
                {
                    b.Property<int>("PersonId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId2")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonId1", "PersonId2");

                    b.HasIndex("PersonId2");

                    b.ToTable("Friendships");

                    b.HasData(
                        new
                        {
                            PersonId1 = 1,
                            PersonId2 = 2
                        });
                });

            modelBuilder.Entity("CrudQualidade.Domain.Entities.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Peoples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 25,
                            City = "Rio Verde",
                            Email = "lucas@email.com",
                            LastName = "Oliveira",
                            Name = "Lucas",
                            NumberPhone = "64123456879"
                        },
                        new
                        {
                            Id = 2,
                            Age = 44,
                            City = "Rio Verde",
                            Email = "marcia@email.com",
                            LastName = "Oliveira",
                            Name = "Márcia",
                            NumberPhone = "64123412342"
                        });
                });

            modelBuilder.Entity("CrudQualidade.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatePost")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeopleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Primeira postagem de Lucas :)",
                            DatePost = new DateTime(2023, 10, 14, 0, 19, 8, 669, DateTimeKind.Local).AddTicks(2012),
                            PeopleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Márcia disse que Deus está vivo <3",
                            DatePost = new DateTime(2023, 10, 14, 0, 19, 8, 669, DateTimeKind.Local).AddTicks(2026),
                            PeopleId = 2
                        });
                });

            modelBuilder.Entity("CrudQualidade.Domain.Entities.Friendship", b =>
                {
                    b.HasOne("CrudQualidade.Domain.Entities.People", "People1")
                        .WithMany("FriendshipsInitialized")
                        .HasForeignKey("PersonId1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CrudQualidade.Domain.Entities.People", "People2")
                        .WithMany("FriendshipsAccepted")
                        .HasForeignKey("PersonId2")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("People1");

                    b.Navigation("People2");
                });

            modelBuilder.Entity("CrudQualidade.Domain.Entities.Post", b =>
                {
                    b.HasOne("CrudQualidade.Domain.Entities.People", "People")
                        .WithMany("Post")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });

            modelBuilder.Entity("CrudQualidade.Domain.Entities.People", b =>
                {
                    b.Navigation("FriendshipsAccepted");

                    b.Navigation("FriendshipsInitialized");

                    b.Navigation("Post");
                });
#pragma warning restore 612, 618
        }
    }
}