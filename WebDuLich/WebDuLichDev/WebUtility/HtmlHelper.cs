using DuLichDLL.BAL;
using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebDuLichDev.WebUtility
{
    public class Helper
    {
        
        public static List<DL_ImagePlace> ExceptAB(List<DL_ImagePlace> A, List<DL_ImagePlace> B)
        {
            var R=A.Except(B).ToList();
            try
            {                
                return R;
               
            }
            catch (SystemException ex)
            {
                throw new SystemException(ex.Message);
            }
            
        }
        public static bool IsAdmin()
        {
            //if(System.Web.Mvc.AuthorizeAttribute. Roles=="admin"        
            webpages_UsersInRolesBAL userInRoleBal = new webpages_UsersInRolesBAL();
            return userInRoleBal.UserIsAdmin(WebDuLichSecurity.UserID);
        }
     

    }

    public static class DataHelpper
    {
        public static string PATH_IMAGE_CITY
        {
            get { return ConfigurationManager.AppSettings["PathImageCity"].ToString().Trim(); }
        }
        public static string PATH_IMAGE_PLACE
        {
            get { return ConfigurationManager.AppSettings["PathImagePlace"].ToString().Trim(); }
        }
        public static string PATH_AVATAR_CITY
        {
            get { return ConfigurationManager.AppSettings["PathAvatarCity"].ToString().Trim(); }
        }
        public static string PATH_AVATAR_PLACE
        {
            get { return ConfigurationManager.AppSettings["PathAvatarPlace"].ToString().Trim(); }
        } 
    }
        
}