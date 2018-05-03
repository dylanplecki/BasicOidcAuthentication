using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using KeycloakIdentityModel.Extensions;
using Newtonsoft.Json.Linq;

namespace KeycloakIdentityModel.Utilities.ClaimMapping
{
    public static class ClaimMappings
    {
        private static readonly List<ClaimLookup> AccessTokenMappingList = new List<ClaimLookup>
        {
            new ClaimLookup
            {
                ClaimName = Constants.ClaimTypes.Audience,
                JSelectQuery = "aud"
            },
            new ClaimLookup
            {
                ClaimName = Constants.ClaimTypes.Issuer,
                JSelectQuery = "iss"
            },
            new ClaimLookup
            {
                ClaimName = Constants.ClaimTypes.IssuedAt,
                JSelectQuery = "iat",
                Transformation =
                    token => ((token.Value<double?>() ?? 1) - 1).ToDateTime().ToString(CultureInfo.InvariantCulture)
            },
            new ClaimLookup
            {
                ClaimName = Constants.ClaimTypes.AccessTokenExpiration,
                JSelectQuery = "exp",
                Transformation =
                    token => ((token.Value<double?>() ?? 1) - 1).ToDateTime().ToString(CultureInfo.InvariantCulture)
            },
            new ClaimLookup
            {
                ClaimName = Constants.ClaimTypes.SubjectId,
                JSelectQuery = "sub"
            },
            new ClaimLookup
            {
                ClaimName = ClaimTypes.Name,
                JSelectQuery = "preferred_username"
            },
            new ClaimLookup
            {
                ClaimName = ClaimTypes.GivenName,
                JSelectQuery = "given_name"
            },
            new ClaimLookup
            {
                ClaimName = ClaimTypes.Surname,
                JSelectQuery = "family_name"
            },
            new ClaimLookup
            {
                ClaimName = ClaimTypes.Email,
                JSelectQuery = "email"
            },
            new ClaimLookup
            {
                ClaimName = ClaimTypes.Role,
                JSelectQuery = "resource_access.{gid}.roles"
            }
        };

        internal static IEnumerable<ClaimLookup> AccessTokenMappings { get; } = AccessTokenMappingList;

        internal static IEnumerable<ClaimLookup> IdTokenMappings { get; } = new List<ClaimLookup>();

        internal static IEnumerable<ClaimLookup> RefreshTokenMappings { get; } = new List<ClaimLookup>
        {
            new ClaimLookup
            {
                ClaimName = Constants.ClaimTypes.RefreshTokenExpiration,
                JSelectQuery = "exp",
                Transformation =
                    token => ((token.Value<double?>() ?? 1) - 1).ToDateTime().ToString(CultureInfo.InvariantCulture)
            }
        };

        public static void AddAccessTokenMappings(string claimName, string jSelectQuery)
        {
            AccessTokenMappingList.Add(new ClaimLookup { ClaimName = claimName, JSelectQuery = jSelectQuery });
        }
    }
}
