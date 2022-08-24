using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleEcom.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    number = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    symbol = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    symbol_orientation = table.Column<int>(type: "integer", nullable: false),
                    spaced_symbol = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parent_category_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_product_category_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "product_category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    last_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    display_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_product_category_category_id",
                        column: x => x.category_id,
                        principalTable: "product_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_identity_user_claim_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_identity_user_login_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_token",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_identity_user_token_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_price",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    currency_id = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_price", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_price_currency_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_price_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_role_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_identity_role_claim_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_role",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_identity_user_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_identity_user_role_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "currency",
                columns: new[] { "id", "code", "name", "number", "spaced_symbol", "symbol", "symbol_orientation" },
                values: new object[,]
                {
                    { 1, "???", "Abkhazian apsar", "0", false, "?", 0 },
                    { 2, "RUB", "Russian ruble", "0", false, "₽", 0 },
                    { 3, "AFN", "Afghan afghani", "0", false, "؋", 0 },
                    { 4, "EUR", "Euro", "0", false, "€", 0 },
                    { 5, "ALL", "Albanian lek", "0", false, "L", 0 },
                    { 6, "???", "Alderney pound", "0", false, "£", 0 },
                    { 7, "GGP", "Guernsey pound", "0", false, "£", 0 },
                    { 8, "DZD", "Algerian dinar", "0", false, "د.ج", 0 },
                    { 10, "AOA", "Angolan kwanza", "0", false, "Kz", 0 },
                    { 11, "XCD", "Eastern Caribbean dollar", "0", false, "$", 0 },
                    { 13, "ARS", "Argentine peso", "0", false, "$", 0 },
                    { 14, "AMD", "Armenian dram", "0", false, "֏", 0 },
                    { 15, "???", "Artsakh dram", "0", false, "դր.", 0 },
                    { 17, "AWG", "Aruban florin", "0", false, "ƒ", 0 },
                    { 18, "SHP", "Saint Helena pound", "0", false, "£", 0 },
                    { 19, "AUD", "Australian dollar", "0", false, "$", 0 },
                    { 21, "AZN", "Azerbaijani manat", "0", false, "₼", 0 },
                    { 22, "BSD", "Bahamian dollar", "0", false, "$", 0 },
                    { 23, "BHD", "Bahraini dinar", "0", false, ".د.ب", 0 },
                    { 24, "BDT", "Bangladeshi taka", "0", false, "৳", 0 },
                    { 25, "BBD", "Barbadian dollar", "0", false, "$", 0 },
                    { 26, "BYN", "Belarusian ruble", "0", false, "Br", 0 },
                    { 28, "BZD", "Belize dollar", "0", false, "$", 0 },
                    { 29, "XOF", "West African CFA franc", "0", false, "Fr", 0 },
                    { 30, "BMD", "Bermudian dollar", "0", false, "$", 0 },
                    { 31, "BTN", "Bhutanese ngultrum", "0", false, "Nu.", 0 },
                    { 32, "INR", "Indian rupee", "0", false, "₹", 0 },
                    { 33, "BOB", "Bolivian boliviano", "0", false, "Bs.", 0 },
                    { 34, "USD", "United States dollar", "0", false, "$", 0 },
                    { 35, "BAM", "Bosnia and Herzegovina convertible mark", "0", false, "KM", 0 },
                    { 36, "BWP", "Botswana pula", "0", false, "P", 0 },
                    { 37, "BRL", "Brazilian real", "0", false, "R$", 0 },
                    { 40, "BND", "Brunei dollar", "0", false, "$", 0 },
                    { 41, "SGD", "Singapore dollar", "0", false, "$", 0 },
                    { 42, "BGN", "Bulgarian lev", "0", false, "лв.", 0 },
                    { 44, "BIF", "Burundian franc", "0", false, "Fr", 0 },
                    { 45, "KHR", "Cambodian riel", "0", false, "៛", 0 },
                    { 46, "XAF", "Central African CFA franc", "0", false, "Fr", 0 },
                    { 47, "CAD", "Canadian dollar", "0", false, "$", 0 },
                    { 48, "CVE", "Cape Verdean escudo", "0", false, "$", 0 },
                    { 49, "KYD", "Cayman Islands dollar", "0", false, "$", 0 },
                    { 51, "BTC", "Bitcoin", "0", false, "₿", 0 },
                    { 53, "CLP", "Chilean peso", "0", false, "$", 0 },
                    { 54, "CNY", "Renminbi/Chinese yuan", "0", false, "¥", 0 },
                    { 55, "COP", "Colombian peso", "0", false, "$", 0 },
                    { 56, "KMF", "Comorian franc", "0", false, "Fr", 0 },
                    { 57, "CDF", "Congolese franc", "0", false, "Fr", 0 },
                    { 59, "CKD", "Cook Islands dollar", "0", false, "$", 0 },
                    { 60, "NZD", "New Zealand dollar", "0", false, "$", 0 },
                    { 61, "CRC", "Costa Rican colón", "0", false, "₡", 0 },
                    { 63, "HRK", "Croatian kuna", "0", false, "kn", 0 },
                    { 64, "CUP", "Cuban peso", "0", false, "$", 0 },
                    { 65, "ANG", "Netherlands Antillean guilder", "0", false, "ƒ", 0 },
                    { 67, "CZK", "Czech koruna", "0", false, "Kč", 0 },
                    { 68, "DKK", "Danish krone", "0", false, "kr", 0 },
                    { 69, "DJF", "Djiboutian franc", "0", false, "Fr", 0 },
                    { 71, "DOP", "Dominican peso", "0", false, "RD$", 0 },
                    { 76, "EGP", "Egyptian pound", "0", false, "£E", 0 },
                    { 80, "ERN", "Eritrean nakfa", "0", false, "Nfk.", 0 },
                    { 82, "SZL", "Swazi lilangeni", "0", false, "L", 0 },
                    { 83, "ZAR", "South African rand", "0", false, "R", 0 },
                    { 84, "ETB", "Ethiopian birr", "0", false, "Br", 0 },
                    { 85, "FKP", "Falkland Islands pound", "0", false, "£", 0 },
                    { 87, "FOK", "Faroese króna", "0", false, "kr", 0 },
                    { 88, "FJD", "Fijian dollar", "0", false, "$", 0 },
                    { 91, "XPF", "CFP franc", "0", false, "₣", 0 },
                    { 93, "GMD", "Gambian dalasi", "0", false, "D", 0 },
                    { 94, "GEL", "Georgian lari", "0", false, "₾", 0 },
                    { 96, "GHS", "Ghanaian cedi", "0", false, "₵", 0 },
                    { 97, "GIP", "Gibraltar pound", "0", false, "£", 0 },
                    { 101, "GTQ", "Guatemalan quetzal", "0", false, "Q", 0 },
                    { 103, "GBP", "Sterling", "0", false, "£", 0 },
                    { 104, "GNF", "Guinean franc", "0", false, "Fr", 0 },
                    { 106, "GYD", "Guyanese dollar", "0", false, "$", 0 },
                    { 107, "HTG", "Haitian gourde", "0", false, "G", 0 },
                    { 108, "HNL", "Honduran lempira", "0", false, "L", 0 },
                    { 109, "HKD", "Hong Kong dollar", "0", false, "$", 0 },
                    { 110, "HUF", "Hungarian forint", "0", false, "Ft", 0 },
                    { 111, "ISK", "Icelandic króna", "0", false, "kr", 0 },
                    { 113, "IDR", "Indonesian rupiah", "0", false, "Rp", 0 },
                    { 114, "IRR", "Iranian rial", "0", false, "﷼", 0 },
                    { 115, "IQD", "Iraqi dinar", "0", false, "ع.د", 0 },
                    { 117, "IMP", "Manx pound", "0", false, "£", 0 },
                    { 119, "ILS", "Israeli new shekel", "0", false, "₪", 0 },
                    { 121, "JMD", "Jamaican dollar", "0", false, "$", 0 },
                    { 122, "JPY", "Japanese yen", "0", false, "¥", 0 },
                    { 123, "JEP", "Jersey pound", "0", false, "£", 0 },
                    { 125, "JOD", "Jordanian dinar", "0", false, "د.ا", 0 },
                    { 126, "KZT", "Kazakhstani tenge", "0", false, "₸", 0 },
                    { 127, "KES", "Kenyan shilling", "0", false, "Sh", 0 },
                    { 128, "KID", "Kiribati dollar", "0", false, "$", 0 },
                    { 130, "KPW", "North Korean won", "0", false, "₩", 0 },
                    { 131, "KRW", "South Korean won", "0", false, "₩", 0 },
                    { 133, "KWD", "Kuwaiti dinar", "0", false, "د.ك", 0 },
                    { 134, "KGS", "Kyrgyz som", "0", false, "с", 0 },
                    { 135, "LAK", "Lao kip", "0", false, "₭", 0 },
                    { 137, "LBP", "Lebanese pound", "0", false, "ل.ل", 0 },
                    { 138, "LSL", "Lesotho loti", "0", false, "L", 0 },
                    { 140, "LRD", "Liberian dollar", "0", false, "$", 0 },
                    { 141, "LYD", "Libyan dinar", "0", false, "ل.د", 0 },
                    { 142, "CHF", "Swiss franc", "0", false, "Fr.", 0 },
                    { 145, "MOP", "Macanese pataca", "0", false, "MOP$", 0 },
                    { 147, "MGA", "Malagasy ariary", "0", false, "Ar", 0 },
                    { 148, "MWK", "Malawian kwacha", "0", false, "MK", 0 },
                    { 149, "MYR", "Malaysian ringgit", "0", false, "RM", 0 },
                    { 150, "MVR", "Maldivian rufiyaa", "0", false, ".ރ", 0 },
                    { 154, "MRU", "Mauritanian ouguiya", "0", false, "UM", 0 },
                    { 155, "MUR", "Mauritian rupee", "0", false, "₨", 0 },
                    { 156, "MXN", "Mexican peso", "0", false, "$", 0 },
                    { 158, "MDL", "Moldovan leu", "0", false, "L", 0 },
                    { 160, "MNT", "Mongolian tögrög", "0", false, "₮", 0 },
                    { 163, "MAD", "Moroccan dirham", "0", false, "د.م.", 0 },
                    { 164, "MZN", "Mozambican metical", "0", false, "MT", 0 },
                    { 165, "MMK", "Burmese kyat", "0", false, "Ks", 0 },
                    { 166, "NAD", "Namibian dollar", "0", false, "$", 0 },
                    { 169, "NPR", "Nepalese rupee", "0", false, "रू", 0 },
                    { 173, "NIO", "Nicaraguan córdoba", "0", false, "C$", 0 },
                    { 175, "NGN", "Nigerian naira", "0", false, "₦", 0 },
                    { 177, "???", "Niue dollar", "0", false, "$", 0 },
                    { 178, "MKD", "Macedonian denar", "0", false, "ден", 0 },
                    { 179, "TRY", "Turkish lira", "0", false, "₺", 0 },
                    { 180, "NOK", "Norwegian krone", "0", false, "kr", 0 },
                    { 181, "OMR", "Omani rial", "0", false, "ر.ع.", 0 },
                    { 182, "PKR", "Pakistani rupee", "0", false, "₨", 0 },
                    { 186, "PAB", "Panamanian balboa", "0", false, "B/.", 0 },
                    { 188, "PGK", "Papua New Guinean kina", "0", false, "K", 0 },
                    { 189, "PYG", "Paraguayan guaraní", "0", false, "₲", 0 },
                    { 190, "PEN", "Peruvian sol", "0", false, "S/.", 0 },
                    { 191, "PHP", "Philippine peso", "0", false, "₱", 0 },
                    { 193, "PND", "Pitcairn Islands dollar", "0", false, "$", 0 },
                    { 194, "PLN", "Polish złoty", "0", false, "zł", 0 },
                    { 196, "QAR", "Qatari riyal", "0", false, "ر.ق", 0 },
                    { 197, "RON", "Romanian leu", "0", false, "lei", 0 },
                    { 199, "RWF", "Rwandan franc", "0", false, "Fr", 0 },
                    { 204, "???", "Sahrawi peseta", "0", false, "Ptas", 0 },
                    { 209, "WST", "Samoan tālā", "0", false, "T", 0 },
                    { 211, "STN", "São Tomé and Príncipe dobra", "0", false, "Db", 0 },
                    { 212, "SAR", "Saudi riyal", "0", false, "﷼", 0 },
                    { 214, "RSD", "Serbian dinar", "0", false, "din.", 0 },
                    { 215, "SCR", "Seychellois rupee", "0", false, "₨", 0 },
                    { 216, "SLL", "Sierra Leonean leone", "0", false, "Le", 0 },
                    { 223, "SBD", "Solomon Islands dollar", "0", false, "$", 0 },
                    { 224, "SOS", "Somali shilling", "0", false, "Sh", 0 },
                    { 225, "SLS", "Somaliland shilling", "0", false, "Sl", 0 },
                    { 229, "SSP", "South Sudanese pound", "0", false, "£", 0 },
                    { 230, "LKR", "Sri Lankan rupee", "0", false, "Rs", 0 },
                    { 231, "SDG", "Sudanese pound", "0", false, "ج.س.", 0 },
                    { 232, "SRD", "Surinamese dollar", "0", false, "$", 0 },
                    { 233, "SEK", "Swedish krona", "0", false, "kr", 0 },
                    { 235, "SYP", "Syrian pound", "0", false, "£S", 0 },
                    { 236, "TWD", "New Taiwan dollar", "0", false, "$", 0 },
                    { 237, "TJS", "Tajikistani somoni", "0", false, "с.", 0 },
                    { 238, "TZS", "Tanzanian shilling", "0", false, "Sh", 0 },
                    { 239, "THB", "Thai baht", "0", false, "฿", 0 },
                    { 241, "TOP", "Tongan paʻanga", "0", false, "T$", 0 },
                    { 242, "PRB", "Transnistrian ruble", "0", false, "р.", 0 },
                    { 243, "TTD", "Trinidad and Tobago dollar", "0", false, "$", 0 },
                    { 244, "TND", "Tunisian dinar", "0", false, "د.ت", 0 },
                    { 246, "TMT", "Turkmenistan manat", "0", false, "m.", 0 },
                    { 248, "TVD", "Tuvaluan dollar", "0", false, "$", 0 },
                    { 250, "UGX", "Ugandan shilling", "0", false, "USh", 0 },
                    { 251, "UAH", "Ukrainian hryvnia", "0", false, "₴", 0 },
                    { 252, "AED", "United Arab Emirates dirham", "0", false, "د.إ", 0 },
                    { 255, "UYU", "Uruguayan peso", "0", false, "$", 0 },
                    { 256, "UZS", "Uzbekistani so'm", "0", false, "Sʻ", 0 },
                    { 257, "VUV", "Vanuatu vatu", "0", false, "Vt", 0 },
                    { 259, "VES", "Venezuelan sovereign bolívar", "0", false, "Bs.", 0 },
                    { 260, "VED", "Venezuelan bolívar digital", "0", false, "Bs.", 0 },
                    { 261, "VND", "Vietnamese đồng", "0", false, "₫", 0 },
                    { 263, "YER", "Yemeni rial", "0", false, "﷼", 0 },
                    { 264, "ZMW", "Zambian kwacha", "0", false, "ZK", 0 },
                    { 265, "ZWB", "RTGS dollar", "0", false, "RTGS$", 0 }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "user_id" },
                values: new object[,]
                {
                    { 1, "e994d361-ec97-4409-8bdb-69ad4d4ca01d", "SystemAdmin", "SYSTEMADMIN", null },
                    { 2, "6eaeab58-0fd0-4849-893d-0d12f2bd8ce3", "SiteAdmin", "SITEADMIN", null },
                    { 3, "9a391831-de69-49c5-a02b-2ea5e34d4131", "SiteUser", "SITEUSER", null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "first_name", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { 1, 0, "52100990-dd09-43be-a6d1-8bf2343d2383", "system.admin@example-ecom.com", true, "SYSTEM", "ADMIN", false, null, "SYSTEM.ADMIN@EXAMPLE-ECOM.COM", "SYSTEM_ADMIN", "AQAAAAEAACcQAAAAECp/si0EGzIT/ph6LUE9osq8AVaGCjfHH1WsVCNCV6pCtM9AO3gE5jz2LJATWnuXrA==", null, false, "fe8f130d-872c-4a76-9955-cbc74fd66847", false, "SYSTEM_ADMIN" });

            migrationBuilder.InsertData(
                table: "identity_user_role",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_identity_role_claim_role_id",
                table: "identity_role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_identity_user_claim_user_id",
                table: "identity_user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_identity_user_login_user_id",
                table: "identity_user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_identity_user_role_role_id",
                table: "identity_user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_parent_category_id",
                table: "product_category",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_price_currency_id",
                table: "product_price",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_price_product_id",
                table: "product_price",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_user_id",
                table: "role",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "normalized_user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "identity_role_claim");

            migrationBuilder.DropTable(
                name: "identity_user_claim");

            migrationBuilder.DropTable(
                name: "identity_user_login");

            migrationBuilder.DropTable(
                name: "identity_user_role");

            migrationBuilder.DropTable(
                name: "identity_user_token");

            migrationBuilder.DropTable(
                name: "product_price");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "product_category");
        }
    }
}
