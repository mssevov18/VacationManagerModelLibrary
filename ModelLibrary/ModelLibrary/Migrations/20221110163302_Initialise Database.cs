using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelLibrary.Migrations
{
    public partial class InitialiseDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamsWorkingOnProjectsConnection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsWorkingOnProjectsConnection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsWorkingOnProjectsConnection_Projects",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsWorkingOnProjectsConnection_Teams",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInTeamsConnection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInTeamsConnection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInTeamsConnection_Teams",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInTeamsConnection_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedById = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttachedFileId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_AttachedFiles",
                        column: x => x.AttachedFileId,
                        principalTable: "AttachedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Users",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Users1",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams",
                table: "Teams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamsWorkingOnProjectsConnection",
                table: "TeamsWorkingOnProjectsConnection",
                columns: new[] { "TeamId", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamsWorkingOnProjectsConnection_ProjectId",
                table: "TeamsWorkingOnProjectsConnection",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersInTeamsConnection",
                table: "UsersInTeamsConnection",
                columns: new[] { "TeamId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersInTeamsConnection_UserId",
                table: "UsersInTeamsConnection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_ApprovedById",
                table: "VacationRequests",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_AttachedFileId",
                table: "VacationRequests",
                column: "AttachedFileId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_RequesterId",
                table: "VacationRequests",
                column: "RequesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamsWorkingOnProjectsConnection");

            migrationBuilder.DropTable(
                name: "UsersInTeamsConnection");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "AttachedFiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
