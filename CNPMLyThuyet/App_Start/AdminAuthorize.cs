using CNPMLyThuyet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CNPMLyThuyet.App_Start
{
    public class AdminAuthorize:AuthorizeAttribute
    {
        public string chucnang { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            NhanVien nhanvien = (NhanVien)HttpContext.Current.Session["TaiKhoan"];
            if (nhanvien == null)
            {
                QuanLyTrungTamThuongMaiEntities4 db = new QuanLyTrungTamThuongMaiEntities4();
                var count = db.PhanQuyens.Count(m => m.MaPB == nhanvien.MaPB && m.MaCN == chucnang);
                if (count != 0)
                {
                    return;
                }
                else
                {
                    var returnurl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", returnurl = returnurl.ToString() }));
                }

                return;
            }
            else
            {
                var returnurl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", returnurl = returnurl.ToString() }));
            }

        }
    }
}