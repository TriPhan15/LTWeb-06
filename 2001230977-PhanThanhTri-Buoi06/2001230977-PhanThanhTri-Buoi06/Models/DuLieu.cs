using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using _2001230977_PhanThanhTri_Buoi06.ViewsModel;
namespace _2001230977_PhanThanhTri_Buoi06.Models
{
    public class DuLieu
    {

        string con = ConfigurationManager.ConnectionStrings["Buoi06"].ConnectionString;
        public List<SanPham> dssp = new List<SanPham>();
        public List<Loai> dsl = new List<Loai>();
        public DuLieu()
        {
            ThietLap_DSSP();
            ThietLap_DSL();
        }
        public void ThietLap_DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from sanpham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new SanPham();
                en.masanpham = dr["masanpham"].ToString();
                en.tensp = dr["tensp"].ToString();
                en.mal = dr["mal"].ToString();
                en.masx = dr["masx"].ToString();
                en.gia = double.Parse(dr["gia"].ToString());
                en.ghichu = dr["ghichu"].ToString();
                en.hinh = dr["hinh"].ToString();
                dssp.Add(en);
            }
        }
        public void ThietLap_DSL()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new Loai();

                en.maloai = dr["maloai"].ToString();
                en.tenloai = dr["tenloai"].ToString();
                dsl.Add(en);
            }
        }
        public List<SanPham> DSSP(string maloai)
        {
            List<SanPham> em = new List<SanPham>();
            string sqlscript = string.Format("select * from sanpham where mal='{0}'", maloai);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows){
                var en = new SanPham();
                en.masanpham = dr["masanpham"].ToString();
                en.tensp = dr["tensp"].ToString();
                en.mal = dr["mal"].ToString();
                en.masx = dr["masx"].ToString();
                en.gia = double.Parse(dr["gia"].ToString());
                en.ghichu = dr["ghichu"].ToString();
                en.hinh = dr["hinh"].ToString();
                em.Add(en);
            }
            return em;
        }
        public List<Loai> DSL(string maloai)
        {
            List<Loai> ab = new List<Loai>();
            string sqlscript = string.Format("select * from loai where maloai='{0}'", maloai);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new Loai();
                en.maloai = dr["maloai"].ToString();
                en.tenloai = dr["tenloai"].ToString();
                ab.Add(en);
            }
            return ab;
        }
        public SanPham ChiTietSanPham(string maSP)
        {
            SanPham sanPham = new SanPham();
            string sqlscript = string.Format("select * from sanpham where masanpham='{0}'", maSP);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                sanPham = new SanPham
                {
                    masanpham = dr["masanpham"].ToString(),
                    tensp = dr["tensp"].ToString(),
                    mal = dr["mal"].ToString(),
                    masx = dr["masx"].ToString(),
                    gia = double.Parse(dr["gia"].ToString()),
                    ghichu = dr["ghichu"].ToString(),
                    hinh = dr["hinh"].ToString()
                };
            }

            return sanPham;
        }
        public KhachHang Login(string phone, string password)
        {
            KhachHang khachHang = null;

            string sqlString = "SELECT * FROM khachhang WHERE sodienthoai = @phone AND matkhau = @password";
            using (SqlConnection connection = new SqlConnection(con))
            using (SqlCommand cmd = new SqlCommand(sqlString, connection))
            {
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    khachHang = new KhachHang
                    {
                        makhachhang = dr["makhachhang"].ToString(),
                        tenkhachhang = dr["tenkhachhang"].ToString(),
                        sodienthoai = dr["sodienthoai"].ToString()
                    };
                }
            }

            return khachHang;
        }
        public List<SanPham> TimKiemTheoLoai(string maloai)
        {
            List<SanPham> em = new List<SanPham>();
            string sqlscript = string.Format("select * from sanpham where mal='{0}'", maloai);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new SanPham();
                en.masanpham = dr["masanpham"].ToString();
                en.tensp = dr["tensp"].ToString();
                en.mal = dr["mal"].ToString();
                en.masx = dr["masx"].ToString();
                en.gia = double.Parse(dr["gia"].ToString());
                en.ghichu = dr["ghichu"].ToString();
                en.hinh = dr["hinh"].ToString();
                em.Add(en);
            }
            return em;
        }

        public List<SanPham> TimKiemTheoGia(double giaTu, double giaDen)
        {
            List<SanPham> em = new List<SanPham>();
            string sqlscript = string.Format("select * from sanpham where gia between {0} and {1}", giaTu, giaDen);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new SanPham();
                en.masanpham = dr["masanpham"].ToString();
                en.tensp = dr["tensp"].ToString();
                en.mal = dr["mal"].ToString();
                en.masx = dr["masx"].ToString();
                en.gia = double.Parse(dr["gia"].ToString());
                en.ghichu = dr["ghichu"].ToString();
                en.hinh = dr["hinh"].ToString();
                em.Add(en);
            }
            return em;
        }
        public List<HoaDon> DSHD()
        {
            List<HoaDon> list = new List<HoaDon>();
            string sql = "select * from hoadon";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HoaDon hd = new HoaDon
                {
                    mahoadon = dr["mahoadon"].ToString(),
                    ngaytao = DateTime.Parse(dr["ngaytao"].ToString()),
                    makh = dr["makh"].ToString()
                };
                list.Add(hd);
            }
            return list;
        }

        public List<ChiTiet> ChiTietHoaDon(string mahd)
        {
            List<ChiTiet> list = new List<ChiTiet>();
            string sql = string.Format("select * from chitiet where mahd='{0}'", mahd);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ChiTiet ct = new ChiTiet
                {
                    mahd = dr["mahd"].ToString(),
                    masp = dr["masp"].ToString(),
                    soluong = int.Parse(dr["soluong"].ToString())
                };
                list.Add(ct);
            }
            return list;
        }


    }
}