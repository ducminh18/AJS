using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AJS.Models
{
    public class DataConnect
    {
        //những đối tượng thực hiện kết nối đến CSDL
        //sqlconnection, sqlcommand, sqldataadapter, datatable/dataset
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //chuỗi kết nối đến CSDL
        string chuoikn = ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString;
        public DataConnect()
        {
            cnn = new SqlConnection(chuoikn);
        }
        //thực hiện 2 thao tác đọc/ghi trên CSDl
        public DataTable getData(string sql)
        {
            cnn.Open();
            da = new SqlDataAdapter(sql, cnn);
            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public void writeData(string sql)
        {
            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cnn.Close();
        }
    }
}