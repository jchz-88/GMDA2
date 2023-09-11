using System.Windows;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Desktop;
using Microsoft.Identity.Client.Broker;


namespace Listas
{
    public partial class App
    {
        static App()
        {
            CreateApplication(true, false);
        }

        public static void CreateApplication(bool useWam, bool useBrokerPreview)
        {
            var builder = PublicClientApplicationBuilder.Create(ClientId)
                .WithAuthority($"{Instance}{Tenant}")
                .WithDefaultRedirectUri();

            //Use of Broker Requires redirect URI "ms-appx-web://microsoft.aad.brokerplugin/{client_id}" in app registration
            if (useWam && !useBrokerPreview)
            {
                builder.WithBroker(true);
            }
            else if (useWam && useBrokerPreview)
            {
                builder.WithBroker(true);
            }
            _clientApp = builder.Build();
            TokenCache.EnableSerialization(_clientApp.UserTokenCache);
        }

        // Below are the clientId (Application Id) of your app registration and the tenant information. 
        // You have to replace:
        // - the content of ClientID with the Application Id for your app registration
        // - The content of Tenant by the information about the accounts allowed to sign-in in your application:
        //   - For Work or School account in your org, use your tenant ID, or domain
        //   - for any Work or School accounts, use organizations
        //   - for any Work or School accounts, or Microsoft personal account, use common
        //   - for Microsoft Personal account, use consumers
        //private static string ClientId = "4a1aa1d5-c567-49d0-ad0b-cd957a47f842";
        private static string ClientId = "f4d48061-d562-4af4-b0a6-8cb2c07a65ab";
       

        // Note: Tenant is important for the quickstart.
        private static string Tenant = "d3abd9d3-3514-4659-94b2-0e1458194215";
        private static string Instance = "https://login.microsoftonline.com/";
        private static IPublicClientApplication _clientApp;

        public static IPublicClientApplication PublicClientApp { get { return _clientApp; } }
    }
}
