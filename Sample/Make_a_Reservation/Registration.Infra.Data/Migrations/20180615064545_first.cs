using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Registration.Infra.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegionView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(type: "varchar(255)", nullable: false),
                    EquivalentLocaleName = table.Column<string>(type: "varchar(255)", nullable: false),
                    RegionString = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    ForeignZip = table.Column<string>(type: "varchar(255)", nullable: true),
                    LogoURL = table.Column<string>(type: "varchar(255)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    State = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeZoneView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(type: "varchar(255)", nullable: false),
                    StandardName = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZoneView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    ForeignZip = table.Column<string>(type: "varchar(255)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    State = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ForeignZip = table.Column<string>(type: "varchar(255)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    State = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImageView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImageView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImageView_LocationView_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginCredentialView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginCredentialView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLoginCredentialView_StaffView_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginLocationView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginLocationView", x => new { x.Id, x.StaffId, x.LocationId });
                    table.UniqueConstraint("AK_StaffLoginLocationView_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocationView_LocationView_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocationView_StaffView_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationImageView_LocationId",
                table: "LocationImageView",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationView_TenantId",
                table: "LocationView",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginCredentialView_StaffId",
                table: "StaffLoginCredentialView",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocationView_LocationId",
                table: "StaffLoginLocationView",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocationView_StaffId",
                table: "StaffLoginLocationView",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffView_TenantId",
                table: "StaffView",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationImageView");

            migrationBuilder.DropTable(
                name: "RegionView");

            migrationBuilder.DropTable(
                name: "StaffLoginCredentialView");

            migrationBuilder.DropTable(
                name: "StaffLoginLocationView");

            migrationBuilder.DropTable(
                name: "TimeZoneView");

            migrationBuilder.DropTable(
                name: "LocationView");

            migrationBuilder.DropTable(
                name: "StaffView");

            migrationBuilder.DropTable(
                name: "TenantView");
        }
    }
}
