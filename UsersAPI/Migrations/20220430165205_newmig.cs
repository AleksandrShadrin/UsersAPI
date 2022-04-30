using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("34d28791-fa8b-4584-80d4-828814a77dd9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("5021a836-4c84-4273-83b4-a4a2e62fde8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("604f9ec6-54d3-4d7c-bd00-b98755f0c266"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("e1ec4abd-4337-4d0d-8299-965c8cf6d6dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("fc785bca-e6a1-45e4-8b7c-9cd16c49d4b5"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "Password", "RevokedBy", "RevokedOn" },
                values: new object[,]
                {
                    { new Guid("1c7ebad1-90c2-4111-81b7-9368149c415a"), false, new DateTime(2003, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 1, "User4", null, null, "User4", "secret123", null, null },
                    { new Guid("2a4202c9-15ee-4c79-97cc-5719c81ebc98"), false, new DateTime(2004, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 0, "User3", null, null, "User3", "secret123", null, null },
                    { new Guid("4635728d-b2ed-47f9-b5b9-b73220a1ca67"), true, new DateTime(2022, 4, 30, 20, 52, 5, 180, DateTimeKind.Local).AddTicks(4390), "Init", null, 1, "Admin", null, null, "Admin", "secret123", null, null },
                    { new Guid("a97c1ca4-7d0b-445f-83b1-7f81d19c9845"), false, new DateTime(1979, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 0, "User1", null, null, "User1", "secret123", null, null },
                    { new Guid("da2158b3-cabc-4a7c-b887-449364f9ed3d"), false, new DateTime(1999, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 0, "User2", null, null, "User2", "secret123", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("1c7ebad1-90c2-4111-81b7-9368149c415a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("2a4202c9-15ee-4c79-97cc-5719c81ebc98"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("4635728d-b2ed-47f9-b5b9-b73220a1ca67"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("a97c1ca4-7d0b-445f-83b1-7f81d19c9845"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("da2158b3-cabc-4a7c-b887-449364f9ed3d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "Password", "RevokedBy", "RevokedOn" },
                values: new object[,]
                {
                    { new Guid("34d28791-fa8b-4584-80d4-828814a77dd9"), true, new DateTime(2022, 4, 30, 20, 8, 23, 721, DateTimeKind.Local).AddTicks(8741), "Init", null, 1, "Admin", null, null, "Admin", "secret123", null, null },
                    { new Guid("5021a836-4c84-4273-83b4-a4a2e62fde8d"), false, new DateTime(2004, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 0, "User3", null, null, "User3", "secret123", null, null },
                    { new Guid("604f9ec6-54d3-4d7c-bd00-b98755f0c266"), false, new DateTime(1999, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 0, "User2", null, null, "User2", "secret123", null, null },
                    { new Guid("e1ec4abd-4337-4d0d-8299-965c8cf6d6dc"), false, new DateTime(2003, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 1, "User4", null, null, "User4", "secret123", null, null },
                    { new Guid("fc785bca-e6a1-45e4-8b7c-9cd16c49d4b5"), false, new DateTime(1979, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Init", null, 0, "User1", null, null, "User1", "secret123", null, null }
                });
        }
    }
}
