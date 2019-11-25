namespace KiemTra.Migrations
{
    using KiemTra.DAL.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KiemTra.DAL.KiemTraDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KiemTra.DAL.KiemTraDBContext context)
        {
            context.ChiTietDanhBaDbSet.AddOrUpdate(new ChiTietDanhBa
            {
                Tengoi = "Trần Ngọc Viện",
                TenNhom = "Bạn Bè",
                SDT = "0122665432",
                Diachi = "Hải Dương",
                Email = "tnv@123gmai.cm"

            });
            context.SaveChanges();
        }
    }
}
