using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL.Entity
{
    class ChiTietDanhBa
    {
        [Key]
        public string Tengoi { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string TenNhom { get; set; }
        [ForeignKey("TenNhom")]
        public virtual NhómDanhBa NhómDanhBa { get; set; }
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
        public static List<ChiTietDanhBa> GetListFromDB(string Tennhom)
        {
            return new KiemTraDBContext().ChiTietDanhBaDbSet.Where(e => e.TenNhom == Tennhom).ToList();
        }
        public static void Remove(ChiTietDanhBa ten)
        {
            var db = new KiemTraDBContext();
            var ojbSV = db.ChiTietDanhBaDbSet.Where(e => e.Tengoi == ten.Tengoi).FirstOrDefault();
            if (ojbSV != null)
            {
                db.ChiTietDanhBaDbSet.Remove(ojbSV);

            }
            db.SaveChanges();
        }
        public static void Add(ChiTietDanhBa nhom)
        {
            var db = new KiemTraDBContext();
            db.ChiTietDanhBaDbSet.Add(nhom);
            db.SaveChanges();

        }
    }
}
