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
                name: "Branding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    LogoURL = table.Column<string>(type: "varchar(255)", nullable: true),
                    PageColor1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    PageColor4 = table.Column<string>(type: "varchar(10)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    BusinessDescription = table.Column<string>(type: "varchar(2000)", nullable: false),
                    BusinessID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: false),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

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
                name: "ResourceStatus",
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
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CancelOffset = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ScheduleType = table.Column<int>(nullable: false),
                    ScheduleTypeValue = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(2000)", nullable: true),
                    CanLoginAllLocations = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    StateProvince = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    StreetAddress2 = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    PrimaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    SecondaryTelephone = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantContact", x => x.Id);
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
                name: "LocationImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategory",
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
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                        name: "FK_StaffLoginLocation_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLayout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TimeZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLayout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLayout_TimeZone_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
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
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    WeekdayStart = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ScheduleLayout_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "ScheduleLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLayoutTimeSlot",
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
                    StartTime = table.Column<string>(type: "varchar(10)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLayoutTimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLayoutTimeSlot_ScheduleLayout_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "ScheduleLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    IsLocatedAtAllLocations = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ResourceTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ResourceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ResourceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLocation", x => new { x.Id, x.ResourceId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_ResourceLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceLocation_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceTypeId",
                table: "Resource",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ScheduleId",
                table: "Resource",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_StatusId",
                table: "Resource",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_LocationId",
                table: "ResourceLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_ResourceId",
                table: "ResourceLocation",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_LayoutId",
                table: "Schedule",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayout_TimeZoneId",
                table: "ScheduleLayout",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayoutTimeSlot_LayoutId",
                table: "ScheduleLayoutTimeSlot",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CategoryId",
                table: "Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_LocationId",
                table: "StaffLoginLocation",
                column: "LocationId");

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
                name: "LocationImage");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "ResourceLocation");

            migrationBuilder.DropTable(
                name: "ScheduleLayoutTimeSlot");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "StaffLoginLocation");

            migrationBuilder.DropTable(
                name: "TenantAddress");

            migrationBuilder.DropTable(
                name: "TenantContact");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ServiceCategory");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ResourceStatus");

            migrationBuilder.DropTable(
                name: "ScheduleLayout");

            migrationBuilder.DropTable(
                name: "TimeZone");
        }
    }
}
