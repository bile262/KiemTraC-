using KiemTra.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            
            nhomdanhba = NhómDanhBa.GetListFromDB();
            bds1.DataSource = nhomdanhba;
            dvg1.DataSource = bds1;
            
            
        }
        public void Load()
        {
            dvg1.AutoGenerateColumns = false;

            nhomdanhba = NhómDanhBa.GetListFromDB();
            bds1.DataSource = nhomdanhba;
            dvg1.DataSource = bds1;
            var nhomdanhba1 = (NhómDanhBa)bds1.Current;
            chitietdanhba = ChiTietDanhBa.GetListFromDB(nhomdanhba1.TenNhom);
            dvg2.AutoGenerateColumns = false;
            bds2.DataSource = chitietdanhba;
            dvg2.DataSource = bds2;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new ThemNhom();
            f.ShowDialog();
            Load();

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn xóa nhóm này?","Thông báo!",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning)== System.Windows.Forms.DialogResult.OK)
            {
                var nhom = (NhómDanhBa)bds1.Current;
                NhómDanhBa.Remove(nhom);
                MessageBox.Show("Đã xóa dữ liệu có tên là: " + nhom.TenNhom, "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Load();
            }
           
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            var f = new ThemLienLac();
            f.ShowDialog();
            Load();
        }

        

        private void Dvg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var nhomdanhba = (NhómDanhBa)bds1.Current;
            chitietdanhba = ChiTietDanhBa.GetListFromDB(nhomdanhba.TenNhom);
            dvg2.AutoGenerateColumns = false;
            bds2.DataSource = chitietdanhba;
            dvg2.DataSource = bds2;
        }

        private void Dvg2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var nhomdanhba = (NhómDanhBa)bds1.Current;
            chitietdanhba = ChiTietDanhBa.GetListFromDB(nhomdanhba.TenNhom); 
            dvg2.AutoGenerateColumns = false;
            bds2.DataSource = chitietdanhba;
            dvg2.DataSource = bds2;
            var chitiet = (ChiTietDanhBa)bds2.Current;
            label6.Text = chitiet.Tengoi;
            label7.Text = chitiet.Diachi;
            label8.Text = chitiet.Email;
            label9.Text = chitiet.SDT;
        }

        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string t = toolStripTextBox1.Text;
            List<ChiTietDanhBa> ct = new List<ChiTietDanhBa>();
            for(int i=0;i<chitietdanhba.Count;i++)
            {
                if((chitietdanhba[i].Tengoi.ToLower().Contains(t.ToLower())==true)||(chitietdanhba[i].Email.ToLower().Contains(t.ToLower()) == true)||
                        (chitietdanhba[i].SDT.Contains(t.ToLower()) == true))
                {
                    ct.Add(new ChiTietDanhBa
                    {
                        Tengoi = chitietdanhba[i].Tengoi,
                        TenNhom = chitietdanhba[i].TenNhom,
                        Diachi = chitietdanhba[i].Diachi,
                        Email = chitietdanhba[i].Email,
                        SDT = chitietdanhba[i].SDT
                    });
                }
            }
            dvg2.DataSource = ct;
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa liên lạc này ?", "Thông báo!", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                var nhomll = (ChiTietDanhBa)bds2.Current;


                ChiTietDanhBa.Remove(nhomll);
                Load();
    


                MessageBox.Show("Đã xóa dữ liệu có tên là: " + nhomll.Tengoi, "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
