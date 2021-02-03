using System;

namespace Keycloak.IdentityModel.Models.Configuration
{
    public class DefaultKeycloakParameters : IKeycloakParameters
    {
        /// <summary>
        ///     Unique authentication type identifier
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        ///     Defines the entire URL to the Keycloak instance
        /// </summary>
        /// <remarks>
        ///     - By default, keycloak is deployed to the /auth submodule
        ///     on the webserver, which must be included in this URL
        /// </remarks>
        public string KeycloakUrl { get; set; }

        /// <summary>
        ///     The Keycloak realm on which the client is located
        /// </summary>
        public string Realm { get; set; }

        /// <summary>
        ///     The client ID to use for the application
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     OPTIONAL: The client secret to use for the application
        /// </summary>
        /// <remarks>
        ///     - Not required for public clients
        ///     - Default: None
        /// </remarks>
        public string ClientSecret { get; set; }

        /// <summary>
        ///     OPTIONAL: The OpenID scopes to request when authenticating a user
        /// </summary>
        /// <remarks>
        ///     - All scopes should be space-delimited in a single string
        ///     - Default: "openid"
        /// </remarks>
        public string Scope { get; set; }

        /// <summary>
        ///     OPTIONAL: Choose a default identity provider to use for the application
        /// </summary>
        /// <remarks>
        ///     - The value here must be a valid IDP ID in the specified Keycloak realm
        ///     - Only this chosen IDP may be used with this application
        ///     - The Keycloak login page will not be shown when this option is non-empty
        ///     - Default: None
        /// </remarks>
        public string IdentityProvider { get; set; }

        /// <summary>
        ///     OPTIONAL: The absolute or relative URL for users to be redirected to after logout
        /// </summary>
        /// <remarks>
        ///     - Default: Application base URL
        /// </remarks>
        public string PostLogoutRedirectUrl { get; set; }

        /// <summary>
        ///     OPTIONAL.ADV: Whether to check for valid token signatures before accepting
        /// </summary>
        /// <remarks>
        ///     - If enabled, this will create a MASSIVE security hole
        ///     - Default: False
        /// </remarks>
        public bool DisableIssuerSigningKeyValidation { get; set; } = false;

        /// <summary>
        ///     OPTIONAL.ADV: Whether to allow the extension to accept unsigned tokens
        /// </summary>
        /// <remarks>
        ///     - If enabled, this will create a MASSIVE security hole
        ///     - Default: False
        /// </remarks>
        public bool AllowUnsignedTokens { get; set; } = false;

        /// <summary>
        ///     OPTIONAL.ADV: Whether to disable the validation of the issuer of any returned token
        /// </summary>
        /// <remarks>
        ///     - Default: False
        /// </remarks>
        public bool DisableIssuerValidation { get; set; } = false;

        /// <summary>
        ///     OPTIONAL.ADV: Whether to disable the validation of the audience (app) of any returned token
        /// </summary>
        /// <remarks>
        ///     - Default: False
        /// </remarks>
        public bool DisableAudienceValidation { get; set; } = false;

        /// <summary>
        ///     OPTIONAL.ADV: The maximum grace time span for expired tokens to be accepted
        /// </summary>
        /// <remarks>
        ///     - Default: 2 seconds
        /// </remarks>
        public TimeSpan TokenClockSkew { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        ///     OPTIONAL.ADV: Whether to enable token validation via the Keycloak server
        /// </summary>
        /// <remarks>
        ///     - Enabling this option will require an HTTP call to the Keycloak server
        ///     on every request with a bearer token, or when new tokens are requested
        ///     - Enabling this option will also allow changes on the Keycloak server to
        ///     be seen by the end user immediately, ie. assigning a new role to a user
        ///     - Default: false
        /// </remarks>
        public bool UseRemoteTokenValidation { get; set; } = false;

        /// <summary>
        ///     OPTIONAL.ADV: The time interval for the OIDC metadata to refresh
        /// </summary>
        /// <remarks>
        ///     - User TimeSpace.MaxValue for no refreshing, and TimeSpace.Zero to always refresh
        ///     - Default: 60 minutes
        /// </remarks>
        public TimeSpan MetadataRefreshInterval { get; set; } = TimeSpan.FromMinutes(60);

        public string CallbackPath { get; set; }
        public string ResponseType { get; set; }

        /// <summary>
        ///     OPTIONAL.ADV: Disable signature validation of Refresh tokens.
        /// </summary>
        /// <remarks>
        ///     - In Keycloak server v4.5, it was decided to change encryption algorithm of Refresh tokens from RS256 to HS256.
        ///       Ref: https://issues.jboss.org/browse/KEYCLOAK-4622
        ///       This lead to an issue with this library that validates both Access and Refresh tokens with RS256.
        ///       Setting this option to true will disable validation of Refresh token (but keep validation for Access token).
        ///       As the application should not use the contents of the Refresh tokens, only send it back to the Keycloak server (which will validate it), it should be safe to disable it.
        ///     - Default: false
        /// </remarks>
        public bool DisableRefreshTokenSignatureValidation { get; set; } = false;

        /// <summary>
        ///     OPTIONAL.ADV: Disable all validation of Refresh tokens.
        /// </summary>
        /// <remarks>
        ///     - In Keycloak server somewhere between v4.6-4.8, it was decided that the contents of the "aud" claim in Refresh tokens to contain the Keycloak Realm URL instead of the Keycloak ClientId.
        ///       This lead to an issue with this library that validates the "aud" claim in Refresh tokens to contain the ClientId.
        ///       Setting this option to true will disable ALL validation of Refresh token (but keep validation for ID/Access token).
        ///       As the application should not use the contents of the Refresh tokens, only send it back to the Keycloak server (which will validate it), it should be safe to disable it.
        ///       This option overrides and can be used instead of DisableRefreshTokenSignatureValidation.
        ///     - Default: false
        /// </remarks>
        public bool DisableAllRefreshTokenValidation { get; set; }

        /// <summary>
        ///     OPTIONAL: The absolute or relative URL for users to be redirected to if the authorization response from Keycloak indicated unsuccessful authorization (query parameter "error")
        /// </summary>
        /// <remarks>
        ///     - Default: If not specified, an exception will be thrown if and error from Keycloak authentication is received.
        /// </remarks>
        public string AuthResponseErrorRedirectUrl { get; set; }

    }
}
