using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Costvel.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locais",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mapa_id = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    cidade = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    estado = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    pais = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    coordenadas = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_custos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    ordem = table.Column<int>(type: "integer", nullable: false),
                    criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "custos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    ip_solicitante = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    cidade_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_id = table.Column<int>(type: "integer", nullable: false),
                    criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost", x => x.id);
                    table.ForeignKey(
                        name: "FK_CostType_Cost",
                        column: x => x.tipo_id,
                        principalTable: "tipo_custos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locais_custos",
                        column: x => x.cidade_id,
                        principalTable: "locais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_custos_cidade_id",
                table: "custos",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "IX_custos_tipo_id",
                table: "custos",
                column: "tipo_id");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_custos_ordem",
                table: "tipo_custos",
                column: "ordem",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "custos");

            migrationBuilder.DropTable(
                name: "tipo_custos");

            migrationBuilder.DropTable(
                name: "locais");
        }
    }
}
