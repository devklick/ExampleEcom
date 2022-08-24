using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using Microsoft.Extensions.Configuration;
using ExampleEcom.Domain.Aggregates.ProductAggregates;

namespace ExampleEcom.Infrastructure.Persistence.Extensions
{
    public static class ModelBuilderSeeding
    {
        public static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = RoleConstants.SYSTEM_ADMIN_ROLE_ID,
                    Name = RoleConstants.SYSTEM_ADMIN_ROLE_NAME,
                    NormalizedName = RoleConstants.SYSTEM_ADMIN_ROLE_NAME_NORMALIZED,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = RoleConstants.SITE_ADMIN_ROLE_ID,
                    Name = RoleConstants.SITE_ADMIN_ROLE_NAME,
                    NormalizedName = RoleConstants.SITE_ADMIN_ROLE_NAME_NORMALIZED,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = RoleConstants.SITE_USER_ROLE_ID,
                    Name = RoleConstants.SITE_USER_ROLE_NAME,
                    NormalizedName = RoleConstants.SITE_USER_ROLE_NAME_NORMALIZED,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }

        public static void SeedUsers(this ModelBuilder builder, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            var adminUser = new User
            {
                Id = UserConstants.SYSTEM_ADMIN_USER_ID,
                Email = "system.admin@example-ecom.com",
                EmailConfirmed = true,
                FirstName = "SYSTEM",
                LastName = "ADMIN",
                LockoutEnabled = false,
                UserName = UserConstants.SYSTEM_ADMIN_USER_NAME,
                NormalizedUserName = UserConstants.SYSTEM_ADMIN_USER_NAME_NORMALIZED,
                NormalizedEmail = "system.admin@example-ecom.com".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, configuration["SeedData:SystemAdmin:Password"]);
            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = RoleConstants.SYSTEM_ADMIN_ROLE_ID,
                UserId = UserConstants.SYSTEM_ADMIN_USER_ID
            },
            new IdentityUserRole<int>
            {
                RoleId = RoleConstants.SITE_ADMIN_ROLE_ID,
                UserId = UserConstants.SYSTEM_ADMIN_USER_ID
            });
        }

        public static void SeedCurrencies(this ModelBuilder builder)
        {
            var currencies = new[] {
                // A
                new Currency { Name = "United Arab Emirates dirham", Code = "AED", Symbol = "د.إ", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 252, SpacedSymbol = false },
                new Currency { Name = "Afghan afghani", Code = "AFN", Symbol = "؋", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 3, SpacedSymbol = false },
                new Currency { Name = "Albanian lek", Code = "ALL", Symbol = "L", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 5, SpacedSymbol = false },
                new Currency { Name = "Armenian dram", Code = "AMD", Symbol = "֏", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 14, SpacedSymbol = false },
                new Currency { Name = "Netherlands Antillean guilder", Code = "ANG", Symbol = "ƒ", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 65, SpacedSymbol = false },
                new Currency { Name = "Angolan kwanza", Code = "AOA", Symbol = "Kz", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 10, SpacedSymbol = false },
                new Currency { Name = "Argentine peso", Code = "ARS", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 13, SpacedSymbol = false },
                new Currency { Name = "Australian dollar", Code = "AUD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 19, SpacedSymbol = false },
                new Currency { Name = "Aruban florin", Code = "AWG", Symbol = "ƒ", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 17, SpacedSymbol = false },
                new Currency { Name = "Azerbaijani manat", Code = "AZN", Symbol = "₼", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 21, SpacedSymbol = false },

                // B
                new Currency { Name = "Bahamian dollar", Code = "BSD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 22, SpacedSymbol = false },
                new Currency { Name = "Bahraini dinar", Code = "BHD", Symbol = ".د.ب", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 23, SpacedSymbol = false },
                new Currency { Name = "Bangladeshi taka", Code = "BDT", Symbol = "৳", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 24, SpacedSymbol = false },
                new Currency { Name = "Barbadian dollar", Code = "BBD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 25, SpacedSymbol = false },
                new Currency { Name = "Belarusian ruble", Code = "BYN", Symbol = "Br", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 26, SpacedSymbol = false },
                new Currency { Name = "Belize dollar", Code = "BZD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 28, SpacedSymbol = false },
                new Currency { Name = "Bermudian dollar", Code = "BMD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 30, SpacedSymbol = false },
                new Currency { Name = "Bhutanese ngultrum", Code = "BTN", Symbol = "Nu.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 31, SpacedSymbol = false },
                new Currency { Name = "Bolivian boliviano", Code = "BOB", Symbol = "Bs.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 33, SpacedSymbol = false },
                new Currency { Name = "Bosnia and Herzegovina convertible mark", Code = "BAM", Symbol = "KM", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 35, SpacedSymbol = false },
                new Currency { Name = "Botswana pula", Code = "BWP", Symbol = "P", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 36, SpacedSymbol = false },
                new Currency { Name = "Brazilian real", Code = "BRL", Symbol = "R$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 37, SpacedSymbol = false },
                new Currency { Name = "Brunei dollar", Code = "BND", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 40, SpacedSymbol = false },
                new Currency { Name = "Bulgarian lev", Code = "BGN", Symbol = "лв.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 42, SpacedSymbol = false },
                new Currency { Name = "Burundian franc", Code = "BIF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 44, SpacedSymbol = false },
                new Currency { Name = "Bitcoin", Code = "BTC", Symbol = "₿", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 51, SpacedSymbol = false },
                
                // C
                new Currency { Name = "Canadian dollar", Code = "CAD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 47, SpacedSymbol = false },
                new Currency { Name = "Cape Verdean escudo", Code = "CVE", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 48, SpacedSymbol = false },
                new Currency { Name = "Chilean peso", Code = "CLP", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 53, SpacedSymbol = false },
                new Currency { Name = "Renminbi/Chinese yuan", Code = "CNY", Symbol = "¥", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 54, SpacedSymbol = false },
                new Currency { Name = "Colombian peso", Code = "COP", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 55, SpacedSymbol = false },
                new Currency { Name = "Congolese franc", Code = "CDF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 57, SpacedSymbol = false },
                new Currency { Name = "Cook Islands dollar", Code = "CKD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 59, SpacedSymbol = false },
                new Currency { Name = "Costa Rican colón", Code = "CRC", Symbol = "₡", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 61, SpacedSymbol = false },
                new Currency { Name = "Cuban peso", Code = "CUP", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 64, SpacedSymbol = false },
                new Currency { Name = "Czech koruna", Code = "CZK", Symbol = "Kč", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 67, SpacedSymbol = false },
                new Currency { Name = "Swiss franc", Code = "CHF", Symbol = "Fr.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 142, SpacedSymbol = false },
                
                // D
                new Currency { Name = "Algerian dinar", Code = "DZD", Symbol = "د.ج", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 8, SpacedSymbol = false },
                new Currency { Name = "Danish krone", Code = "DKK", Symbol = "kr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 68, SpacedSymbol = false },
                new Currency { Name = "Djiboutian franc", Code = "DJF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 69, SpacedSymbol = false },
                new Currency { Name = "Dominican peso", Code = "DOP", Symbol = "RD$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 71, SpacedSymbol = false },

                // E
                new Currency { Name = "Euro", Code = "EUR", Symbol = "€", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 4, SpacedSymbol = false },
                new Currency { Name = "Egyptian pound", Code = "EGP", Symbol = "£E", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 76, SpacedSymbol = false },
                new Currency { Name = "Eritrean nakfa", Code = "ERN", Symbol = "Nfk.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 80, SpacedSymbol = false },
                new Currency { Name = "Ethiopian birr", Code = "ETB", Symbol = "Br", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 84, SpacedSymbol = false },

                // F
                new Currency { Name = "Falkland Islands pound", Code = "FKP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 85, SpacedSymbol = false },
                new Currency { Name = "Faroese króna", Code = "FOK", Symbol = "kr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 87, SpacedSymbol = false },
                new Currency { Name = "Fijian dollar", Code = "FJD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 88, SpacedSymbol = false },

                // G
                new Currency { Name = "Guernsey pound", Code = "GGP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 7, SpacedSymbol = false },
                new Currency { Name = "Gambian dalasi", Code = "GMD", Symbol = "D", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 93, SpacedSymbol = false },
                new Currency { Name = "Georgian lari", Code = "GEL", Symbol = "₾", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 94, SpacedSymbol = false },
                new Currency { Name = "Ghanaian cedi", Code = "GHS", Symbol = "₵", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 96, SpacedSymbol = false },
                new Currency { Name = "Gibraltar pound", Code = "GIP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 97, SpacedSymbol = false },
                new Currency { Name = "Guatemalan quetzal", Code = "GTQ", Symbol = "Q", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 101, SpacedSymbol = false },
                new Currency { Name = "Sterling", Code = "GBP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 103, SpacedSymbol = false },
                new Currency { Name = "Guinean franc", Code = "GNF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 104, SpacedSymbol = false },
                new Currency { Name = "Guyanese dollar", Code = "GYD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 106, SpacedSymbol = false },

                // H
                new Currency { Name = "Croatian kuna", Code = "HRK", Symbol = "kn", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 63, SpacedSymbol = false },
                new Currency { Name = "Haitian gourde", Code = "HTG", Symbol = "G", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 107, SpacedSymbol = false },
                new Currency { Name = "Honduran lempira", Code = "HNL", Symbol = "L", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 108, SpacedSymbol = false },
                new Currency { Name = "Hong Kong dollar", Code = "HKD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 109, SpacedSymbol = false },
                new Currency { Name = "Hungarian forint", Code = "HUF", Symbol = "Ft", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 110, SpacedSymbol = false },

                // I
                new Currency { Name = "Indian rupee", Code = "INR", Symbol = "₹", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 32, SpacedSymbol = false },
                new Currency { Name = "Icelandic króna", Code = "ISK", Symbol = "kr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 111, SpacedSymbol = false },
                new Currency { Name = "Indonesian rupiah", Code = "IDR", Symbol = "Rp", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 113, SpacedSymbol = false },
                new Currency { Name = "Iranian rial", Code = "IRR", Symbol = "﷼", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 114, SpacedSymbol = false },
                new Currency { Name = "Iraqi dinar", Code = "IQD", Symbol = "ع.د", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 115, SpacedSymbol = false },
                new Currency { Name = "Manx pound", Code = "IMP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 117, SpacedSymbol = false },
                new Currency { Name = "Israeli new shekel", Code = "ILS", Symbol = "₪", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 119, SpacedSymbol = false },

                // J
                new Currency { Name = "Jamaican dollar", Code = "JMD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 121, SpacedSymbol = false },
                new Currency { Name = "Japanese yen", Code = "JPY", Symbol = "¥", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 122, SpacedSymbol = false },
                new Currency { Name = "Jersey pound", Code = "JEP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 123, SpacedSymbol = false },
                new Currency { Name = "Jordanian dinar", Code = "JOD", Symbol = "د.ا", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 125, SpacedSymbol = false },

                // K
                new Currency { Name = "Cambodian riel", Code = "KHR", Symbol = "៛", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 45, SpacedSymbol = false },
                new Currency { Name = "Cayman Islands dollar", Code = "KYD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 49, SpacedSymbol = false },
                new Currency { Name = "Kazakhstani tenge", Code = "KZT", Symbol = "₸", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 126, SpacedSymbol = false },
                new Currency { Name = "Kenyan shilling", Code = "KES", Symbol = "Sh", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 127, SpacedSymbol = false },
                new Currency { Name = "Kiribati dollar", Code = "KID", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 128, SpacedSymbol = false },
                new Currency { Name = "North Korean won", Code = "KPW", Symbol = "₩", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 130, SpacedSymbol = false },
                new Currency { Name = "South Korean won", Code = "KRW", Symbol = "₩", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 131, SpacedSymbol = false },
                new Currency { Name = "Kuwaiti dinar", Code = "KWD", Symbol = "د.ك", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 133, SpacedSymbol = false },
                new Currency { Name = "Kyrgyz som", Code = "KGS", Symbol = "с", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 134, SpacedSymbol = false },
                new Currency { Name = "Comorian franc", Code = "KMF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 56, SpacedSymbol = false },

                // L
                new Currency { Name = "Lao kip", Code = "LAK", Symbol = "₭", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 135, SpacedSymbol = false },
                new Currency { Name = "Lebanese pound", Code = "LBP", Symbol = "ل.ل", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 137, SpacedSymbol = false },
                new Currency { Name = "Lesotho loti", Code = "LSL", Symbol = "L", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 138, SpacedSymbol = false },
                new Currency { Name = "Liberian dollar", Code = "LRD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 140, SpacedSymbol = false },
                new Currency { Name = "Libyan dinar", Code = "LYD", Symbol = "ل.د", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 141, SpacedSymbol = false },
                new Currency { Name = "Sri Lankan rupee", Code = "LKR", Symbol = "Rs", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 230, SpacedSymbol = false },

                // M
                new Currency { Name = "Macedonian denar", Code = "MKD", Symbol = "ден", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 178, SpacedSymbol = false },
                new Currency { Name = "Macanese pataca", Code = "MOP", Symbol = "MOP$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 145, SpacedSymbol = false },
                new Currency { Name = "Malagasy ariary", Code = "MGA", Symbol = "Ar", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 147, SpacedSymbol = false },
                new Currency { Name = "Malawian kwacha", Code = "MWK", Symbol = "MK", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 148, SpacedSymbol = false },
                new Currency { Name = "Malaysian ringgit", Code = "MYR", Symbol = "RM", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 149, SpacedSymbol = false },
                new Currency { Name = "Maldivian rufiyaa", Code = "MVR", Symbol = ".ރ", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 150, SpacedSymbol = false },
                new Currency { Name = "Mauritanian ouguiya", Code = "MRU", Symbol = "UM", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 154, SpacedSymbol = false },
                new Currency { Name = "Mauritian rupee", Code = "MUR", Symbol = "₨", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 155, SpacedSymbol = false },
                new Currency { Name = "Mexican peso", Code = "MXN", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 156, SpacedSymbol = false },
                new Currency { Name = "Moldovan leu", Code = "MDL", Symbol = "L", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 158, SpacedSymbol = false },
                new Currency { Name = "Mongolian tögrög", Code = "MNT", Symbol = "₮", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 160, SpacedSymbol = false },
                new Currency { Name = "Moroccan dirham", Code = "MAD", Symbol = "د.م.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 163, SpacedSymbol = false },
                new Currency { Name = "Mozambican metical", Code = "MZN", Symbol = "MT", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 164, SpacedSymbol = false },
                new Currency { Name = "Burmese kyat", Code = "MMK", Symbol = "Ks", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 165, SpacedSymbol = false },

                // N
                new Currency { Name = "New Zealand dollar", Code = "NZD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 60, SpacedSymbol = false },
                new Currency { Name = "Namibian dollar", Code = "NAD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 166, SpacedSymbol = false },
                new Currency { Name = "Nepalese rupee", Code = "NPR", Symbol = "रू", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 169, SpacedSymbol = false },
                new Currency { Name = "Nicaraguan córdoba", Code = "NIO", Symbol = "C$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 173, SpacedSymbol = false },
                new Currency { Name = "Nigerian naira", Code = "NGN", Symbol = "₦", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 175, SpacedSymbol = false },
                new Currency { Name = "Norwegian krone", Code = "NOK", Symbol = "kr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 180, SpacedSymbol = false },

                // O
                new Currency { Name = "Omani rial", Code = "OMR", Symbol = "ر.ع.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 181, SpacedSymbol = false },

                // P
                new Currency { Name = "Pakistani rupee", Code = "PKR", Symbol = "₨", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 182, SpacedSymbol = false },
                new Currency { Name = "Panamanian balboa", Code = "PAB", Symbol = "B/.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 186, SpacedSymbol = false },
                new Currency { Name = "Papua New Guinean kina", Code = "PGK", Symbol = "K", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 188, SpacedSymbol = false },
                new Currency { Name = "Paraguayan guaraní", Code = "PYG", Symbol = "₲", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 189, SpacedSymbol = false },
                new Currency { Name = "Peruvian sol", Code = "PEN", Symbol = "S/.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 190, SpacedSymbol = false },
                new Currency { Name = "Philippine peso", Code = "PHP", Symbol = "₱", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 191, SpacedSymbol = false },
                new Currency { Name = "Pitcairn Islands dollar", Code = "PND", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 193, SpacedSymbol = false },
                new Currency { Name = "Polish złoty", Code = "PLN", Symbol = "zł", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 194, SpacedSymbol = false },
                new Currency { Name = "Transnistrian ruble", Code = "PRB", Symbol = "р.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 242, SpacedSymbol = false },

                // Q
                new Currency { Name = "Qatari riyal", Code = "QAR", Symbol = "ر.ق", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 196, SpacedSymbol = false },

                // R
                new Currency { Name = "Romanian leu", Code = "RON", Symbol = "lei", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 197, SpacedSymbol = false },
                new Currency { Name = "Rwandan franc", Code = "RWF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 199, SpacedSymbol = false },
                new Currency { Name = "Serbian dinar", Code = "RSD", Symbol = "din.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 214, SpacedSymbol = false },
                new Currency { Name = "Russian ruble", Code = "RUB", Symbol = "₽", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 2, SpacedSymbol = false },

                // S
                new Currency { Name = "Saint Helena pound", Code = "SHP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 18, SpacedSymbol = false },
                new Currency { Name = "Singapore dollar", Code = "SGD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 41, SpacedSymbol = false },
                new Currency { Name = "Swazi lilangeni", Code = "SZL", Symbol = "L", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 82, SpacedSymbol = false },
                new Currency { Name = "São Tomé and Príncipe dobra", Code = "STN", Symbol = "Db", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 211, SpacedSymbol = false },
                new Currency { Name = "Saudi riyal", Code = "SAR", Symbol = "﷼", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 212, SpacedSymbol = false },
                new Currency { Name = "Seychellois rupee", Code = "SCR", Symbol = "₨", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 215, SpacedSymbol = false },
                new Currency { Name = "Sierra Leonean leone", Code = "SLL", Symbol = "Le", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 216, SpacedSymbol = false },
                new Currency { Name = "Solomon Islands dollar", Code = "SBD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 223, SpacedSymbol = false },
                new Currency { Name = "Somali shilling", Code = "SOS", Symbol = "Sh", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 224, SpacedSymbol = false },
                new Currency { Name = "Somaliland shilling", Code = "SLS", Symbol = "Sl", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 225, SpacedSymbol = false },
                new Currency { Name = "South Sudanese pound", Code = "SSP", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 229, SpacedSymbol = false },
                new Currency { Name = "Sudanese pound", Code = "SDG", Symbol = "ج.س.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 231, SpacedSymbol = false },
                new Currency { Name = "Surinamese dollar", Code = "SRD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 232, SpacedSymbol = false },
                new Currency { Name = "Swedish krona", Code = "SEK", Symbol = "kr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 233, SpacedSymbol = false },
                new Currency { Name = "Syrian pound", Code = "SYP", Symbol = "£S", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 235, SpacedSymbol = false },

                // T
                new Currency { Name = "Turkish lira", Code = "TRY", Symbol = "₺", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 179, SpacedSymbol = false },
                new Currency { Name = "New Taiwan dollar", Code = "TWD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 236, SpacedSymbol = false },
                new Currency { Name = "Tajikistani somoni", Code = "TJS", Symbol = "с.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 237, SpacedSymbol = false },
                new Currency { Name = "Tanzanian shilling", Code = "TZS", Symbol = "Sh", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 238, SpacedSymbol = false },
                new Currency { Name = "Thai baht", Code = "THB", Symbol = "฿", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 239, SpacedSymbol = false },
                new Currency { Name = "Tongan paʻanga", Code = "TOP", Symbol = "T$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 241, SpacedSymbol = false },
                new Currency { Name = "Trinidad and Tobago dollar", Code = "TTD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 243, SpacedSymbol = false },
                new Currency { Name = "Tunisian dinar", Code = "TND", Symbol = "د.ت", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 244, SpacedSymbol = false },
                new Currency { Name = "Turkmenistan manat", Code = "TMT", Symbol = "m.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 246, SpacedSymbol = false },
                new Currency { Name = "Tuvaluan dollar", Code = "TVD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 248, SpacedSymbol = false },

                // U
                new Currency { Name = "United States dollar", Code = "USD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 34, SpacedSymbol = false },
                new Currency { Name = "Ugandan shilling", Code = "UGX", Symbol = "USh", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 250, SpacedSymbol = false },
                new Currency { Name = "Ukrainian hryvnia", Code = "UAH", Symbol = "₴", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 251, SpacedSymbol = false },
                new Currency { Name = "Uruguayan peso", Code = "UYU", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 255, SpacedSymbol = false },
                new Currency { Name = "Uzbekistani so'm", Code = "UZS", Symbol = "Sʻ", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 256, SpacedSymbol = false },

                // V
                new Currency { Name = "Vanuatu vatu", Code = "VUV", Symbol = "Vt", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 257, SpacedSymbol = false },
                new Currency { Name = "Venezuelan sovereign bolívar", Code = "VES", Symbol = "Bs.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 259, SpacedSymbol = false },
                new Currency { Name = "Venezuelan bolívar digital", Code = "VED", Symbol = "Bs.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 260, SpacedSymbol = false },
                new Currency { Name = "Vietnamese đồng", Code = "VND", Symbol = "₫", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 261, SpacedSymbol = false },

                // W
                new Currency { Name = "Samoan tālā", Code = "WST", Symbol = "T", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 209, SpacedSymbol = false },

                // X
                new Currency { Name = "Eastern Caribbean dollar", Code = "XCD", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 11, SpacedSymbol = false },
                new Currency { Name = "West African CFA franc", Code = "XOF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 29, SpacedSymbol = false },
                new Currency { Name = "Central African CFA franc", Code = "XAF", Symbol = "Fr", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 46, SpacedSymbol = false },
                new Currency { Name = "CFP franc", Code = "XPF", Symbol = "₣", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 91, SpacedSymbol = false },

                // Y
                new Currency { Name = "Yemeni rial", Code = "YER", Symbol = "﷼", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 263, SpacedSymbol = false },

                // Z
                new Currency { Name = "South African rand", Code = "ZAR", Symbol = "R", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 83, SpacedSymbol = false },
                new Currency { Name = "Zambian kwacha", Code = "ZMW", Symbol = "ZK", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 264, SpacedSymbol = false },
                new Currency { Name = "RTGS dollar", Code = "ZWB", Symbol = "RTGS$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 265, SpacedSymbol = false }

                // ?
                new Currency { Name = "Abkhazian apsar", Code = "???", Symbol = "?", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 1, SpacedSymbol = false },
                new Currency { Name = "Alderney pound", Code = "???", Symbol = "£", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 6, SpacedSymbol = false },
                new Currency { Name = "Artsakh dram", Code = "???", Symbol = "դր.", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 15, SpacedSymbol = false },
                new Currency { Name = "Niue dollar", Code = "???", Symbol = "$", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 177, SpacedSymbol = false },
                new Currency { Name = "Sahrawi peseta", Code = "???", Symbol = "Ptas", SymbolOrientation = CurrencySymbolOrientation.BeforeValue, Number = "0", Id = 204, SpacedSymbol = false },
            }
            builder.Entity<Currency>().HasData(currencies.OrderBy(c => c.Code));
        }
    }
}
