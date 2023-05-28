﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoomService.Models;

#nullable disable

namespace RoomService.Migrations
{
    [DbContext(typeof(RoomContext))]
    partial class RoomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelService.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HotelId = 1,
                            Price = 999.0,
                            RoomNumber = "20A",
                            RoomType = "AC"
                        },
                        new
                        {
                            Id = 2,
                            HotelId = 1,
                            Price = 555.0,
                            RoomNumber = "20B",
                            RoomType = "AC"
                        },
                        new
                        {
                            Id = 3,
                            HotelId = 2,
                            Price = 666.0,
                            RoomNumber = "30A",
                            RoomType = "NonAC"
                        },
                        new
                        {
                            Id = 4,
                            HotelId = 2,
                            Price = 2999.0,
                            RoomNumber = "30B",
                            RoomType = "AC"
                        },
                        new
                        {
                            Id = 5,
                            HotelId = 3,
                            Price = 4999.0,
                            RoomNumber = "40A",
                            RoomType = "AC"
                        },
                        new
                        {
                            Id = 6,
                            HotelId = 3,
                            Price = 1199.0,
                            RoomNumber = "40B",
                            RoomType = "NonAC"
                        },
                        new
                        {
                            Id = 7,
                            HotelId = 4,
                            Price = 3999.0,
                            RoomNumber = "50A",
                            RoomType = "AC"
                        },
                        new
                        {
                            Id = 8,
                            HotelId = 4,
                            Price = 1999.0,
                            RoomNumber = "50B",
                            RoomType = "NonAC"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
