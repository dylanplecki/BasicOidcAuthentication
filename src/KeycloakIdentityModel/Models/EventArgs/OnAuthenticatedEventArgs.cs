namespace KeycloakIdentityModel.Models.EventArgs
{
    public class OnAuthenticatedEventArgs: System.EventArgs
    {
        public string RedirectUri { get; set; }
    }
}
