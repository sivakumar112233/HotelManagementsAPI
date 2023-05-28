﻿// <auto-generated />
using HotelService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelService.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20230527053846_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelService.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            Location = "Chennai",
                            Name = "oyo"
                        },
                        new
                        {
                            HotelId = 2,
                            Location = "Bangalore",
                            Name = "Novatel"
                        },
                        new
                        {
                            HotelId = 3,
                            Location = "Chennai",
                            Name = "yolo"
                        },
                        new
                        {
                            HotelId = 4,
                            Location = "Bangalore",
                            Name = "standardFord"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
