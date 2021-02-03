# Keycloak OWIN Authentication [![Build status](https://ci.appveyor.com/api/projects/status/xf1kvor22ya99h6w?svg=true)](https://ci.appveyor.com/project/DylanPlecki/keycloakowinauthentication)
###### Owin.Security.Keycloak - OWIN Authentication Middleware for C# Applications
----------------------------------------------------------------------------------

From [Keycloak's Website](http://keycloak.jboss.org/):
> Keycloak is an integrated SSO and IDM for browser apps and RESTful web services, built on top of OAuth 2.0, OpenID Connect, JSON Web Tokens (JWT) and SAML 2.0 specifications.
Keycloak has tight integration with a variety of platforms and has an HTTP security proxy service where we don't have tight integration.

This project is an unofficial Keycloak connector for C#. It is designed as an OWIN authentication middleware component, and can import user data,
including roles and authorization information, into the OWIN pipeline for use in ASP.NET, WPF, and any other C# application.

## Documentation

I am in the process of updating the documentation and samples. Older documentation on `Owin.Security.Keycloak` and `KeycloakIdentityModel` can be found on Dylan Plecki's [GitHub Wiki Page](https://github.com/dylanplecki/KeycloakOwinAuthentication/wiki).

## NuGet Packages

Dylan Plecki's project had two NuGet packages, one for each assembly. I have included the Keycloak.IdentityModel assembly in the Owin.Security.Keycloak-3 package so there is no longer a dependency on the KeycloakIdentityModel package.

For ASP.NET and OWIN functionality:
- `Owin.Security.Keycloak-3` ([link](https://www.nuget.org/packages/Owin.Security.Keycloak-3/))

Required NuGet package(s) for hosting on ASP.NET / IIS:
- `Microsoft.Owin.Host.SystemWeb` ([link](https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb))

Recommended NuGet package(s) for hosting on ASP.NET / IIS:
- `Microsoft.Owin.Security.Cookies` ([link](https://www.nuget.org/packages/Microsoft.Owin.Security.Cookies))

## Issues & Requests

Issues, feature requests, and technical help can be found at the project's [issue tracker](https://github.com/mattmorg55/Owin.Security.Keycloak/issues) on GitHub.
