using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.WebUtility;
using zingme_sdk;

namespace WebDuLichDev.Controllers
{

    public class ZingController : BaseController
    {
        public ActionResult Invite()
        {
            ZME_Config zme_config = RegisterAuthZing.config();

            ZME_Social zmeSocial = new ZME_Social(zme_config);
            // zmeSocial.invite();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult PostNoticeRate(int rate, string placeName, long ID)
        {
            if (null == WebDuLichSecurity.AccessTokenZingMe)
                return Json(new { result = false });

            string hostname = ConfigurationManager.AppSettings["Path"].ToString();

            ZME_Config zme_config = RegisterAuthZing.config();
            ZME_Me zmeMe = new ZME_Me(zme_config);
            Hashtable me_info = zmeMe.getInfo(WebDuLichSecurity.AccessTokenZingMe, "id,username");
            ZME_Social zmeSocial = new ZME_Social(zme_config);
            string username = me_info["username"].ToString();
            //string rate= rate.ToString();
            string title = username + " vừa đánh giá cho " + placeName + " được " + rate.ToString() + " điểm trên tổng số 20";
            ZME_Feed zmeFeed = new ZME_Feed(placeName, title, "dia diem", hostname +"Data/Avatar/Place/images.jpg", hostname+"place/niceplace/"+ID, hostname);
            zmeSocial.post(WebDuLichSecurity.AccessTokenZingMe, zmeFeed, false);
            return Json(new { result = true});
        }
    }
    
    
}
