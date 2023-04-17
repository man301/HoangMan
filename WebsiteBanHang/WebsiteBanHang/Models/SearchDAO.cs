using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Models
{
    public class SearchDAO
    {
        WebBanHangEntities objWebBanHangEntities = new WebBanHangEntities();
        public List<Product> SearchByKey(string key)
        {
            return objWebBanHangEntities.Products.SqlQuery("Select * From Product Where Name like '%" + key + "%'").ToList();
        }
    }
}