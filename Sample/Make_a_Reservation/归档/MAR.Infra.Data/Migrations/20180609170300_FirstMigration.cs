using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MAR.Infra.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Abbreviation = table.Column<string>(nullable: true),
                    EquivalentLocaleName = table.Column<string>(nullable: true),
                    RegionString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DisplayName = table.Column<string>(nullable: true),
                    StandardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branding",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    PageColor1 = table.Column<string>(nullable: true),
                    PageColor2 = table.Column<string>(nullable: true),
                    PageColor3 = table.Column<string>(nullable: true),
                    PageColor4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branding_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAddress",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ForeignZip = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessAddress_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessContact",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessContact_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    BusinessId = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationAddress",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ForeignZip = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    LocationId = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationAddress_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationContact",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationContact_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddress",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ForeignZip = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffContact",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffContact_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginCredential",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginCredential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLoginCredential_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginLocation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LocationId = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffLoginLocation_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branding_BusinessId",
                table: "Branding",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAddress_BusinessId",
                table: "BusinessAddress",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContact_BusinessId",
                table: "BusinessContact",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_BusinessId",
                table: "Location",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_LocationId",
                table: "LocationAddress",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_BusinessId",
                table: "Staff",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddress_StaffId",
                table: "StaffAddress",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffContact_StaffId",
                table: "StaffContact",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginCredential_StaffId",
                table: "StaffLoginCredential",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_LocationId",
                table: "StaffLoginLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLoginLocation_StaffId",
                table: "StaffLoginLocation",
                column: "StaffId");


            //Seeders.TimeZoneSeeder seeder = new Seeders.TimeZoneSeeder();
            //seeder.SeedIt();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branding");

            migrationBuilder.DropTable(
                name: "BusinessAddress");

            migrationBuilder.DropTable(
                name: "BusinessContact");

            migrationBuilder.DropTable(
                name: "LocationAddress");

            migrationBuilder.DropTable(
                name: "LocationContact");

            migrationBuilder.DropTable(
                name: "LocationImage");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "StaffAddress");

            migrationBuilder.DropTable(
                name: "StaffContact");

            migrationBuilder.DropTable(
                name: "StaffLoginCredential");

            migrationBuilder.DropTable(
                name: "StaffLoginLocation");

            migrationBuilder.DropTable(
                name: "TimeZones");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
