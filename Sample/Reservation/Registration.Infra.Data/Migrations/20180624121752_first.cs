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
            migrationBuilder.EnsureSchema(
                name: "book2");

            migrationBuilder.CreateTable(
                name: "V_Region",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(type: "varchar(255)", nullable: false),
                    EquivalentLocaleName = table.Column<string>(type: "varchar(255)", nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    RegionString = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_ServiceCategory",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    CancelOffset = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    IsInternal = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    ScheduleTypeValue = table.Column<int>(nullable: false),
                    SiteId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    TenantId = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_ServiceCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_ServiceCategory_V_ServiceCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "book2",
                        principalTable: "V_ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_Tenant",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Logo = table.Column<byte[]>(type: "varchar(255)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: false),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_TimeZone",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(type: "varchar(255)", nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    StandardName = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_TimeZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_HomePageImage",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Data = table.Column<string>(type: "mediumtext", nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    ParentCategoryName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_HomePageImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_HomePageImage_V_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "book2",
                        principalTable: "V_ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_HomePageImage_V_ServiceCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "book2",
                        principalTable: "V_ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_Site",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: false),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: true),
                    TenantId = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_Site_V_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "book2",
                        principalTable: "V_Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_Location",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    SiteId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_Location_V_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "V_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_Location_V_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "book2",
                        principalTable: "V_Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_Service",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    SiteId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    TenantId = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_Service_V_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "book2",
                        principalTable: "V_ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_Service_V_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "V_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_Service_V_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "book2",
                        principalTable: "V_Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_Staff",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    CanLoginAllLocations = table.Column<bool>(nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Image = table.Column<byte[]>(type: "varchar(4000)", nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    SiteId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_Staff_V_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "V_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_Staff_V_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "book2",
                        principalTable: "V_Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_LocationImage",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    Image = table.Column<byte[]>(type: "varchar(255)", nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    SiteId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    TenantId = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_LocationImage_V_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2",
                        principalTable: "V_Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_LocationImage_V_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "V_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_LocationImage_V_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "book2",
                        principalTable: "V_Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "V_StaffLoginLocation",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    StaffId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    LocationId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_StaffLoginLocation", x => new { x.Id, x.StaffId, x.LocationId });
                    table.UniqueConstraint("AK_V_StaffLoginLocation_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V_StaffLoginLocation_V_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2",
                        principalTable: "V_Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_StaffLoginLocation_V_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2",
                        principalTable: "V_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_StaffLoginLocation_V_Staff_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "book2",
                        principalTable: "V_Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_V_StaffLoginLocation_V_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "book2",
                        principalTable: "V_Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_V_HomePageImage_CategoryId",
                schema: "book2",
                table: "V_HomePageImage",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_V_HomePageImage_ParentCategoryId",
                schema: "book2",
                table: "V_HomePageImage",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Location_SiteId",
                schema: "book2",
                table: "V_Location",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Location_TenantId",
                schema: "book2",
                table: "V_Location",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_V_LocationImage_LocationId",
                schema: "book2",
                table: "V_LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_V_LocationImage_SiteId",
                schema: "book2",
                table: "V_LocationImage",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_V_LocationImage_TenantId",
                schema: "book2",
                table: "V_LocationImage",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Service_CategoryId",
                schema: "book2",
                table: "V_Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Service_SiteId",
                schema: "book2",
                table: "V_Service",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Service_TenantId",
                schema: "book2",
                table: "V_Service",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_V_ServiceCategory_ParentCategoryId",
                schema: "book2",
                table: "V_ServiceCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Site_TenantId",
                schema: "book2",
                table: "V_Site",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Staff_SiteId",
                schema: "book2",
                table: "V_Staff",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_V_Staff_TenantId",
                schema: "book2",
                table: "V_Staff",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_V_StaffLoginLocation_LocationId",
                schema: "book2",
                table: "V_StaffLoginLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_V_StaffLoginLocation_SiteId",
                schema: "book2",
                table: "V_StaffLoginLocation",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_V_StaffLoginLocation_StaffId",
                schema: "book2",
                table: "V_StaffLoginLocation",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_V_StaffLoginLocation_TenantId",
                schema: "book2",
                table: "V_StaffLoginLocation",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "V_HomePageImage",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_LocationImage",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_Region",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_Service",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_StaffLoginLocation",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_TimeZone",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_ServiceCategory",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_Location",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_Staff",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_Site",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "V_Tenant",
                schema: "book2");
        }
    }
}
