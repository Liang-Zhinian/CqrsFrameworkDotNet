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
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(2000)", nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Branding_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ResourceType_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                    table.ForeignKey(
                        name: "FK_Service_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    CanLoginAllLocations = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false),
                    ForeignZip = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    State = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantAddress_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantContact_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                        name: "FK_ScheduleLayout_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleLayout_TimeZone_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false),
                    ForeignZip = table.Column<string>(type: "varchar(255)", nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    State = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                        name: "FK_LocationAddress_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationContact_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationContact_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_LocationImage_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false),
                    ForeignZip = table.Column<string>(type: "varchar(255)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(255)", nullable: true),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    State = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(255)", nullable: true),
                    StaffId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffContact_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffContact_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginCredential",
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
                    table.PrimaryKey("PK_StaffLoginCredential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLoginCredential_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffLoginCredential_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                    table.ForeignKey(
                        name: "FK_Schedule_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                    table.ForeignKey(
                        name: "FK_ScheduleLayoutTimeSlot_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                    table.ForeignKey(
                        name: "FK_Resource_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
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
                    table.ForeignKey(
                        name: "FK_ResourceLocation_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branding_TenantId",
                table: "Branding",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_TenantId",
                table: "Location",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_LocationId",
                table: "LocationAddress",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_TenantId",
                table: "LocationAddress",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_TenantId",
                table: "LocationContact",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_TenantId",
                table: "LocationImage",
                column: "TenantId");

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
                name: "IX_Resource_TenantId",
                table: "Resource",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_LocationId",
                table: "ResourceLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_ResourceId",
                table: "ResourceLocation",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_TenantId",
                table: "ResourceLocation",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_TenantId",
                table: "ResourceType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_LayoutId",
                table: "Schedule",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TenantId",
                table: "Schedule",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayout_TenantId",
                table: "ScheduleLayout",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayout_TimeZoneId",
                table: "ScheduleLayout",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayoutTimeSlot_LayoutId",
                table: "ScheduleLayoutTimeSlot",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLayoutTimeSlot_TenantId",
                table: "ScheduleLayoutTimeSlot",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CategoryId",
                table: "Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_TenantId",
                table: "Service",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_TenantId",
                table: "Staff",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddress_StaffId",
                table: "StaffAddress",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddress_TenantId",
                table: "StaffAddress",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffContact_StaffId",
                table: "StaffContact",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffContact_TenantId",
                table: "StaffContact",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginCredential_StaffId",
                table: "StaffLoginCredential",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginCredential_TenantId",
                table: "StaffLoginCredential",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_LocationId",
                table: "StaffLoginLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_StaffId",
                table: "StaffLoginLocation",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_TenantId",
                table: "StaffLoginLocation",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantAddress_TenantId",
                table: "TenantAddress",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantContact_TenantId",
                table: "TenantContact",
                column: "TenantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branding");

            migrationBuilder.DropTable(
                name: "LocationAddress");

            migrationBuilder.DropTable(
                name: "LocationContact");

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
                name: "StaffAddress");

            migrationBuilder.DropTable(
                name: "StaffContact");

            migrationBuilder.DropTable(
                name: "StaffLoginCredential");

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
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "TimeZone");
        }
    }
}
