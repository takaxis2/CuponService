using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CouponService.Migrations
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCupon_Cupons_Cuponid",
                table: "userCupon");

            migrationBuilder.DropForeignKey(
                name: "FK_userCupon_Users_Userid",
                table: "userCupon");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "userCupon",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Cuponid",
                table: "userCupon",
                newName: "cuponid");

            migrationBuilder.RenameIndex(
                name: "IX_userCupon_Userid",
                table: "userCupon",
                newName: "IX_userCupon_userid");

            migrationBuilder.RenameIndex(
                name: "IX_userCupon_Cuponid",
                table: "userCupon",
                newName: "IX_userCupon_cuponid");

            migrationBuilder.AlterColumn<long>(
                name: "userid",
                table: "userCupon",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "cuponid",
                table: "userCupon",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userCupon_Cupons_cuponid",
                table: "userCupon",
                column: "cuponid",
                principalTable: "Cupons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCupon_Users_userid",
                table: "userCupon",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCupon_Cupons_cuponid",
                table: "userCupon");

            migrationBuilder.DropForeignKey(
                name: "FK_userCupon_Users_userid",
                table: "userCupon");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "userCupon",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "cuponid",
                table: "userCupon",
                newName: "Cuponid");

            migrationBuilder.RenameIndex(
                name: "IX_userCupon_userid",
                table: "userCupon",
                newName: "IX_userCupon_Userid");

            migrationBuilder.RenameIndex(
                name: "IX_userCupon_cuponid",
                table: "userCupon",
                newName: "IX_userCupon_Cuponid");

            migrationBuilder.AlterColumn<long>(
                name: "Userid",
                table: "userCupon",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Cuponid",
                table: "userCupon",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_userCupon_Cupons_Cuponid",
                table: "userCupon",
                column: "Cuponid",
                principalTable: "Cupons",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_userCupon_Users_Userid",
                table: "userCupon",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
