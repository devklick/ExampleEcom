using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleEcom.Infrastructure.Migrations
{
    public partial class NormalizedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_role_id",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_user_id",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_user_id",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_role_id",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_user_id",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_user_id",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_category_category_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_product_category_parent_category_id",
                table: "product_category");

            migrationBuilder.DropForeignKey(
                name: "FK_product_price_product_product_id",
                table: "product_price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_category",
                table: "product_category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "product_category",
                newName: "product_categories");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "asp_net_user_tokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "asp_net_users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "asp_net_user_roles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "asp_net_user_logins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "asp_net_user_claims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "asp_net_roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "asp_net_role_claims");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_parent_category_id",
                table: "product_categories",
                newName: "IX_product_categories_parent_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_id",
                table: "products",
                newName: "IX_products_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_role_id",
                table: "asp_net_user_roles",
                newName: "IX_asp_net_user_roles_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_user_id",
                table: "asp_net_user_logins",
                newName: "IX_asp_net_user_logins_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_user_id",
                table: "asp_net_user_claims",
                newName: "IX_asp_net_user_claims_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_role_id",
                table: "asp_net_role_claims",
                newName: "IX_asp_net_role_claims_role_id");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "asp_net_roles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_categories",
                table: "product_categories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_user_tokens",
                table: "asp_net_user_tokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_users",
                table: "asp_net_users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_user_roles",
                table: "asp_net_user_roles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_user_logins",
                table: "asp_net_user_logins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_user_claims",
                table: "asp_net_user_claims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_roles",
                table: "asp_net_roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_role_claims",
                table: "asp_net_role_claims",
                column: "id");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "ff648c48-d0a3-4b5d-8101-901b41b9a9d9", "SYSTEMADMIN" });

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "7eb2d2cb-bb24-41b8-abba-823468165070", "SITEADMIN" });

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "898e525b-eda8-47a1-8a5b-a1006c3a85fc", "SITEUSER" });

            migrationBuilder.UpdateData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "normalized_email", "normalized_user_name", "password_hash" },
                values: new object[] { "7191eb14-6fa4-47f4-a357-60ac6c421116", "SYSTEM.ADMIN@EXAMPLE-ECOM.COM", "SYSTEM_ADMIN", "AQAAAAEAACcQAAAAEI+YTnsxGHhBo9pyvDGhMxcagqZ3uLKjFc9Bx2ZGg4/3h0W9nno+CRjr3lyKxdUwxw==" });

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_roles_user_id",
                table: "asp_net_roles",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_role_claims_asp_net_roles_role_id",
                table: "asp_net_role_claims",
                column: "role_id",
                principalTable: "asp_net_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_roles_asp_net_users_user_id",
                table: "asp_net_roles",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_claims_asp_net_users_user_id",
                table: "asp_net_user_claims",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_logins_asp_net_users_user_id",
                table: "asp_net_user_logins",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_roles_asp_net_roles_role_id",
                table: "asp_net_user_roles",
                column: "role_id",
                principalTable: "asp_net_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_roles_asp_net_users_user_id",
                table: "asp_net_user_roles",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_tokens_asp_net_users_user_id",
                table: "asp_net_user_tokens",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_categories_product_categories_parent_category_id",
                table: "product_categories",
                column: "parent_category_id",
                principalTable: "product_categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_price_products_product_id",
                table: "product_price",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_product_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "product_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_role_claims_asp_net_roles_role_id",
                table: "asp_net_role_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_roles_asp_net_users_user_id",
                table: "asp_net_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_claims_asp_net_users_user_id",
                table: "asp_net_user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_logins_asp_net_users_user_id",
                table: "asp_net_user_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_roles_asp_net_roles_role_id",
                table: "asp_net_user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_roles_asp_net_users_user_id",
                table: "asp_net_user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_tokens_asp_net_users_user_id",
                table: "asp_net_user_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_product_categories_product_categories_parent_category_id",
                table: "product_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_product_price_products_product_id",
                table: "product_price");

            migrationBuilder.DropForeignKey(
                name: "FK_products_product_categories_category_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_categories",
                table: "product_categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_users",
                table: "asp_net_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_user_tokens",
                table: "asp_net_user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_user_roles",
                table: "asp_net_user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_user_logins",
                table: "asp_net_user_logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_user_claims",
                table: "asp_net_user_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_roles",
                table: "asp_net_roles");

            migrationBuilder.DropIndex(
                name: "IX_asp_net_roles_user_id",
                table: "asp_net_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_role_claims",
                table: "asp_net_role_claims");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "asp_net_roles");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "product_categories",
                newName: "product_category");

            migrationBuilder.RenameTable(
                name: "asp_net_users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "asp_net_user_tokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "asp_net_user_roles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "asp_net_user_logins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "asp_net_user_claims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "asp_net_roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "asp_net_role_claims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_products_category_id",
                table: "product",
                newName: "IX_product_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_categories_parent_category_id",
                table: "product_category",
                newName: "IX_product_category_parent_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_category",
                table: "product_category",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "6d688c6b-6ebd-43af-b9ec-f2d6b289e9c6", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "d5b5391c-b79f-448c-82f3-3b2c76464ce6", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "9344c678-e6a6-4fbb-98e4-f10121bc63a1", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "normalized_email", "normalized_user_name", "password_hash" },
                values: new object[] { "d3da3376-ff60-4882-a890-466dc53efe35", null, null, "AQAAAAEAACcQAAAAEANLjZymlWvuMaeERlTbDzrun+RpAKZqHoK/se5eT6IkZLAfrpoPGRBMUdtAws5iwA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_role_id",
                table: "AspNetRoleClaims",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_user_id",
                table: "AspNetUserClaims",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_user_id",
                table: "AspNetUserLogins",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_role_id",
                table: "AspNetUserRoles",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_user_id",
                table: "AspNetUserRoles",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_user_id",
                table: "AspNetUserTokens",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_category_category_id",
                table: "product",
                column: "category_id",
                principalTable: "product_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_product_category_parent_category_id",
                table: "product_category",
                column: "parent_category_id",
                principalTable: "product_category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_price_product_product_id",
                table: "product_price",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
