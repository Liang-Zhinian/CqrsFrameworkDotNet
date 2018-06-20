using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Registration.Infra.Data.Migrations
{
    public partial class addServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCategoryView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CancelOffset = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    IsInternal = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    ScheduleTypeValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategoryView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCategoryView_ServiceCategoryView_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ServiceCategoryView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomePageImageView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Data = table.Column<string>(type: "mediumtext", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    ParentCategoryName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageImageView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePageImageView_ServiceCategoryView_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategoryView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomePageImageView_ServiceCategoryView_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ServiceCategoryView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceView",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceView_ServiceCategoryView_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategoryView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomePageImageView_CategoryId",
                table: "HomePageImageView",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HomePageImageView_ParentCategoryId",
                table: "HomePageImageView",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategoryView_ParentCategoryId",
                table: "ServiceCategoryView",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceView_CategoryId",
                table: "ServiceView",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePageImageView");

            migrationBuilder.DropTable(
                name: "ServiceView");

            migrationBuilder.DropTable(
                name: "ServiceCategoryView");
        }
    }
}
