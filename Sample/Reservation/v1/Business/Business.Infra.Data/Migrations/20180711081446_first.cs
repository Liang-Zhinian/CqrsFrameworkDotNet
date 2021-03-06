﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Business.Infrastructure.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "book2business");

            migrationBuilder.CreateTable(
                name: "IndustryStandardCategory",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryStandardCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustryStandardCategory_IndustryStandardCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "book2business",
                        principalTable: "IndustryStandardCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "book2business",
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
                schema: "book2business",
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
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleType",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_EmailAddress = table.Column<string>(type: "varchar(255)", nullable: true),
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
                schema: "book2business",
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
                schema: "book2business",
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
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContactInformation_ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_EmailAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    ContactInformation_SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    Geolocation_Latitude = table.Column<double>(nullable: true),
                    Geolocation_Longitude = table.Column<double>(nullable: true),
                    PostalAddress_City = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalAddress_StreetAddress2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CancelOffset = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ScheduleTypeId = table.Column<int>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCategory_ScheduleType_ScheduleTypeId",
                        column: x => x.ScheduleTypeId,
                        principalSchema: "book2business",
                        principalTable: "ScheduleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCategory_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    CanLoginAllLocations = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLayout",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLayout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLayout_TimeZone_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalSchema: "book2business",
                        principalTable: "TimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2business",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationImage_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DefaultTimeLength = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    IndustryStandardCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ServiceCategoryId = table.Column<Guid>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceItem_IndustryStandardCategory_IndustryStandardCategoryId",
                        column: x => x.IndustryStandardCategoryId,
                        principalSchema: "book2business",
                        principalTable: "IndustryStandardCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceItem_ServiceCategory_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalSchema: "book2business",
                        principalTable: "ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceItem_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginLocation",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StaffId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginLocation", x => new { x.Id, x.StaffId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "book2business",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Staff_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "book2business",
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DaysVisible = table.Column<int>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    IsCalendarSubscriptionAllowed = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    LayoutId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    WeekdayStart = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ScheduleLayout_LayoutId",
                        column: x => x.LayoutId,
                        principalSchema: "book2business",
                        principalTable: "ScheduleLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLayoutTimeSlot",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AvailabilityCode = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    EndLabel = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    LayoutId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLayoutTimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLayoutTimeSlot_ScheduleLayout_LayoutId",
                        column: x => x.LayoutId,
                        principalSchema: "book2business",
                        principalTable: "ScheduleLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    BookableEndDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    ServiceItemId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availability_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalSchema: "book2business",
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Availability_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Availability_Staff_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "book2business",
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unavailability",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    ServiceItemId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(nullable: false),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unavailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unavailability_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalSchema: "book2business",
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unavailability_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "book2business",
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unavailability_Staff_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "book2business",
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    IsLocatedAtAllLocations = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ResourceTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalSchema: "book2business",
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "book2business",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "book2business",
                        principalTable: "ResourceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                schema: "book2business",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AvailabilityId = table.Column<Guid>(nullable: true),
                    CancelOffset = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ScheduleTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Program_Availability_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalSchema: "book2business",
                        principalTable: "Availability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Program_ScheduleType_ScheduleTypeId",
                        column: x => x.ScheduleTypeId,
                        principalSchema: "book2business",
                        principalTable: "ScheduleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLocation",
                schema: "book2business",
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
                        principalSchema: "book2business",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceLocation_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "book2business",
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_ServiceItemId",
                schema: "book2business",
                table: "Availability",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_SiteId",
                schema: "book2business",
                table: "Availability",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_StaffId",
                schema: "book2business",
                table: "Availability",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Branding_SiteId",
                schema: "book2business",
                table: "Branding",
                column: "SiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndustryStandardCategory_ParentCategoryId",
                schema: "book2business",
                table: "IndustryStandardCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_SiteId",
                schema: "book2business",
                table: "Location",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                schema: "book2business",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_SiteId",
                schema: "book2business",
                table: "LocationImage",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_AvailabilityId",
                schema: "book2business",
                table: "Program",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_ScheduleTypeId",
                schema: "book2business",
                table: "Program",
                column: "ScheduleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceTypeId",
                schema: "book2business",
                table: "Resource",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ScheduleId",
                schema: "book2business",
                table: "Resource",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_StatusId",
                schema: "book2business",
                table: "Resource",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_LocationId",
                schema: "book2business",
                table: "ResourceLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_ResourceId",
                schema: "book2business",
                table: "ResourceLocation",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_LayoutId",
                schema: "book2business",
                table: "Schedule",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayout_TimeZoneId",
                schema: "book2business",
                table: "ScheduleLayout",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayoutTimeSlot_LayoutId",
                schema: "book2business",
                table: "ScheduleLayoutTimeSlot",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategory_ScheduleTypeId",
                schema: "book2business",
                table: "ServiceCategory",
                column: "ScheduleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategory_SiteId",
                schema: "book2business",
                table: "ServiceCategory",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_IndustryStandardCategoryId",
                schema: "book2business",
                table: "ServiceItem",
                column: "IndustryStandardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_ServiceCategoryId",
                schema: "book2business",
                table: "ServiceItem",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_SiteId",
                schema: "book2business",
                table: "ServiceItem",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SiteId",
                schema: "book2business",
                table: "Staff",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_LocationId",
                schema: "book2business",
                table: "StaffLoginLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_SiteId",
                schema: "book2business",
                table: "StaffLoginLocation",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_StaffId",
                schema: "book2business",
                table: "StaffLoginLocation",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Unavailability_ServiceItemId",
                schema: "book2business",
                table: "Unavailability",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Unavailability_SiteId",
                schema: "book2business",
                table: "Unavailability",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Unavailability_StaffId",
                schema: "book2business",
                table: "Unavailability",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branding",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "LocationImage",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Program",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ResourceLocation",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ScheduleLayoutTimeSlot",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "StaffLoginLocation",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Unavailability",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Availability",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ServiceItem",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Staff",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ResourceType",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ResourceStatus",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "IndustryStandardCategory",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ServiceCategory",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ScheduleLayout",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "ScheduleType",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "Site",
                schema: "book2business");

            migrationBuilder.DropTable(
                name: "TimeZone",
                schema: "book2business");
        }
    }
}
