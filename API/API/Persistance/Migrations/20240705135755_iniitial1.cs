using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class iniitial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Quizes",
                newName: "Status");

            migrationBuilder.AddColumn<bool>(
                name: "IsOver",
                table: "UserQuizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaking",
                table: "UserQuizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserQuizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TimeToComplite",
                table: "UserQuizzes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOver",
                table: "UserQuizzes");

            migrationBuilder.DropColumn(
                name: "IsTaking",
                table: "UserQuizzes");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserQuizzes");

            migrationBuilder.DropColumn(
                name: "TimeToComplite",
                table: "UserQuizzes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "PersonalNumber");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Quizes",
                newName: "Score");
        }
    }
}
