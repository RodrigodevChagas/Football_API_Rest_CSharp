using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFutebol.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbitragens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeJuiz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeBandeira1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeBandeira2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitragens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisTime1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisTime2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisEvento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artilharia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Confrontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campeonato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Times = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estadio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicoPresente = table.Column<int>(type: "int", nullable: false),
                    ChutesAGol_Time1 = table.Column<int>(type: "int", nullable: false),
                    ChutesAGol_Time2 = table.Column<int>(type: "int", nullable: false),
                    ResultadoId = table.Column<int>(type: "int", nullable: false),
                    ArbitragemId = table.Column<int>(type: "int", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confrontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confrontos_Arbitragens_ArbitragemId",
                        column: x => x.ArbitragemId,
                        principalTable: "Arbitragens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confrontos_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confrontos_Resultados_ResultadoId",
                        column: x => x.ResultadoId,
                        principalTable: "Resultados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confrontos_ArbitragemId",
                table: "Confrontos",
                column: "ArbitragemId");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontos_LocalizacaoId",
                table: "Confrontos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontos_ResultadoId",
                table: "Confrontos",
                column: "ResultadoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confrontos");

            migrationBuilder.DropTable(
                name: "Arbitragens");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Resultados");
        }
    }
}
