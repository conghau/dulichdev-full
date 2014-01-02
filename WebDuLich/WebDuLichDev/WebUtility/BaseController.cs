using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuLichDev.WebUtility
{
    public class BaseController : Controller
    {
        #region Log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BaseController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";
        #endregion

        protected override void ExecuteCore()
        {
            try
            {
                string culture = string.Empty;
                if (string.IsNullOrWhiteSpace(WebDuLichSecurity.LanguageCode))
                {
                    WebDuLichSecurity.LanguageCode = "vi-VN";
                }
                else
                {
                    culture = WebDuLichSecurity.LanguageCode;
                }
                //
                SessionManager.LanguageCode = culture;
                //
                // Invokes the action in the current controller context.
                //
                base.ExecuteCore();
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Error", "Home");
                log.Error(ex.Message);
                Response.Redirect("~/home/error", false);
            }

        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}
