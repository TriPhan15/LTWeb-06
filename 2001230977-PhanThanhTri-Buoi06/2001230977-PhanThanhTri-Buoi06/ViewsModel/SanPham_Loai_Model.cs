using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2001230977_PhanThanhTri_Buoi06.Models;
namespace _2001230977_PhanThanhTri_Buoi06.ViewsModel
{
    public class SanPham_Loai_Model
    {
        public List<SanPham> DSSP { get; set; }
        public List<Loai> DSL { get; set; }
        public string SelectedMaLoai { get; set; }
        public double GiaTu { get; set; }
        public double GiaDen { get; set; }
    }
}