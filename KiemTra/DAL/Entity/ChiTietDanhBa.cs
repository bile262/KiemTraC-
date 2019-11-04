using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL.Entity
{
    class ChiTietDanhBa
    {
        public string TenNhom { get; set; }
        public string Tengoi { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public static List<ChiTietDanhBa> GetListFromFile(string pathData,string tenNhom)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<ChiTietDanhBa> ketQua = new List<ChiTietDanhBa>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });

                var chitietdanhba = new ChiTietDanhBa
                {
                    Tengoi = lsValue[1],
                    Diachi = lsValue[2],
                    Email = lsValue[3],
                    SDT = lsValue[4],
                    TenNhom = lsValue[5],
                };
                if (chitietdanhba.TenNhom == tenNhom )
                    ketQua.Add(chitietdanhba);
            }
            return ketQua;
        }
    }
}
