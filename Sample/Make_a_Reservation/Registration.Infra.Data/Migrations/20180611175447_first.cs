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
                        .Annotation("MySQL:AutoIncrement", true),
                    Abbreviation = table.Column<string>(nullable: true),
                    EquivalentLocaleName = table.Column<string>(nullable: true),
                    RegionString = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
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
                        .Annotation("MySQL:AutoIncrement", true),
                    DisplayName = table.Column<string>(nullable: false),
                    StandardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZoneView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandingView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    LogoURL = table.Column<string>(nullable: true),
                    PageColor1 = table.Column<string>(nullable: true),
                    PageColor2 = table.Column<string>(nullable: true),
                    PageColor3 = table.Column<string>(nullable: true),
                    PageColor4 = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandingView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandingView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantAddressView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ForeignZip = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAddressView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantAddressView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantContactView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantContactView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantContactView_TenantView_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationAddressView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
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
                    table.PrimaryKey("PK_LocationAddressView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationAddressView_LocationView_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationContactView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationContactView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationContactView_LocationView_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationImageView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImageView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImageView_LocationView_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddressView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
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
                    table.PrimaryKey("PK_StaffAddressView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAddressView_StaffView_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffContactView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffContactView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffContactView_StaffView_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginCredentialView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    Password = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLoginCredentialView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLoginCredentialView_StaffView_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffLoginLocationView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(32)", nullable: false),
                    StaffId = table.Column<string>(nullable: false),
                    LocationId = table.Column<string>(nullable: false)
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
                name: "IX_BrandingView_TenantId",
                table: "BrandingView",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddressView_LocationId",
                table: "LocationAddressView",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContactView_LocationId",
                table: "LocationContactView",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationImageView_LocationId",
                table: "LocationImageView",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationView_TenantId",
                table: "LocationView",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddressView_StaffId",
                table: "StaffAddressView",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffContactView_StaffId",
                table: "StaffContactView",
                column: "StaffId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TenantAddressView_TenantId",
                table: "TenantAddressView",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantContactView_TenantId",
                table: "TenantContactView",
                column: "TenantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandingView");

            migrationBuilder.DropTable(
                name: "LocationAddressView");

            migrationBuilder.DropTable(
                name: "LocationContactView");

            migrationBuilder.DropTable(
                name: "LocationImageView");

            migrationBuilder.DropTable(
                name: "RegionView");

            migrationBuilder.DropTable(
                name: "StaffAddressView");

            migrationBuilder.DropTable(
                name: "StaffContactView");

            migrationBuilder.DropTable(
                name: "StaffLoginCredentialView");

            migrationBuilder.DropTable(
                name: "StaffLoginLocationView");

            migrationBuilder.DropTable(
                name: "TenantAddressView");

            migrationBuilder.DropTable(
                name: "TenantContactView");

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
