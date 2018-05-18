
namespace NilamHutAPI.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }

            public static class UserRoles
            {
                public const string Administrator = "Administrator", SimpleUser = "SimpleUser";
            }
        }
    }
}
