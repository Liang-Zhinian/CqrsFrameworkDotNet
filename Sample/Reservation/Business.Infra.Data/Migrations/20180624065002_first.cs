﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Business.Infra.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "book2");

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "book2",
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
                name: "ResourceStatus",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceType",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CancelOffset = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ScheduleType = table.Column<int>(nullable: false),
                    ScheduleTypeValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Version = table.Column<int>(nullable: false),
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
                schema: "book2",
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
                name: "Service",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "book2",
                        principalTable: "ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
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
                    Image = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Version = table.Column<int>(nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    Geolocation_Latitude = table.Column<double>(nullable: true),
                    Geolocation_Longitude = table.Column<double>(nullable: true),
                    PostalAddress_City = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress2 = table.Column<string>(nullable: true),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
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
                    CanLoginAllLocations = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Version = table.Column<int>(nullable: false),
                    TenantId_Id = table.Column<string>(type: "varchar(36)", nullable: false)
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
                name: "ScheduleLayout",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId_Id = table.Column<string>(type: "char(36)", nullable: false),
                    TimeZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLayout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLayout_TimeZone_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalSchema: "book2",
                        principalTable: "TimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
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
                    StaffId = table.Column<Guid>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DaysVisible = table.Column<int>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    IsCalendarSubscriptionAllowed = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    LayoutId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    TenantId_Id = table.Column<string>(type: "char(36)", nullable: false),
                    WeekdayStart = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ScheduleLayout_LayoutId",
                        column: x => x.LayoutId,
                        principalSchema: "book2",
                        principalTable: "ScheduleLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLayoutTimeSlot",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AvailabilityCode = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    EndLabel = table.Column<string>(type: "varchar(255)", nullable: true),
                    EndTime = table.Column<string>(type: "varchar(10)", nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Label = table.Column<string>(type: "varchar(255)", nullable: true),
                    LayoutId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartTime = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLayoutTimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLayoutTimeSlot_ScheduleLayout_LayoutId",
                        column: x => x.LayoutId,
                        principalSchema: "book2",
                        principalTable: "ScheduleLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    IsLocatedAtAllLocations = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ResourceTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TenantId_Id = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalSchema: "book2",
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "book2",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "book2",
                        principalTable: "ResourceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLocation",
                schema: "book2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ResourceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLocation", x => new { x.Id, x.ResourceId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_ResourceLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceLocation_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "book2",
                        principalTable: "Resource",
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
                name: "IX_Resource_ResourceTypeId",
                schema: "book2",
                table: "Resource",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ScheduleId",
                schema: "book2",
                table: "Resource",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_StatusId",
                schema: "book2",
                table: "Resource",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_LocationId",
                schema: "book2",
                table: "ResourceLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_ResourceId",
                schema: "book2",
                table: "ResourceLocation",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_LayoutId",
                schema: "book2",
                table: "Schedule",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayout_TimeZoneId",
                schema: "book2",
                table: "ScheduleLayout",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayoutTimeSlot_LayoutId",
                schema: "book2",
                table: "ScheduleLayoutTimeSlot",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CategoryId",
                schema: "book2",
                table: "Service",
                column: "CategoryId");

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
                name: "Region",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "ResourceLocation",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "ScheduleLayoutTimeSlot",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "StaffLoginLocation",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "ServiceCategory",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Staff",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "ResourceType",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "ResourceStatus",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "Site",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "ScheduleLayout",
                schema: "book2");

            migrationBuilder.DropTable(
                name: "TimeZone",
                schema: "book2");
        }
    }
}
