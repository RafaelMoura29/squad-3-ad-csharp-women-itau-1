﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralErros.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENVIRONMENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENVIRONMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LEVEL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEVEL = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEVEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 255, nullable: false),
                    TOKEN = table.Column<string>(nullable: false),
                    EXPIRATION = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ERROR_OCURRENCE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(nullable: false),
                    REGISTRATION_DATE = table.Column<DateTime>(nullable: false),
                    ORIGIN = table.Column<string>(nullable: false),
                    FILED = table.Column<bool>(nullable: false),
                    DETAILS = table.Column<string>(nullable: false),
                    ID_EVENTS = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    EnvironmentId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    TokenUser = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    LevelName = table.Column<string>(nullable: true),
                    EnvironmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR_OCURRENCE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ERROR_OCURRENCE_ENVIRONMENT_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "ENVIRONMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_OCURRENCE_LEVEL_LevelId",
                        column: x => x.LevelId,
                        principalTable: "LEVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_OCURRENCE_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCURRENCE_EnvironmentId",
                table: "ERROR_OCURRENCE",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCURRENCE_LevelId",
                table: "ERROR_OCURRENCE",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCURRENCE_UserId",
                table: "ERROR_OCURRENCE",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERROR_OCURRENCE");

            migrationBuilder.DropTable(
                name: "ENVIRONMENT");

            migrationBuilder.DropTable(
                name: "LEVEL");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}