using KiemTra.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL
{
    class KiemTraDBContext : DbContext
    {
        public KiemTraDBContext():base("Data Source=.;Initial Catalog=KiemTraDB;Persist Security Info=True;User ID=sa;Password=123")
        {

        }
        public DbSet<NhómDanhBa> NhomDanhBaDbSet { get; set; }
        public DbSet<ChiTietDanhBa> ChiTietDanhBaDbSet { get; set; }
    }
}
