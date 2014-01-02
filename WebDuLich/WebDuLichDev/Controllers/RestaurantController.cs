using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Models;
using DuLichDLL.BAL;
using DuLichDLL.TOOLS;
using WebDuLichDev.WebUtility;
using System.IO;
using DuLichDLL.Model;
using WebDuLichDev.Enum;
using DuLichDLL.ExceptionType;


namespace WebDuLichDev.Controllers
{
    public class RestaurantController : Controller
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(RestaurantController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";

        //
        // GET: /Restaurant/
        private static List<RestaurantInfo> RestaunantBookTemp = new List<RestaurantInfo>();

        public ActionResult Index()
        {
            return View();
        }

        #region admin

        public ActionResult AddRestaurant()
        {

            return View();
        }

        public ActionResult ListRestaurant()
        {
            try
            {
                vm_Pagination pagination = new vm_Pagination
                {
                    Page = MvcApplication.pageDefault,
                    PageSize = MvcApplication.pageSizeDefault,
                    OrderBy = DL_PlaceColumns.CreatedDate.ToString(),
                    OrderDirection = "DESC",

                };
                long totalRecords = 0;

                DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
                var model = dlPlaceBAL.GetListWithFilter(0, "", "", (long)DL_PlaceTypeId.Restaurants, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

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

        [HttpPost]
        public ActionResult ListRestaurant(vm_Pagination pagination, vm_Search dataSearch)
        {
            try
            {
                long totalRecords = 0;

                DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
                var model = dlPlaceBAL.GetListWithFilter(0, "", "", (long)DL_PlaceTypeId.Restaurants, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

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

        [HttpPost]
        public ActionResult AddRestaurant(RestaurantInfo restaurantinfo, string[] imagePlace)
        {
            try
            {
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
                if (null != imagePlace)
                {
                    for (int index = 0; index < imagePlace.Count(); index++)
                    {
                        DL_ImagePlace temp = new DL_ImagePlace();
                        temp.LinkImage = imagePlace[index];
                        listdlImangePlace.Add(temp);
                    }
                }
                restaurantinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Restaurants;
                restaurantinfo.listImagePlace = listdlImangePlace;
                restaurantinfo.dlPlace.TotalPointRating = 0;
                restaurantinfo.dlPlace.TotalUserRating = 0;
                bool result = dlPlaceBal.InsertRestaurant(restaurantinfo.dlPlace, restaurantinfo.dlRestaurantInfoDetail, restaurantinfo.listImagePlace);
                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Insert;
                    return RedirectToAction("ListRestaurant");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Insert;
                    return RedirectToAction("ListRestaurant");
                }
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
        public ActionResult UpdateRestaurant(long ID)
        {
            try
            {
                RestaurantInfo restaurantinfo = new RestaurantInfo();
                DL_RestaurantInfoDetailBAL restaurantInfoBal = new DL_RestaurantInfoDetailBAL();
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
                restaurantinfo.dlRestaurantInfoDetail = restaurantInfoBal.GetByDLPlaceID(ID);
                restaurantinfo.dlPlace = dlPlaceBal.GetByID(ID);
                listdlImangePlace = dlImagePlaceBal.GetByDLPlaceID(ID);
                restaurantinfo.listImagePlace = listdlImangePlace;
                var model = restaurantinfo;

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
        [HttpPost]
        public ActionResult UpdateRestaurant(RestaurantInfo restaurantinfo, string[] imagePlace)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
                List<DL_ImagePlace> listdlImangePlaceTemp = new List<DL_ImagePlace>();
                List<DL_ImagePlace> listdlImangePlaceTempNew = new List<DL_ImagePlace>();
                DL_ImagePlaceBAL dlImageBal = new DL_ImagePlaceBAL();
                if (null != imagePlace)
                {
                    for (int index = 0; index < imagePlace.Count(); index++)
                    {
                        DL_ImagePlace temp = new DL_ImagePlace();
                        temp.LinkImage = imagePlace[index];
                        listdlImangePlaceTempNew.Add(temp);
                    }
                }
                //listdlImangePlace = dlImageBal.GetByDLPlaceID(restaurantinfo.dlPlace.ID);
                restaurantinfo.dlRestaurantInfoDetail.DL_PlaceId = restaurantinfo.dlPlace.ID;
                if (restaurantinfo.listImagePlace != null)
                {
                    foreach (var i in restaurantinfo.listImagePlace)
                    {
                        if (i.Status == 1)
                            dlImageBal.Update(i);
                        else
                        {
                            i.Status = 0;
                            dlImageBal.Update(i);
                        }
                    }
                }
                restaurantinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Restaurants;
                result = dlPlaceBal.UpdateRestaurant(restaurantinfo.dlPlace, restaurantinfo.dlRestaurantInfoDetail, listdlImangePlaceTempNew);
                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Update;
                    return RedirectToAction("ListRestaurant");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListRestaurant");
                }
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

        public ActionResult DelRestaurant(long ID)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                var status = 1;
                result = dlPlaceBal.UpdateStatusById(ID, status);

                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Update;
                    return RedirectToAction("ListRestaurant");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListRestaurant");
                }
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
        #endregion

        #region book flip

        public ActionResult RestaurantByCity(long ID)
        {
            try
            {
                ViewBag.CityId = ID;
                DL_CityBAL dlCityBal = new DL_CityBAL();
                var city = dlCityBal.GetByID(ID);
                ViewBag.Title = city.CityName;

                //vm_Pagination pagination = new vm_Pagination { OrderBy = DL_PlaceColumns.CreatedDate.ToString(), OrderDirection = "DESC" };
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_RestaurantInfoDetailBAL dlRestaurantInfoDetailBal = new DL_RestaurantInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                var dlRestaurantPlace = dlPlaceBal.GetListRestaurantsPlaceByCity(ID);
                //ViewData["OrderBy"] = pagination.OrderBy;
                //ViewData["OrderDirection"] = pagination.OrderDirection;
                var restaurantBook = new List<RestaurantInfo>();
                for (int index = 0; index < dlRestaurantPlace.Count(); index++)
                {
                    var tmp = new RestaurantInfo();
                    tmp.dlPlace = dlRestaurantPlace[index];
                    tmp.dlRestaurantInfoDetail = dlRestaurantInfoDetailBal.GetByDLPlaceID(dlRestaurantPlace[index].ID);
                    //tmp.listImageCity = dlImagePlaceBal.GetByDLPlaceID(dlRestaurantPlace[index].ID);
                    restaurantBook.Add(tmp);

                }
                RestaunantBookTemp = restaurantBook;
                return View(restaurantBook);
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult RestaurantInfoDetail(long placeId)
        {
            try
            {
                //DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetail = new DL_NicePlaceInfoDetailBAL();
                //var model = dlNicePlaceInfoDetail.GetByPlaceId(placeId);
                var model = new DL_RestaurantInfoDetail();
                for (int index = 0; index < RestaunantBookTemp.Count; index++)
                {
                    if (RestaunantBookTemp[index].dlRestaurantInfoDetail.DL_PlaceId == placeId)
                    {
                        model = RestaunantBookTemp[index].dlRestaurantInfoDetail;
                    }
                }
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

        #endregion

    }
}
