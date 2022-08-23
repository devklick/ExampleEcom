using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleEcom.Infrastructure.Migrations
{
    public partial class SeedDataStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "859fec43-4c08-495e-a02d-b4738186a830");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "57c79293-3e92-470e-be4c-a55e2e61f90d");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "68e0d2e6-23cf-4e48-bb0c-12cd3dd7cfc3");

            migrationBuilder.UpdateData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "bed9bd9e-0b4f-4393-b649-8d31792f3c6a", "AQAAAAEAACcQAAAAENf7VnaQ2oblo1GqF5qFhd58TmsOM7rB+jcodRGOc3KNnRZ4CrC17c8wZWo/n4yzow==", "c7234a8d-c40c-4d11-86b0-06256cbac3b0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "ff648c48-d0a3-4b5d-8101-901b41b9a9d9");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "7eb2d2cb-bb24-41b8-abba-823468165070");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "898e525b-eda8-47a1-8a5b-a1006c3a85fc");

            migrationBuilder.UpdateData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "7191eb14-6fa4-47f4-a357-60ac6c421116", "AQAAAAEAACcQAAAAEI+YTnsxGHhBo9pyvDGhMxcagqZ3uLKjFc9Bx2ZGg4/3h0W9nno+CRjr3lyKxdUwxw==", null });
        }
    }
}
