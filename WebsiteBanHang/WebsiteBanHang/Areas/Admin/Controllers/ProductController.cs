using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebBanHangEntities dbObj = new WebBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = dbObj.Products.ToList();
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))+ extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                dbObj.Products.Add(objProduct);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
    }
}