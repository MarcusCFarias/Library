using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class correctFKRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLoan_Book_BookId1",
                table: "BookLoan");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLoan_User_UserId1",
                table: "BookLoan");

            migrationBuilder.DropIndex(
                name: "IX_BookLoan_BookId1",
                table: "BookLoan");

            migrationBuilder.DropIndex(
                name: "IX_BookLoan_UserId1",
                table: "BookLoan");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "BookLoan");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BookLoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "BookLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "BookLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_BookId1",
                table: "BookLoan",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_UserId1",
                table: "BookLoan",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoan_Book_BookId1",
                table: "BookLoan",
                column: "BookId1",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoan_User_UserId1",
                table: "BookLoan",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
