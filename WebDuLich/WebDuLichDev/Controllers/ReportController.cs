using DuLichDLL.BAL;
using DuLichDLL.ExceptionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Enum;
using WebDuLichDev.Models;
using DuLichDLL.Model;
using WebDuLichDev.WebUtility;
using WebDuLichDev.Filters;

namespace WebDuLichDev.Controllers
{
    public class ReportController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ReportController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";

        //[Permission("Report", "View")]
        public ActionResult ListSpam()
        {
            try
            {
                vm_Pagination pagination = new vm_Pagination
                {
                    Page = MvcApplication.pageDefault,
                    PageSize = MvcApplication.pageSizeDefault,
                    OrderBy = DL_SPAMREPORTColumns.NumberReport.ToString(),
                    OrderDirection = "DESC",

                };
                long totalRecords = 0;

                DL_SPAMREPORTBAL dl_SpamReportBal = new DL_SPAMREPORTBAL();
                var model = dl_SpamReportBal.GetListWithGroupByPlace(pagination.Page.Value , pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
                common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
                ViewData["OrderBy"] = pagination.OrderBy;
                ViewData["OrderDirection"] = pagination.OrderDirection;
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
        [Authorize]
        [HttpPost]
        public ActionResult ListSpam(long[] listPlaceIdSkip, long[] listPlaceIdAccept, vm_Pagination pagination)
        {
            try
            {

                DL_SPAMREPORTBAL dlSpamReportBal = new DL_SPAMREPORTBAL();
                if(null != listPlaceIdAccept || null != listPlaceIdSkip)
                    dlSpamReportBal.ProcessingReportSpam(listPlaceIdAccept, listPlaceIdSkip);

                long totalRecords = 0;

                DL_SPAMREPORTBAL dl_SpamReportBal = new DL_SPAMREPORTBAL();
                var model = dl_SpamReportBal.GetListWithGroupByPlace(pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, "DESC", out totalRecords);
                common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
                ViewData["OrderBy"] = pagination.OrderBy;
                ViewData["OrderDirection"] = pagination.OrderDirection;
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

    }
}
