using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nhaxuatbans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    tennhaxb = table.Column<string>(type: "text", nullable: false),
                    sdt = table.Column<string>(type: "text", nullable: false),
                    ghichu = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaxuatbans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tacgias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    tentacgia = table.Column<string>(type: "text", nullable: false),
                    quequan = table.Column<string>(type: "text", nullable: false),
                    ghichu = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tacgias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "theloais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    tentheloai = table.Column<string>(type: "text", nullable: false),
                    ghichu = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theloais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    roleID = table.Column<string>(type: "text", nullable: false),
                    roleName = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userroles", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "saches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    tensach = table.Column<string>(type: "text", nullable: false),
                    tacgiaID = table.Column<Guid>(type: "uuid", nullable: false),
                    nhaxbID = table.Column<Guid>(type: "uuid", nullable: false),
                    giaban = table.Column<int>(type: "integer", nullable: false),
                    soluong = table.Column<int>(type: "integer", nullable: false),
                    ghichu = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saches_nhaxuatbans_nhaxbID",
                        column: x => x.nhaxbID,
                        principalTable: "nhaxuatbans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_saches_tacgias_tacgiaID",
                        column: x => x.tacgiaID,
                        principalTable: "tacgias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Pass = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    roleID = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_userroles_roleID",
                        column: x => x.roleID,
                        principalTable: "userroles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "theloai_sach",
                columns: table => new
                {
                    sachID = table.Column<Guid>(type: "uuid", nullable: false),
                    theloaiID = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theloai_sach", x => new { x.sachID, x.theloaiID });
                    table.ForeignKey(
                        name: "FK_theloai_sach_saches_sachID",
                        column: x => x.sachID,
                        principalTable: "saches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_theloai_sach_theloais_theloaiID",
                        column: x => x.theloaiID,
                        principalTable: "theloais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "hoadons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    thoigianban = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tongtien = table.Column<int>(type: "integer", nullable: false),
                    ghichu = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoadons_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "chitiethoadons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    hoadonID = table.Column<Guid>(type: "uuid", nullable: false),
                    sachID = table.Column<Guid>(type: "uuid", nullable: false),
                    soluong = table.Column<int>(type: "integer", nullable: false),
                    giaban = table.Column<int>(type: "integer", nullable: false),
                    ghichu = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitiethoadons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chitiethoadons_hoadons_hoadonID",
                        column: x => x.hoadonID,
                        principalTable: "hoadons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_chitiethoadons_saches_sachID",
                        column: x => x.sachID,
                        principalTable: "saches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadons_hoadonID",
                table: "chitiethoadons",
                column: "hoadonID");

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadons_sachID",
                table: "chitiethoadons",
                column: "sachID");

            migrationBuilder.CreateIndex(
                name: "IX_hoadons_UserId",
                table: "hoadons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_saches_nhaxbID",
                table: "saches",
                column: "nhaxbID");

            migrationBuilder.CreateIndex(
                name: "IX_saches_tacgiaID",
                table: "saches",
                column: "tacgiaID");

            migrationBuilder.CreateIndex(
                name: "IX_theloai_sach_theloaiID",
                table: "theloai_sach",
                column: "theloaiID");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleID",
                table: "users",
                column: "roleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chitiethoadons");

            migrationBuilder.DropTable(
                name: "theloai_sach");

            migrationBuilder.DropTable(
                name: "hoadons");

            migrationBuilder.DropTable(
                name: "saches");

            migrationBuilder.DropTable(
                name: "theloais");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "nhaxuatbans");

            migrationBuilder.DropTable(
                name: "tacgias");

            migrationBuilder.DropTable(
                name: "userroles");
        }
    }
}
