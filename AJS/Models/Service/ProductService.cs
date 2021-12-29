using AJS.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJS.Models.Service
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dc = new DataContext();

        public ProductService()
        {
        }

        public bool AddOrUpdate(Product prod)
        {
            var product = _dc.SanPham.FirstOrDefault(p => p.MaSP == prod.MaSP);
            if (product != null)
            {
                product.MoTa = prod.MoTa;
                product.SoLuong = prod.SoLuong;
                product.TenSP = prod.TenSP;
                product.MoTa = prod.MoTa;
                product.Anh = prod.Anh;
            }
            else
            {
                product = new Product
                {
                    Anh = prod.Anh,
                    TenSP = prod.TenSP,
                    SoLuong = prod.SoLuong,
                    MaSP = prod.MaSP,
                    DonGia = prod.DonGia,
                    MaLoai = prod.MaLoai,
                    MoTa = prod.MoTa
                };
                _dc.SanPham.Add(product);
            }

            if (_dc.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete(string MaSP)
        {
            var product = _dc.SanPham.FirstOrDefault(p => p.MaSP == MaSP);
            if (product != null)
            {
                _dc.SanPham.Remove(product);
            }
            return _dc.SaveChanges() > 0;
        }

        public Product GetById(string ID)
        {
            return _dc.SanPham.FirstOrDefault(p => p.MaSP == ID);
        }

        public List<Product> GetList()
        {
            return _dc.SanPham.ToList();
        }
    }
}