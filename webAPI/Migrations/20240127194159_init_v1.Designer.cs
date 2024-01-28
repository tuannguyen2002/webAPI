﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webAPI.DBContext;

#nullable disable

namespace webAPI.Migrations
{
    [DbContext(typeof(giaoTiepCSDL))]
    [Migration("20240127194159_init_v1")]
    partial class init_v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webAPI.Data.DangNhap.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("roleID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("roleID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("webAPI.Data.DangNhap.UserRole", b =>
                {
                    b.Property<string>("roleID")
                        .HasColumnType("text");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("roleID");

                    b.ToTable("userroles");
                });

            modelBuilder.Entity("webAPI.Data.HoaDon.chitiethoadon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ghichu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("giaban")
                        .HasColumnType("integer");

                    b.Property<Guid>("hoadonID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("sachID")
                        .HasColumnType("uuid");

                    b.Property<int>("soluong")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("hoadonID");

                    b.HasIndex("sachID");

                    b.ToTable("chitiethoadons");
                });

            modelBuilder.Entity("webAPI.Data.HoaDon.hoadon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("ghichu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("thoigianban")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("tongtien")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("hoadons");
                });

            modelBuilder.Entity("webAPI.Data.Nguon.nhaxb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ghichu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sdt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tennhaxb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("nhaxuatbans");
                });

            modelBuilder.Entity("webAPI.Data.Nguon.tacgia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ghichu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("quequan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tentacgia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tacgias");
                });

            modelBuilder.Entity("webAPI.Data.Sach.sach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ghichu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("giaban")
                        .HasColumnType("integer");

                    b.Property<Guid>("nhaxbID")
                        .HasColumnType("uuid");

                    b.Property<int>("soluong")
                        .HasColumnType("integer");

                    b.Property<Guid>("tacgiaID")
                        .HasColumnType("uuid");

                    b.Property<string>("tensach")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("nhaxbID");

                    b.HasIndex("tacgiaID");

                    b.ToTable("saches");
                });

            modelBuilder.Entity("webAPI.Data.Sach.theloai", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ghichu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tentheloai")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("theloais");
                });

            modelBuilder.Entity("webAPI.Data.Sach.theloai_sach", b =>
                {
                    b.Property<Guid>("sachID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("theloaiID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("sachID", "theloaiID");

                    b.HasIndex("theloaiID");

                    b.ToTable("theloai_sach");
                });

            modelBuilder.Entity("webAPI.Data.DangNhap.User", b =>
                {
                    b.HasOne("webAPI.Data.DangNhap.UserRole", "Roles")
                        .WithMany("users")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("webAPI.Data.HoaDon.chitiethoadon", b =>
                {
                    b.HasOne("webAPI.Data.HoaDon.hoadon", "hoadon")
                        .WithMany("chitiethoadons")
                        .HasForeignKey("hoadonID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("webAPI.Data.Sach.sach", "sach")
                        .WithMany("chitiethoadons")
                        .HasForeignKey("sachID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("hoadon");

                    b.Navigation("sach");
                });

            modelBuilder.Entity("webAPI.Data.HoaDon.hoadon", b =>
                {
                    b.HasOne("webAPI.Data.DangNhap.User", "Users")
                        .WithMany("hoadons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("webAPI.Data.Sach.sach", b =>
                {
                    b.HasOne("webAPI.Data.Nguon.nhaxb", "nhaxuatban")
                        .WithMany("saches")
                        .HasForeignKey("nhaxbID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("webAPI.Data.Nguon.tacgia", "tacgia")
                        .WithMany("saches")
                        .HasForeignKey("tacgiaID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("nhaxuatban");

                    b.Navigation("tacgia");
                });

            modelBuilder.Entity("webAPI.Data.Sach.theloai_sach", b =>
                {
                    b.HasOne("webAPI.Data.Sach.sach", "sach")
                        .WithMany("theloai_Saches")
                        .HasForeignKey("sachID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("webAPI.Data.Sach.theloai", "theloai")
                        .WithMany("theloai_Saches")
                        .HasForeignKey("theloaiID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("sach");

                    b.Navigation("theloai");
                });

            modelBuilder.Entity("webAPI.Data.DangNhap.User", b =>
                {
                    b.Navigation("hoadons");
                });

            modelBuilder.Entity("webAPI.Data.DangNhap.UserRole", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("webAPI.Data.HoaDon.hoadon", b =>
                {
                    b.Navigation("chitiethoadons");
                });

            modelBuilder.Entity("webAPI.Data.Nguon.nhaxb", b =>
                {
                    b.Navigation("saches");
                });

            modelBuilder.Entity("webAPI.Data.Nguon.tacgia", b =>
                {
                    b.Navigation("saches");
                });

            modelBuilder.Entity("webAPI.Data.Sach.sach", b =>
                {
                    b.Navigation("chitiethoadons");

                    b.Navigation("theloai_Saches");
                });

            modelBuilder.Entity("webAPI.Data.Sach.theloai", b =>
                {
                    b.Navigation("theloai_Saches");
                });
#pragma warning restore 612, 618
        }
    }
}
