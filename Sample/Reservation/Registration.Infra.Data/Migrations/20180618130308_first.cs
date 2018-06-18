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
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    LogoURL = table.Column<string>(type: "varchar(255)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: false),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: false),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    TenantId = table.Column<Guid>(nullable: false),
                    PostalAddress_City = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantView", x => x.Id);
                    table.UniqueConstraint("AK_TenantView_TenantId", x => x.TenantId);
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
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: false),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(nullable: false),
                    PostalAddress_City = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Enablement_Enabled = table.Column<bool>(nullable: false),
                    Enablement_EndDate = table.Column<DateTime>(nullable: false),
                    Enablement_StartDate = table.Column<DateTime>(nullable: false),
                    PersonalInfo_Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    PersonalInfo_FirstName = table.Column<string>(type: "varchar(255)", nullable: true),
                    PersonalInfo_LastName = table.Column<string>(type: "varchar(255)", nullable: true),
                    PersonalInfo_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    PersonalInfo_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_City = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_LocationImageView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "TenantId",
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
                    table.ForeignKey(
                        name: "FK_StaffLoginLocationView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationImageView_LocationId",
                table: "LocationImageView",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImageView_TenantId",
                table: "LocationImageView",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationView_TenantId",
                table: "LocationView",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocationView_LocationId",
                table: "StaffLoginLocationView",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocationView_StaffId",
                table: "StaffLoginLocationView",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocationView_TenantId",
                table: "StaffLoginLocationView",
                column: "TenantId");

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
