using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Business.Infra.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
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
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    BrandingId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeZone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(type: "varchar(255)", nullable: false),
                    StandardName = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Logo = table.Column<string>(type: "varchar(4000)", nullable: true),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branding_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Image = table.Column<string>(type: "varchar(4000)", nullable: false),
                    LocationAddressId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId1 = table.Column<Guid>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_Site_SiteId1",
                        column: x => x.SiteId1,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    CanLoginAllLocations = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId1 = table.Column<Guid>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Site_SiteId1",
                        column: x => x.SiteId1,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TimeZoneId = table.Column<int>(nullable: false),
                    Geolocation_Latitude = table.Column<double>(nullable: false),
                    Geolocation_Longitude = table.Column<double>(nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationAddress_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationAddress_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationAddress_TimeZone_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Image = table.Column<string>(type: "varchar(255)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationImage_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginLocation", x => new { x.Id, x.StaffId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branding_SiteId",
                table: "Branding",
                column: "SiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_SiteId",
                table: "Location",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_SiteId1",
                table: "Location",
                column: "SiteId1");

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_LocationId",
                table: "LocationAddress",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_SiteId",
                table: "LocationAddress",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_TimeZoneId",
                table: "LocationAddress",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_SiteId",
                table: "LocationImage",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SiteId",
                table: "Staff",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SiteId1",
                table: "Staff",
                column: "SiteId1");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_LocationId",
                table: "StaffLoginLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_SiteId",
                table: "StaffLoginLocation",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_StaffId",
                table: "StaffLoginLocation",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branding");

            migrationBuilder.DropTable(
                name: "LocationAddress");

            migrationBuilder.DropTable(
                name: "LocationImage");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "StaffLoginLocation");

            migrationBuilder.DropTable(
                name: "TimeZone");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
