using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Catalog.Api.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CancelOffset = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ScheduleTypeId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DefaultTimeLength = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Descrtiption = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ServiceCategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SiteId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceItem_ServiceCategory_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_ServiceCategoryId",
                table: "ServiceItem",
                column: "ServiceCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceItem");

            migrationBuilder.DropTable(
                name: "ServiceCategory");
        }
    }
}
