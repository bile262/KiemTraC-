using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL.Entity
{
    class NhómDanhBa
    { public string TenNhom { get; set; }
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
    }
}
