using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class webpages_OAuthMembership
    {
        private string _provider;
        public string Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        private string _providerUserId;
        public string ProviderUserId
        {
            get { return _providerUserId; }
            set { _providerUserId = value; }
        }
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
    public enum webpages_OAuthMembershipColumns
    {
        Provider,
        ProviderUserId,
        UserId,
    }
    public enum webpages_OAuthMembershipProcedure
    {
        p_webpages_OAuthMembership_Insert,
        p_webpages_OAuthMembership_Delete,
        p_webpages_OAuthMembership_Update,
        p_webpages_OAuthMembership_Get_List,
        p_webpages_OAuthMembership_Get_ByID,

    }
}