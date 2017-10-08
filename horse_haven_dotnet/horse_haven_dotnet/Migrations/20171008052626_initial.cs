using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace horse_haven_dotnet.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardingTypes",
                columns: table => new
                {
                    BoardingTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    DailyRate = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingTypes", x => x.BoardingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "HorseStatuses",
                columns: table => new
                {
                    HorseStatusId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseStatuses", x => x.HorseStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    PersonTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.PersonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "PersonTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    HorseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AdopterId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    CountyOfOrigin = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    EligibleForOwnership = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    HorseHavenId = table.Column<string>(nullable: true),
                    HorseStatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.HorseId);
                    table.ForeignKey(
                        name: "FK_Horses_People_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horses_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horses_HorseStatuses_HorseStatusId",
                        column: x => x.HorseStatusId,
                        principalTable: "HorseStatuses",
                        principalColumn: "HorseStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boardings",
                columns: table => new
                {
                    BoardingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    BoardingTypeId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    HorseId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardings", x => x.BoardingId);
                    table.ForeignKey(
                        name: "FK_Boardings_BoardingTypes_BoardingTypeId",
                        column: x => x.BoardingTypeId,
                        principalTable: "BoardingTypes",
                        principalColumn: "BoardingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boardings_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "HorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseWeights",
                columns: table => new
                {
                    HorseWeightId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    DateWeighed = table.Column<DateTime>(nullable: false),
                    HorseId = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseWeights", x => x.HorseWeightId);
                    table.ForeignKey(
                        name: "FK_HorseWeights_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "HorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CostOfService = table.Column<decimal>(nullable: false),
                    DateOfService = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HorseId = table.Column<int>(nullable: false),
                    ServiceProviderId = table.Column<int>(nullable: false),
                    ServiceProviderId0 = table.Column<int>(name: "ServiceProviderId.", nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "HorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_People_ServiceProviderId.",
                        column: x => x.ServiceProviderId0,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boardings_BoardingTypeId",
                table: "Boardings",
                column: "BoardingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Boardings_HorseId",
                table: "Boardings",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_AdopterId",
                table: "Horses",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_CaseId",
                table: "Horses",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_HorseStatusId",
                table: "Horses",
                column: "HorseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseWeights_HorseId",
                table: "HorseWeights",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonTypeId",
                table: "People",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_HorseId",
                table: "Services",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceProviderId.",
                table: "Services",
                column: "ServiceProviderId.");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boardings");

            migrationBuilder.DropTable(
                name: "HorseWeights");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "BoardingTypes");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "HorseStatuses");

            migrationBuilder.DropTable(
                name: "PersonTypes");
        }
    }
}
