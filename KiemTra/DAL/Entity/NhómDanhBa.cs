using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL.Entity
{
    class NhómDanhBa
    {   [Key]
        public string TenNhom { get; set; }
        
        public static List<NhómDanhBa> GetListFromFile(string pathData)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<NhómDanhBa> ketQua = new List<NhómDanhBa>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });
                var nhomdanhba = new NhómDanhBa
                {
                    TenNhom=lsValue[1],
                };
                
                    ketQua.Add(nhomdanhba);
            }
            return ketQua;
        }
        public static void Remove(NhómDanhBa nhom)
        {
            var db = new KiemTraDBContext();
            var ojbSV = db.NhomDanhBaDbSet.Where(e => e.TenNhom == nhom.TenNhom).FirstOrDefault();
            if (ojbSV != null)
            {
                db.NhomDanhBaDbSet.Remove(ojbSV);
               
            }
            db.SaveChanges();
        }
        public static List<NhómDanhBa> GetListFromDB()
        {
            return new KiemTraDBContext().NhomDanhBaDbSet.ToList();
        }
        public static void Add(NhómDanhBa nhom)
        {
            var db = new KiemTraDBContext();
            db.NhomDanhBaDbSet.Add(nhom);
            db.SaveChanges();

        }
    }
}
