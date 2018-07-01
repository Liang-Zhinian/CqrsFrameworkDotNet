using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Site.Api.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "book2");

            migrationBuilder.CreateTable(
                name: "Site",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branding",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Logo = table.Column<byte[]>(type: "varchar(4000)", nullable: true),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branding_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    Geolocation_Latitude = table.Column<double>(type: "double", nullable: true),
                    Geolocation_Longitude = table.Column<double>(type: "double", nullable: true),
                    PostalAddress_City = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress2 = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    CanLoginAllLocations = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationImage_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginLocation",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginLocation", x => new { x.Id, x.StaffId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Staff_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "book2",
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branding_SiteId",
                schema: "book2",
                table: "Branding",
                column: "SiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_SiteId",
                schema: "book2",
                table: "Location",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                schema: "book2",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_SiteId",
                schema: "book2",
                table: "LocationImage",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SiteId",
                schema: "book2",
                table: "Staff",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_LocationId",
                schema: "book2",
                table: "StaffLoginLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_SiteId",
                schema: "book2",
                table: "StaffLoginLocation",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_StaffId",
                schema: "book2",
                table: "StaffLoginLocation",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branding",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "LocationImage",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "StaffLoginLocation",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Staff",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Site",
                schema: "book2");
        }
    }
}
