using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

        private dynamic ToSelectiList(DataTable dtCategory, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private dynamic ToSelectList(DataTable dtCategory, string v1, string v2)
        {
            throw new NotImplementedException();
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
                    //lưu file hình
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            dbObj.Products.Remove(objProduct);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int id,Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            dbObj.Entry(objProduct).State = EntityState.Modified;
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}