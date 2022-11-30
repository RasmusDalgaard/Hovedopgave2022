using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSuiteVisualConfigurator.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntitySequence");

            migrationBuilder.CreateTable(
                name: "emsuiteConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emsuiteConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
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
                name: "accessPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EntitySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accessPoints_zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_accessPoints_ZoneId",
                table: "accessPoints",
                column: "ZoneId");

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
                name: "accessPoints");

            migrationBuilder.DropTable(
                name: "sensors");

            migrationBuilder.DropTable(
                name: "zones");

            migrationBuilder.DropTable(
                name: "sites");

            migrationBuilder.DropTable(
                name: "emsuiteConfigurations");

            migrationBuilder.DropSequence(
                name: "EntitySequence");
        }
    }
}
