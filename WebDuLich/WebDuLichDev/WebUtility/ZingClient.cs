using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using zingme_sdk;

namespace WebDuLichDev.WebUtility
{
    public class ZingClient : IAuthenticationClient
    {
        public static string code;

        //public string Code
        //{
        //    get { return _code; }
        //    set { _code = value; }
        //}
        public static string access_token;

        //public string Access_token
        //{
        //    get { return _access_token; }
        //    set { _access_token = value; }
        //}
        private string _clientId;

        //public string ClientId
        //{
        //    get { return _clientId; }
        //    set { _clientId = value; }
        //}
        private string _clientSecret;

        //public string ClientSecret
        //{
        //    get { return _clientSecret; }
        //    set { _clientSecret = value; }
        //}
        private string _scope;

        //public string Scope
        //{
        //    get { return _scope; }
        //    set { _scope = value; }
        //}
        private string _providerName = "ZingMe";

        public string ProviderName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }


        public void RequestAuthentication(HttpContextBase context, Uri returnUrl)
        {
            //string url = HttpUtility.UrlEncode(returnUrl.ToString());
            var random = new Random();
            long number_ran = random.Next(1, 100000);
            string state = number_ran.ToString();
            ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
            string url_old = "http://localhost:62688";
            Uri uri_old = new Uri(url_old);

            string uri_new = uri_old.ToString();
            String url = oauth.getAuthorizedUrl(uri_new, "14103");

            context.Response.Redirect(url);
        }

        public AuthenticationResult VerifyAuthentication(HttpContextBase context)
        {
            code = context.Request.QueryString["code"];
            string signedRequestParam = context.Request.Params["signed_request"];
            //NameValueCollection pColl = context.Request.Params;
            //pColl.GetValue("signed_request");
            //pColl.GetKey(10);
            int expires = 0;

            ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
            access_token = oauth.getAccessTokenFromCode(code, out expires);
            ZME_Me me = new ZME_Me(WebDuLichDev.RegisterAuthZing.config());
            string id = "id";
            string username = "username";
            string gender = "gender";
            string dob = "dob";
            var user_data_id = me.getInfo(access_token, id);
            var user_data_username = me.getInfo(access_token, username);
            string rawUrl = context.Request.Url.ToString();

            string id_data = (string)user_data_id[id];
            string username_data = (string)user_data_username[username];
            if (id_data == null)
                return new AuthenticationResult(false, ProviderName, null, null, null);


            AuthenticationResult result = new AuthenticationResult(true, ProviderName, id_data, username_data, null);
            return result;
        }

        public ZingClient(string clientId, string clientSecret, string scope)
        {
            this._clientId = clientId;
            this._clientSecret = clientSecret;
            this._scope = scope;
        }

    }
}