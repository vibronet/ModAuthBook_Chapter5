using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace WebAppChapter5
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
            new OpenIdConnectAuthenticationOptions
            {
                ClientId = "95dcbcfd-5a64-4efe-a5e3-f4ed2043c46c",
                Authority = "https://login.microsoftonline.com/DeveloperTenant.onmicrosoft.com",
                PostLogoutRedirectUri = "https://localhost:44300/"
            }
            );
            // If you want to connect to ADFS (from ADFS 2.x onward) instead of Azure AD:
            // 1- comment out the call to UseOpenIdConnectAuthentication
            // 2- uncomment the call to UseWsFederationAuthentication below
            // 3- assign to Wtrealm and MetadataAddress the values provisioned for your app
            // 4- go to AccountController and follow the suggestions in the comments there
            // please refer to Chapter 5 of http://amzn.to/1QS5kQK for more details.

            //app.UseWsFederationAuthentication(
            //new WsFederationAuthenticationOptions
            //{
            //    Wtrealm = "http://myapp/whatever",
            //    MetadataAddress =
            //"https://sts.contoso.com/federationmetadata/2007-06/federationmetadata.xml"
            //}

        }
    }
}