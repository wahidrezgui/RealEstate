using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class addnotaire1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotosNotaire_Notaires_NotaireId",
                table: "PhotosNotaire");

            migrationBuilder.DropIndex(
                name: "IX_PhotosNotaire_NotaireId",
                table: "PhotosNotaire");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Notaires",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notaires_PhotoId",
                table: "Notaires",
                column: "PhotoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notaires_PhotosNotaire_PhotoId",
                table: "Notaires",
                column: "PhotoId",
                principalTable: "PhotosNotaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notaires_PhotosNotaire_PhotoId",
                table: "Notaires");

            migrationBuilder.DropIndex(
                name: "IX_Notaires_PhotoId",
                table: "Notaires");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Notaires");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosNotaire_NotaireId",
                table: "PhotosNotaire",
                column: "NotaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosNotaire_Notaires_NotaireId",
                table: "PhotosNotaire",
                column: "NotaireId",
                principalTable: "Notaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
