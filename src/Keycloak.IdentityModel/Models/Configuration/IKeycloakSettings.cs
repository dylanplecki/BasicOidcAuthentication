using System;

namespace Keycloak.IdentityModel.Models.Configuration
{
    public interface IKeycloakParameters
    {
        string AuthenticationType { get; }
        string KeycloakUrl { get; }
        string Realm { get; }
        string ClientId { get; }
        string ClientSecret { get; }
        string Scope { get; }
        string IdentityProvider { get; }
        string PostLogoutRedirectUrl { get; }
        bool DisableIssuerSigningKeyValidation { get; }
        bool AllowUnsignedTokens { get; }
        bool DisableIssuerValidation { get; }
        bool DisableAudienceValidation { get; }
        TimeSpan TokenClockSkew { get; }
        TimeSpan MetadataRefreshInterval { get; }
        string CallbackPath { get; }
        string ResponseType { get; }
        bool DisableRefreshTokenSignatureValidation { get; }
        bool DisableAllRefreshTokenValidation { get; }
        string AuthResponseErrorRedirectUrl { get; }
    }
}
