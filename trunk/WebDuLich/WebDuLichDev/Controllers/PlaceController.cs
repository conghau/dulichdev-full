using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;
using System.IO;
using DuLichDLL.TOOLS;
using WebDuLichDev.Models;
using WebDuLichDev.WebUtility;
using DuLichDLL.ExceptionType;
using WebDuLichDev.Enum;
using System.Text;
using WebMatrix.WebData;

namespace WebDuLichDev.Controllers
{
    public class PlaceController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PlaceController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";
        //
        // GET: /Place/
        private static List<DL_ImagePlace> listImagePlaceOld = new List<DL_ImagePlace>();

        private static List<vm_NicePlace> nicePlaceBookTemp = new List<vm_NicePlace>();
        [Authorize]
        public ActionResult ListNicePlace()
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
                var model = dlPlaceBAL.GetListWithFilter(0, "", "", (int)DL_PlaceTypeId.Places, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
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
        public ActionResult ListNicePlace(vm_Pagination pagination, vm_Search dataSearch)
        {
            try
            {
                long totalRecords = 0;

                DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
                var model = dlPlaceBAL.GetListWithFilter(dataSearch.cityId ?? 0, dataSearch.placename ?? "", dataSearch.address ?? "", (int)DL_PlaceTypeId.Places, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
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

        //[Authorize]
        public ActionResult NicePlaceByCity(long ID)
        {
            try
            {
                ViewBag.CityId = ID;
                ViewBag.IntoZing = WebDuLichSecurity.IntoZing;
                //if (WebDuLichSecurity.IntoZing)
                //{
                //    WebDuLichSecurity.PathImageBook = "/Content/themes/20Thing/css/images";
                //}
                //else
                //{
                //    WebDuLichSecurity.PathImageBook = "/Content/themes/20Thing/css/images_full";
                //}

                DL_CityBAL dlCityBal = new DL_CityBAL();
                var city = dlCityBal.GetByID(ID);
                ViewBag.CityName = city.CityName;

                vm_Pagination pagination = new vm_Pagination { OrderBy = DL_PlaceColumns.CreatedDate.ToString(), OrderDirection = "DESC" };
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetailBal = new DL_NicePlaceInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                var dlPlace = dlPlaceBal.GetListNicePlaceByCity(ID);
                ViewData["OrderBy"] = pagination.OrderBy;
                ViewData["OrderDirection"] = pagination.OrderDirection;
                var nicePlaceBook = new List<vm_NicePlace>();
                for (int index = 0; index < dlPlace.Count(); index++)
                {
                    var tmp = new vm_NicePlace();
                    tmp.dlPlace = dlPlace[index];
                    tmp.dlNicePlaceInfoDetail = dlNicePlaceInfoDetailBal.GetByPlaceId(dlPlace[index].ID);
                    tmp.listImagePlace = dlImagePlaceBal.GetByDLPlaceID(dlPlace[index].ID);
                    nicePlaceBook.Add(tmp);

                }
                nicePlaceBookTemp = nicePlaceBook;
                return View(nicePlaceBook);
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

        public ActionResult NicePlace(long ID)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetailBal = new DL_NicePlaceInfoDetailBAL();
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();

            var nicePlace = new vm_NicePlace();

            //nicePlace = nicePlaceBook.Where(p => p.dlPlace.ID == ID).Single();
            nicePlace.dlPlace = dlPlaceBal.GetByID(ID);
            nicePlace.dlNicePlaceInfoDetail = dlNicePlaceInfoDetailBal.GetByPlaceId(ID);
            nicePlace.listImagePlace = dlImagePlaceBal.GetByDLPlaceID(ID);

            return View(nicePlace);
        }

        public ActionResult ListImagePlace(long placeId)
        {
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            var model = dlImagePlaceBal.GetByDLPlaceID(placeId);
            return View(model);
        }

        public ActionResult PlaceInfoDetail(long placeId)
        {
            try
            {
                //DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetail = new DL_NicePlaceInfoDetailBAL();
                //var model = dlNicePlaceInfoDetail.GetByPlaceId(placeId);
                var model = new DL_NicePlaceInfoDetail();
                for (int index = 0; index < nicePlaceBookTemp.Count; index++)
                {
                    if (nicePlaceBookTemp[index].dlNicePlaceInfoDetail.DL_PlaceId == placeId)
                    {
                        model = nicePlaceBookTemp[index].dlNicePlaceInfoDetail;
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

        public ActionResult PrintBook(long cityId)
        {
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            if (null != nicePlaceBookTemp && nicePlaceBookTemp.Count != 0)
                for (int index = 0; index < nicePlaceBookTemp.Count; index++)
                {
                    nicePlaceBookTemp[index].listImagePlace = dlImagePlaceBal.GetByDLPlaceID(nicePlaceBookTemp[index].dlPlace.ID);
                }
            var model = nicePlaceBookTemp;
            return View(model);
        }

        [HttpPost]
        public ActionResult Rating(long placeId, int rate)
        {

            try
            {
                long userId = WebSecurity.CurrentUserId; // WebSecurity.CurrentUserId;
                bool success = false;
                //string error = "";
                float avg = 0;
                long total = 0;
                //DL_CommentCityBAL dlCommentCityBal = new DL_CommentCityBAL();
                var dlPlaceBal = new DL_PlaceBAL();

                var dlPlace = new DL_Place();
                dlPlace = dlPlaceBal.GetByID(placeId);
                dlPlace.TotalPointRating = dlPlace.TotalPointRating + rate;
                dlPlace.TotalUserRating = dlPlace.TotalUserRating + 1;
                avg = dlPlace.TotalPointRating / dlPlace.TotalUserRating;
                dlPlace.AvgRating = (int)avg;

                if (dlPlaceBal.Update(dlPlace) > 0)
                    success = true;
                //success = db.RegisterProductVote(userId, id, rate);
                total = dlPlace.TotalUserRating;
                ViewBag.AVG = avg;

                return Json(new { success = success, Avg = avg, TotalUser = total });
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return null;
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return null;
            }


        }

        public ActionResult CommentPlace(long placeId, string type)
        {
            ViewBag.placeId = placeId;
            ViewBag.type = type.Trim().ToLower();
            return View();
        }

        [HttpPost]
        public ActionResult Spams(long placeId)
        {
            try
            {
                DL_SPAMREPORT dlSpamReport = new DL_SPAMREPORT{ DL_PlaceID = placeId, UserID = WebSecurity.GetUserId(User.Identity.Name),Status =0};
                DL_SPAMREPORTBAL dlSpamReportBal = new DL_SPAMREPORTBAL();
                long result = dlSpamReportBal.Insert(dlSpamReport);
                if (result > 0)
                {
                    return Json(new { status = "OK" }, "text/plain");
                }
                else
                    return Json(new {status ="NO"},"text/plain" );
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return Json(new { status = "NO" }, "text/plain");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return Json(new { status = "NO" }, "text/plain");
            }
        }

        #region Admin Control

        [Authorize]
        public ActionResult AddPlace()
        {
            vm_NicePlace model = new vm_NicePlace();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPlace(vm_NicePlace dataRequest, string[] listImagePlace)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                List<DL_ImagePlace> listDLImagePlace = new List<DL_ImagePlace>();
                if (null != listImagePlace)
                {
                    for (int index = 0; index < listImagePlace.Count(); index++)
                    {
                        DL_ImagePlace temp = new DL_ImagePlace();
                        temp.LinkImage = listImagePlace[index];
                        listDLImagePlace.Add(temp);
                    }
                }
                dataRequest.listImagePlace = listDLImagePlace;

                dataRequest.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Places;
                dataRequest.dlPlace.TotalPointRating = 0;
                dataRequest.dlPlace.TotalUserRating = 0;
                result = dlPlaceBal.InsertNicePlace(dataRequest.dlPlace, dataRequest.dlNicePlaceInfoDetail, dataRequest.listImagePlace);
                //dlPlaceBal.Insert(dataRequest);           
                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Insert;
                    return RedirectToAction("ListNicePlace");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Insert;
                    return RedirectToAction("ListNicePlace");
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

        [Authorize]
        public ActionResult UpdateNicePlace(long dlPlaceId)
        {
            try
            {
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_NicePlaceInfoDetailBAL dlNicePlaceDetailBal = new DL_NicePlaceInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                vm_NicePlace model = new vm_NicePlace();
                model.dlPlace = dlPlaceBal.GetByID(dlPlaceId);
                model.listImagePlace = dlImagePlaceBal.GetByDLPlaceID(dlPlaceId);
                model.dlNicePlaceInfoDetail = dlNicePlaceDetailBal.GetByPlaceId(dlPlaceId);
                listImagePlaceOld = model.listImagePlace;
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
        public ActionResult UpdateNicePlace(vm_NicePlace dataRequest, long[] listIdImagePresent, string[] listImageAddNew)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_NicePlaceInfoDetailBAL dlNicePlaceDetailBal = new DL_NicePlaceInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                //update status image
                if (null != listImagePlaceOld)
                {
                    if (listIdImagePresent != null)
                    {
                        var listImageDeleted = listImagePlaceOld.Select(m => m.ID).ToArray().Except(listIdImagePresent).ToArray();
                        if (null != listImageDeleted)
                            for (int index = 0; index < listImageDeleted.Count(); index++)
                                dlImagePlaceBal.Delete(listImageDeleted[index]);
                    }
                    if (listIdImagePresent == null)
                    {
                        for (int index = 0; index < listImagePlaceOld.Count(); index++)
                        {
                            dlImagePlaceBal.Delete(listImagePlaceOld[index].ID);
                        }
                    }
                }

                List<DL_ImagePlace> listImagePlaceNew = new List<DL_ImagePlace>();
                if (null != listImageAddNew)
                {
                    for (int index = 0; index < listImageAddNew.Count(); index++)
                    {
                        DL_ImagePlace temp = new DL_ImagePlace();
                        temp.DL_PlaceID = dataRequest.dlPlace.ID;
                        temp.LinkImage = listImageAddNew[index];
                        temp.Status = 0;
                        listImagePlaceNew.Add(temp);
                    }
                }

                result = dlPlaceBal.UpdateNicePlace(dataRequest.dlPlace, dataRequest.dlNicePlaceInfoDetail, listImagePlaceNew);

                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Update;
                    return RedirectToAction("ListNicePlace");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListNicePlace");
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

            // return View();
        }
        public ActionResult DelNicePlace(long ID)
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
                    return RedirectToAction("ListNicePlace");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListNicePlace");
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

    }
}
