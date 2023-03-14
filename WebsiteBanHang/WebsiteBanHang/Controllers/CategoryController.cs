using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebBanHangEntities objWebBanHangEntities = new WebBanHangEntities();
        // GET: Category
        public ActionResult Category()
        {
            var lstCategory = objWebBanHangEntities.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWebBanHangEntities.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
    }
}