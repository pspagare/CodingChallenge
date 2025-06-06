﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vypex.CodingChallenge.Infrastructure.Data;

#nullable disable

namespace Vypex.CodingChallenge.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CodingChallengeContext))]
    [Migration("20250413164504_CreateLeaveDay")]
    partial class CreateLeaveDay
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("Vypex.CodingChallenge.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Vypex.CodingChallenge.Domain.Models.LeaveDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveDays");
                });

            modelBuilder.Entity("Vypex.CodingChallenge.Domain.Models.LeaveDay", b =>
                {
                    b.HasOne("Vypex.CodingChallenge.Domain.Models.Employee", "Employee")
                        .WithMany("Leaves")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Vypex.CodingChallenge.Domain.Models.Employee", b =>
                {
                    b.Navigation("Leaves");
                });
#pragma warning restore 612, 618
        }
    }
}
