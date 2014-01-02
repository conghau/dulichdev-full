using DuLichDLL.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.Model;
using DuLichDLL.TOOLS;
using WebDuLichDev.Models;
using WebDuLichDev.WebUtility;

namespace WebDuLichDev.Controllers
{
    public class SystemManagerController : BaseController
    {
        //
        // GET: /SystemManager/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CityManager()
        {

            vm_Pagination pagination = new vm_Pagination
            {
                Page = MvcApplication.pageDefault,
                PageSize = MvcApplication.pageSizeDefault,
                OrderBy = DL_CityColumns.ID.ToString(), // Thi de tam theo thu tu thoi, it bua dat ten ngon lanh thi theo ten
                OrderDirection = "ASC",

            };
            long totalRecords = 0;

            DL_CityBAL dlCityBAL = new DL_CityBAL();
            var model = dlCityBAL.GetListWithFilter("", "", pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }


        [HttpPost]
        public ActionResult CityManager(vm_Pagination pagination, string city_search)
        {

            long totalRecords = 0;

            DL_CityBAL dlCityBAL = new DL_CityBAL();
            var model = dlCityBAL.GetListWithFilter("", city_search, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }

    }
}
