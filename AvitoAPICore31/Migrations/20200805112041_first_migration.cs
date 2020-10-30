using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvitoAPICore31.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    roleId = table.Column<int>(nullable: false),
                    adress = table.Column<string>(maxLength: 500, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    rating = table.Column<double>(nullable: true),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    photo = table.Column<string>(maxLength: 500, nullable: true),
                    companyName = table.Column<string>(maxLength: 50, nullable: true),
                    balance = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 500, nullable: false),
                    categoryId = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    dateOfPublication = table.Column<DateTime>(type: "date", nullable: false),
                    active = table.Column<bool>(nullable: false),
                    conditionId = table.Column<int>(nullable: false),
                    typeId = table.Column<int>(nullable: false),
                    communication = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ad_Category",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ad_Condition",
                        column: x => x.conditionId,
                        principalTable: "Condition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ad_Type",
                        column: x => x.typeId,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ad_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardNumber = table.Column<string>(maxLength: 50, nullable: true),
                    userId = table.Column<int>(nullable: false),
                    bankName = table.Column<string>(maxLength: 100, nullable: false),
                    bankLogo = table.Column<string>(maxLength: 100, nullable: false),
                    balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.id);
                    table.ForeignKey(
                        name: "FK_CreditCard_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adPhotos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo = table.Column<string>(maxLength: 200, nullable: true),
                    adId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adPhotos", x => x.id);
                    table.ForeignKey(
                        name: "FK_adPhotos_Ad",
                        column: x => x.adId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userIdReceiver = table.Column<int>(nullable: false),
                    userIdSender = table.Column<int>(nullable: false),
                    adId = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_Ad",
                        column: x => x.adId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.userIdReceiver,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User1",
                        column: x => x.userIdSender,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WatchHistory",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false),
                    adId = table.Column<int>(nullable: false),
                    seen = table.Column<bool>(nullable: false),
                    liked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchHistory", x => new { x.userId, x.adId });
                    table.ForeignKey(
                        name: "FK_WatchHistory_Ad",
                        column: x => x.adId,
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WatchHistory_User",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_categoryId",
                table: "Ad",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_conditionId",
                table: "Ad",
                column: "conditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_typeId",
                table: "Ad",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_userId",
                table: "Ad",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_adPhotos_adId",
                table: "adPhotos",
                column: "adId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_adId",
                table: "Comment",
                column: "adId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userIdReceiver",
                table: "Comment",
                column: "userIdReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userIdSender",
                table: "Comment",
                column: "userIdSender");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_userId",
                table: "CreditCard",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleId",
                table: "User",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchHistory_adId",
                table: "WatchHistory",
                column: "adId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adPhotos");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "WatchHistory");

            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
