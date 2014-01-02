using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;
using DuLichDLL.Utility;
using WebMatrix.WebData;
using System.Threading;
using System.Web.SessionState;
using System.Globalization;

namespace WebDuLichDev.WebUtility
{
    public class WebDuLichData
    {
        public static List<SelectListItem> ListCity
        {
            get
            {
                DL_CityBAL dlCityBal = new DL_CityBAL();
                List<SelectListItem> listCity = new List<SelectListItem>();

                listCity.Add(new SelectListItem { Text = Resources.Language.ChooseCity + "...", Value = "-1" });

                var dlCity = dlCityBal.GetList();

                foreach (var item in dlCity)
                {
                    listCity.Add(new SelectListItem
                    {
                        Text = item.CityName,
                        Value = item.ID.ToString(),
                    });
                }
                return listCity;
            }
        }

        public static string PathAvatarDefault
        {
            get
            {
                string pathAvatarDefault;
                M_SystemSetting_Config mSystemSetting = new M_SystemSetting_Config();
                M_SystemSettingBAL mSystemSettingBal = new M_SystemSettingBAL();

                mSystemSetting = mSystemSettingBal.GetSystemSetting();
                pathAvatarDefault = mSystemSetting.AVATAR_DEFAULT;

                return pathAvatarDefault;
            }

        }

        //private void SetPath()
        //{
        //    M_SystemSetting_Config mSystemSetting = new M_SystemSetting_Config();
        //    M_SystemSettingBAL mSystemSettingBal = new M_SystemSettingBAL();

        //    mSystemSetting = mSystemSettingBal.GetSystemSetting();
        //    pathAvatarCity = mSystemSetting.PATH_AVATAR_CITY;
        //    pathImageCity = mSystemSetting.PATH_IMAGE_CITY;
        //} 
        public static List<SelectListItem> ListRole
        {
            get
            {
                webpages_RolesBAL roleBal = new webpages_RolesBAL();
                List<SelectListItem> listrole = new List<SelectListItem>();

                listrole.Add(new SelectListItem { Text = "...", Value = "-1" });

                var role = roleBal.GetList();

                foreach (var item in role)
                {
                    listrole.Add(new SelectListItem
                    {
                        Text = item.RoleName,
                        Value = item.RoleId.ToString(),
                    });
                }
                return listrole;
            }
        }
    }

    public class WebDuLichSecurity
    {
        private static string _userId = "UserId";
        private static string _userName = "UserName";
        private static string _menu = "Menu";
        private static string _languageCode = "LanguageCode";
        public static bool UserIsAdmin = false;

        private static string _accessTokenZingMe = "";
        
        public static string AccessTokenZingMe
        {
            get { return Utility.ObjectToString(HttpContext.Current.Session[_accessTokenZingMe]); }
            set
            {
                HttpContext.Current.Session[_accessTokenZingMe] = value;
            }
        }

        public static long UserID
        {
            get
            {
                long userId = Utility.ObjectToLong(HttpContext.Current.Session[_userId]);
                return userId;
            }
        }

        public static string UserName
        {
            get
            {
                string userName = Utility.ObjectToString(HttpContext.Current.Session[_userName]);
                return userName;
            }
        }
        //Get main menu
        public static string Menu
        {
            get
            {
                return Utility.ObjectToString(HttpContext.Current.Session[_menu]);
            }
            set
            {
                HttpContext.Current.Session[_menu] = value;
            }
        }

        public static bool Login(string userName, string passWord, bool rememberme)
        {
            if (WebSecurity.Login(userName, passWord, rememberme))
            {
                UserProfileBAL useprofileBal = new UserProfileBAL();
                var userProfile = useprofileBal.GetByUserName(userName);
                HttpContext.Current.Session[_userId] = userProfile.UserId;
                HttpContext.Current.Session[_userName] = userName;
                return true;//return RedirectToLocal(returnUrl);
            }
            else
                return false;
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public static string LanguageCode
        {
            get
            {
                return string.IsNullOrWhiteSpace(Utility.ObjectToString(HttpContext.Current.Session[_languageCode])) ? "vi-VN" : Utility.ObjectToString(HttpContext.Current.Session[_languageCode]);
            }
            set
            {
                HttpContext.Current.Session[_languageCode] = value;
            }
        }
    }

    public class SessionManager
    {
        protected HttpSessionState session;

        public SessionManager(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }

        public static string LanguageCode
        {
            get
            {

                return Thread.CurrentThread.CurrentUICulture.Name;
            }
            set
            {
                //
                // Set the thread's CurrentUICulture.
                //
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(value);
                //
                // Set the thread's CurrentCulture the same as CurrentUICulture.
                //
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }

        }
    }

}
