using KiemTra.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTra
{
    public partial class Form1 : Form
    {
        string pathDataNhom;
        string pathDataChitiet;
        private List<ChiTietDanhBa> chitietdanhba;
        private List<NhómDanhBa> nhomdanhba;
        public Form1()
        {
            InitializeComponent();
            pathDataNhom = Application.StartupPath + @"\Data\NhomDanhBa.data";
            pathDataChitiet= Application.StartupPath + @"\Data\ChiTietDanhBa.data";
            dvg1.AutoGenerateColumns = false;
            
            nhomdanhba = NhómDanhBa.GetListFromFile(pathDataNhom);
            bds1.DataSource = nhomdanhba;
            dvg1.DataSource = bds1;
            
        }
         

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Dvg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var nhomdanhba = (NhómDanhBa)bds1.Current;
            chitietdanhba = ChiTietDanhBa.GetListFromFile(pathDataChitiet, nhomdanhba.TenNhom);
            dvg2.AutoGenerateColumns = false;
            bds2.DataSource = chitietdanhba;
            dvg2.DataSource = bds2;

        }
    }
}
