using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
//using WebDuLichDev.Models;
using zingme_sdk;
using DotNetOpenAuth.AspNet.Clients;
using WebDuLichDev.Controllers;
using System.Configuration;
using WebDuLichDev.WebUtility;
using WebMatrix.WebData;
namespace WebDuLichDev
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            
            OAuthWebSecurity.RegisterFacebookClient(
               appId: "1381367088774409",
                appSecret: "10f578446278c7d75dfa178942124932");

            //OAuthWebSecurity.RegisterGoogleClient();
             
            //Zing Me SDK Config App ID  
            ZingClient zingClient = new ZingClient("663270de6faf4149ac73cb5e77374924", "ac2105d2856646e4b70b24db66b53f29", null);
            OAuthWebSecurity.RegisterClient(zingClient,"ZingMe",null);
            //OAuthWebSecurity.RegisterClient(
            //    new ZingClient("663270de6faf4149ac73cb5e77374924", "ac2105d2856646e4b70b24db66b53f29", null), "ZingMe", null);     
        }
    }

    public static class RegisterAuthZing
        {
            private static ZME_Environment env = ZME_Environment.DEVELOPMENT;
            private static string appname = "dulich";
            private static string apikey = "663270de6faf4149ac73cb5e77374924";
            private static string secretkey = "ac2105d2856646e4b70b24db66b53f29";
            
            public static ZME_Config config()
            {
                ZME_Config config1 = new ZME_Config(appname, apikey, secretkey, env);
                return config1;
            }
        }
}
