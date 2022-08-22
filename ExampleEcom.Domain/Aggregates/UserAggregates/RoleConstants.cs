namespace ExampleEcom.Domain.Aggregates.UserAggregates
{
    public class RoleConstants
    {
        public static readonly int SYSTEM_ADMIN_ROLE_ID = 1;
        public static readonly string SYSTEM_ADMIN_ROLE_NAME = "SystemAdmin";
        public static readonly string SYSTEM_ADMIN_ROLE_NAME_NORMALIZED = SYSTEM_ADMIN_ROLE_NAME.ToUpper();
        public static readonly int SITE_ADMIN_ROLE_ID = 2;
        public static readonly string SITE_ADMIN_ROLE_NAME = "SiteAdmin";
        public static readonly string SITE_ADMIN_ROLE_NAME_NORMALIZED = SITE_ADMIN_ROLE_NAME.ToUpper();
        public static readonly int SITE_USER_ROLE_ID = 3;
        public static readonly string SITE_USER_ROLE_NAME = "SiteUser";
        public static readonly string SITE_USER_ROLE_NAME_NORMALIZED = SITE_USER_ROLE_NAME.ToUpper();
    }
}
