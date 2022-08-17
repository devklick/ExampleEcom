using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleEcom.Infrastructure.Persistence
{
    public partial class SnakeCaseColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_product_category_ParentCategoryId",
                table: "product_category");

            migrationBuilder.DropForeignKey(
                name: "FK_product_price_currency_CurrencyId",
                table: "product_price");

            migrationBuilder.DropForeignKey(
                name: "FK_product_price_product_ProductId",
                table: "product_price");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "product_price",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product_price",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "product_price",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "product_price",
                newName: "currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_price_ProductId",
                table: "product_price",
                newName: "IX_product_price_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_price_CurrencyId",
                table: "product_price",
                newName: "IX_product_price_currency_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product_category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product_category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "product_category",
                newName: "parent_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_ParentCategoryId",
                table: "product_category",
                newName: "IX_product_category_parent_category_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "product",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "product",
                newName: "display_name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "product",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
                table: "product",
                newName: "IX_product_category_id");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "currency",
                newName: "symbol");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "currency",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "currency",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "currency",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "currency",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SymbolOrientation",
                table: "currency",
                newName: "symbol_orientation");

            migrationBuilder.RenameColumn(
                name: "SpacedSymbol",
                table: "currency",
                newName: "spaced_symbol");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AspNetUserTokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUserTokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserTokens",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AspNetUsers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "AspNetUsers",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AspNetUsers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "AspNetUsers",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "AspNetUsers",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AspNetUserRoles",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserRoles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserLogins",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "AspNetUserLogins",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUserClaims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserClaims",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AspNetUserClaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AspNetUserClaims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetRoles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "AspNetRoles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AspNetRoles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoleClaims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AspNetRoleClaims",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AspNetRoleClaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AspNetRoleClaims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_role_id");

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
                name: "FK_product_price_currency_currency_id",
                table: "product_price",
                column: "currency_id",
                principalTable: "currency",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_price_product_product_id",
                table: "product_price",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_product_price_currency_currency_id",
                table: "product_price");

            migrationBuilder.DropForeignKey(
                name: "FK_product_price_product_product_id",
                table: "product_price");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "product_price",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "product_price",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "product_price",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "currency_id",
                table: "product_price",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_product_price_product_id",
                table: "product_price",
                newName: "IX_product_price_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_product_price_currency_id",
                table: "product_price",
                newName: "IX_product_price_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "product_category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "product_category",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parent_category_id",
                table: "product_category",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_parent_category_id",
                table: "product_category",
                newName: "IX_product_category_ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "product",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "display_name",
                table: "product",
                newName: "DisplayName");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_product_category_id",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.RenameColumn(
                name: "symbol",
                table: "currency",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "currency",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "currency",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "currency",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "currency",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "symbol_orientation",
                table: "currency",
                newName: "SymbolOrientation");

            migrationBuilder.RenameColumn(
                name: "spaced_symbol",
                table: "currency",
                newName: "SpacedSymbol");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "AspNetUsers",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                table: "AspNetUsers",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AspNetUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                table: "AspNetUsers",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                table: "AspNetUsers",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                table: "AspNetUsers",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "AspNetUsers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "AspNetUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_role_id",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_user_id",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_user_id",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_role_id",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "product_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_product_category_ParentCategoryId",
                table: "product_category",
                column: "ParentCategoryId",
                principalTable: "product_category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_price_currency_CurrencyId",
                table: "product_price",
                column: "CurrencyId",
                principalTable: "currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_price_product_ProductId",
                table: "product_price",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
