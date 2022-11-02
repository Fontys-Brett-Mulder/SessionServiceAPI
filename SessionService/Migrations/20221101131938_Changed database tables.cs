using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SessionService.Migrations
{
    public partial class Changeddatabasetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerModel_Session_SessionModelId",
                table: "PlayerModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_GameModel_GameId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerModel",
                table: "PlayerModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameModel",
                table: "GameModel");

            migrationBuilder.RenameTable(
                name: "PlayerModel",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "GameModel",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerModel_SessionModelId",
                table: "Player",
                newName: "IX_Player_SessionModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Session_SessionModelId",
                table: "Player",
                column: "SessionModelId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Game_GameId",
                table: "Session",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Session_SessionModelId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Game_GameId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "PlayerModel");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "GameModel");

            migrationBuilder.RenameIndex(
                name: "IX_Player_SessionModelId",
                table: "PlayerModel",
                newName: "IX_PlayerModel_SessionModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerModel",
                table: "PlayerModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameModel",
                table: "GameModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerModel_Session_SessionModelId",
                table: "PlayerModel",
                column: "SessionModelId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_GameModel_GameId",
                table: "Session",
                column: "GameId",
                principalTable: "GameModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
