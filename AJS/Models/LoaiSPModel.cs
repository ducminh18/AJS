using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AJS.Models
{
    public class LoaiSPModel
    {
        DataConnect dc = new DataConnect();
        public List<LoaiSP> getAllLoaiSP()
        {
            List<LoaiSP> li = new List<LoaiSP>();
            DataTable dt = dc.getData("Select * from LoaiSP");
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP lsp = new LoaiSP();
                lsp.MaLoai = dr[0].ToString();
                lsp.TenLoai = dr[1].ToString();
                lsp.GhiChu = dr[2].ToString();
                li.Add(lsp);
            }
            return li;
        }
        public LoaiSP getOneLSP(string id)
        {
            LoaiSP li = new LoaiSP();
            DataTable dt = dc.getData("Select * from LoaiSP where Maloai='" + id + "'");
            li.MaLoai = dt.Rows[0][0].ToString();
            li.TenLoai = dt.Rows[0][1].ToString();
            li.GhiChu = dt.Rows[0][2].ToString();
            return li;
        }    
        public void CreateLSP(LoaiSP x)
        {
            string sql = "insert into LoaiSP values('" + x.MaLoai + "', N'" + x.TenLoai + "', N'" + x.GhiChu + "')";
            dc.writeData(sql);
        }
        public void UpdateLSP(LoaiSP x)
        {
            string sql = "update LoaiSP set TenLoai=N'" + x.TenLoai + "', GhiChu=N'" + x.GhiChu + "' where MaLoai='" + x.MaLoai + "'";
            dc.writeData(sql);
        }
        public void DeleteLSP(string id)
        {
            string sql = "delete from LoaiSP where MaLoai='" + id + "'";
            dc.writeData(sql);
        }
    }
}