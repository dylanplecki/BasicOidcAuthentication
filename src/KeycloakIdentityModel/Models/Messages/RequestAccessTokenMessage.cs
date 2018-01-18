using System;
using System.Threading.Tasks;
using KeycloakIdentityModel.Models.Configuration;
using KeycloakIdentityModel.Models.Responses;
using KeycloakIdentityModel.Utilities;
using Microsoft.Owin;

namespace KeycloakIdentityModel.Models.Messages
{
    public class RequestAccessTokenMessage : GenericMessage<TokenResponse>
    {
        public RequestAccessTokenMessage(IOwinContext context, Uri baseUri, IKeycloakParameters options,
            AuthorizationResponse authResponse)
            : base(options)
        {
            if (baseUri == null) throw new ArgumentNullException(nameof(baseUri));
            if (authResponse == null) throw new ArgumentNullException(nameof(authResponse));

            BaseUri = baseUri;
            AuthResponse = authResponse;
            Context = context;
        }

        protected Uri BaseUri { get; }
        private AuthorizationResponse AuthResponse { get; }
        private IOwinContext Context { get; }

        public override async Task<TokenResponse> ExecuteAsync()
        {
            return new TokenResponse(await ExecuteHttpRequestAsync());
        }

        private async Task<string> ExecuteHttpRequestAsync()
        {
            var uriManager = await OidcDataManager.GetCachedContextAsync(Context, Options);
            var response = await SendHttpPostRequest(uriManager.GetTokenEndpoint(),
                uriManager.BuildAccessTokenEndpointContent(BaseUri, AuthResponse.Code));
            return await response.Content.ReadAsStringAsync();
        }
    }
}