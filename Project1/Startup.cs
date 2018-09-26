using Microsoft.Owin;
using Owin;
using IdentityModel.Client;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;

[assembly: OwinStartup(typeof(Project1.Startup))]
namespace Project1
{
    public partial class Startup
    {

        private readonly string _clientId = ConfigurationManager.AppSettings["0oa1u814o8RIjG4Ye356"];
        private readonly string _redirectUri = ConfigurationManager.AppSettings["http://https://missiongit.azurewebsites.net/authorization-code/callback"];
        private readonly string _authority = ConfigurationManager.AppSettings["https://deloittejairo.okta.com/oauth2/default"];
        private readonly string _clientSecret = ConfigurationManager.AppSettings["7RGwSFTBz8NgoFdCBJIyn0EAjNL23skSoWPKKWbz"];

        /*public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }*/

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Authority = _authority,
                RedirectUri = _redirectUri,
                ResponseType = OpenIdConnectResponseType.CodeIdToken,
                Scope = OpenIdConnectScope.OpenIdProfile,
                TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name" },
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthorizationCodeReceived = async n =>
                    {
                        // Exchange code for access and ID tokens
                        var tokenClient = new TokenClient($"{_authority}/v1/token", _clientId, _clientSecret);

                        var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(n.Code, _redirectUri);
                        if (tokenResponse.IsError)
                        {
                            throw new Exception(tokenResponse.Error);
                        }

                        var userInfoClient = new UserInfoClient($"{_authority}/v1/userinfo");
                        var userInfoResponse = await userInfoClient.GetAsync(tokenResponse.AccessToken);

                        var claims = new List<Claim>(userInfoResponse.Claims)
          {
            new Claim("id_token", tokenResponse.IdentityToken),
            new Claim("access_token", tokenResponse.AccessToken)
          };

                        n.AuthenticationTicket.Identity.AddClaims(claims);
                    },
                },
            });
        }
    }
}
