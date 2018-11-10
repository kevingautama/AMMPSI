using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AMMPSI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DepreciationDuration = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsMoveable = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Asset_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationID = table.Column<int>(nullable: false),
                    MovementDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movement_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementLog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    LocationID = table.Column<int>(nullable: false),
                    MovedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovementLog_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementLog_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsMoved = table.Column<bool>(nullable: false),
                    MovementID = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovementItem_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementItem_Movement_MovementID",
                        column: x => x.MovementID,
                        principalTable: "Movement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CategoryID",
                table: "Asset",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_LocationID",
                table: "Movement",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementItem_AssetID",
                table: "MovementItem",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementItem_MovementID",
                table: "MovementItem",
                column: "MovementID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementLog_AssetID",
                table: "MovementLog",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementLog_LocationID",
                table: "MovementLog",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementItem");

            migrationBuilder.DropTable(
                name: "MovementLog");

            migrationBuilder.DropTable(
                name: "Movement");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
