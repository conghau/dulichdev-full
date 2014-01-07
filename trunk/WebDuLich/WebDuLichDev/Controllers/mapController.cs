using DuLichDLL.ExceptionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Enum;
using WebDuLichDev.Models;
using WebDuLichDev.WebUtility;

namespace WebDuLichDev.Controllers
{
    public class mapController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(mapController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Map(string co_ordinate, string address)
        {
            try
            {
                vm_map model = new vm_map();
                if (!string.IsNullOrEmpty(co_ordinate))
                {
                    co_ordinate = co_ordinate.Trim();
                    model.latitude = co_ordinate.Split(',')[0] ?? "";
                    model.longitude = co_ordinate.Split(',')[1] ?? "";
                }
                model.address = address ?? "";
                ViewBag.address = address ?? "";
                return View(model);
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult DirectionGetLatLong()
        {
            return View();
        }
    }
}
