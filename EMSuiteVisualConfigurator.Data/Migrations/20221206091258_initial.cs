using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSuiteVisualConfigurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntitySequence");

            migrationBuilder.CreateTable(
                name: "accessPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emsuiteConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    ConfigurationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emsuiteConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    Battery = table.Column<int>(type: "int", nullable: false),
                    SignalStrength = table.Column<int>(type: "int", nullable: false),
                    AccessPointId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loggers_accessPoints_AccessPointId",
                        column: x => x.AccessPointId,
                        principalTable: "accessPoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZoneId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMSuiteConfigurationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sites_emsuiteConfigurations_EMSuiteConfigurationId",
                        column: x => x.EMSuiteConfigurationId,
                        principalTable: "emsuiteConfigurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    SensorSerialNumber = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoggerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ports_loggers_LoggerId",
                        column: x => x.LoggerId,
                        principalTable: "loggers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_zones_sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "sites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "channels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    PortId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_channels_ports_PortId",
                        column: x => x.PortId,
                        principalTable: "ports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_channels_zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_channels_PortId",
                table: "channels",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_channels_ZoneId",
                table: "channels",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_loggers_AccessPointId",
                table: "loggers",
                column: "AccessPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ports_LoggerId",
                table: "ports",
                column: "LoggerId");

            migrationBuilder.CreateIndex(
                name: "IX_sites_EMSuiteConfigurationId",
                table: "sites",
                column: "EMSuiteConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_zones_SiteId",
                table: "zones",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "channels");

            migrationBuilder.DropTable(
                name: "ports");

            migrationBuilder.DropTable(
                name: "zones");

            migrationBuilder.DropTable(
                name: "loggers");

            migrationBuilder.DropTable(
                name: "sites");

            migrationBuilder.DropTable(
                name: "accessPoints");

            migrationBuilder.DropTable(
                name: "emsuiteConfigurations");

            migrationBuilder.DropSequence(
                name: "EntitySequence");
        }
    }
}
