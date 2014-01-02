using DuLichDLL.Model;
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
using DuLichDLL.ExceptionType;
using WebDuLichDev.Enum;


namespace WebDuLichDev.Controllers
{
    public class HotelController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(HotelController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";

        private static List<HotelInfo> HotelBookTemp = new List<HotelInfo>();
        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            return View();
        }
        #region admin

        public ActionResult ListHotel()
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
                var model = dlPlaceBAL.GetListWithFilter(0, "", "", (long)DL_PlaceTypeId.Hotels, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

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
        public ActionResult ListHotel(vm_Pagination pagination, vm_Search dataSearch)
        {
            try
            {
                long totalRecords = 0;

                DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
                var model = dlPlaceBAL.GetListWithFilter(0, "", "", (long)DL_PlaceTypeId.Hotels, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

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
        public ActionResult AddHotel()
        {
            //ViewBag.NewPlaceID = ID;
            return View();
        }

        [HttpPost]
        public ActionResult AddHotel(HotelInfo hotelinfo, string[] imagePlace)
        {
            try
            {
                bool result = false;
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
                hotelinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Hotels;
                hotelinfo.listImagePlace = listdlImangePlace;
                hotelinfo.dlPlace.TotalPointRating = 0;
                hotelinfo.dlPlace.TotalUserRating = 0;
                result=dlPlaceBal.InsertHotel(hotelinfo.dlPlace, hotelinfo.dlHotelPlaceInfoDetail, hotelinfo.listImagePlace);
                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Insert;
                    return RedirectToAction("ListHotel");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Insert;
                    return RedirectToAction("ListHotel");
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
        public ActionResult UpdateHotel(long ID)
        {
            try
            {
                HotelInfo hotelinfo = new HotelInfo();
                DL_HotelPlaceInfoDetailBAL hotelInfoBal = new DL_HotelPlaceInfoDetailBAL();
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
                hotelinfo.dlHotelPlaceInfoDetail = hotelInfoBal.GetByDLPlaceID(ID);
                hotelinfo.dlPlace = dlPlaceBal.GetByID(ID);
                listdlImangePlace = dlImagePlaceBal.GetByDLPlaceID(ID);
                hotelinfo.listImagePlace = listdlImangePlace;
                var model = hotelinfo;
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
        public ActionResult UpdateHotel(HotelInfo hotelinfo, string[] imagePlace)
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
                //listdlImangePlace = dlImageBal.GetByDLPlaceID(hotelinfo.dlPlace.ID);
                if (hotelinfo.listImagePlace != null)
                {
                    foreach (var i in hotelinfo.listImagePlace)
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
                hotelinfo.dlHotelPlaceInfoDetail.DL_PlaceId = hotelinfo.dlPlace.ID;
                hotelinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Hotels;
                result = dlPlaceBal.UpdateHotel(hotelinfo.dlPlace, hotelinfo.dlHotelPlaceInfoDetail, listdlImangePlaceTempNew);
                if (true == result)
                {
                    log.Info("Update Hotel Sucess");
                    TempData["Message"] = ResultMessage.SUC_Update;
                    return RedirectToAction("ListHotel");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListHotel");
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
        
        public ActionResult DelHotel(long ID)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                var status=1;
                result=dlPlaceBal.UpdateStatusById(ID, status);
               
                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Update;
                    return RedirectToAction("ListHotel");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListHotel");
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
        public ActionResult HotelByCity(long ID)
        {
            try
            {
                ViewBag.CityId = ID;
                DL_CityBAL dlCityBal = new DL_CityBAL();
                var city = dlCityBal.GetByID(ID);
                ViewBag.Title = city.CityName;

                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_HotelPlaceInfoDetailBAL dlHotelDetailBal = new DL_HotelPlaceInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                var dlHotelPlace = dlPlaceBal.GetListHotelByCity(ID);
                var HotelBook = new List<HotelInfo>();
                for (int index = 0; index < dlHotelPlace.Count(); index++)
                {
                    var tmp = new HotelInfo();
                    tmp.dlPlace = dlHotelPlace[index];
                    tmp.dlHotelPlaceInfoDetail = dlHotelDetailBal.GetByDLPlaceID(dlHotelPlace[index].ID);
                    //tmp.listImageCity = dlImagePlaceBal.GetByDLPlaceID(dlRestaurantPlace[index].ID);
                    HotelBook.Add(tmp);

                }
                HotelBookTemp = HotelBook;
                return View(HotelBook);
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

        public ActionResult HotelInfoDetail(long placeId)
        {
            try
            {
                //DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetail = new DL_NicePlaceInfoDetailBAL();
                //var model = dlNicePlaceInfoDetail.GetByPlaceId(placeId);
                var model = new DL_HotelPlaceInfoDetail();
                for (int index = 0; index < HotelBookTemp.Count; index++)
                {
                    if (HotelBookTemp[index].dlHotelPlaceInfoDetail.DL_PlaceId == placeId)
                    {
                        model = HotelBookTemp[index].dlHotelPlaceInfoDetail;
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
