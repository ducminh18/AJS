using AJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJS.Interface.Models
{
    public interface IProductService
    {
        List<Product> GetList();
        bool AddOrUpdate(Product prod);

        bool Delete(string MaSP);

        Product GetById(string ID);
    }
}