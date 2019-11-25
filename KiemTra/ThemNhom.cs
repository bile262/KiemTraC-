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
    public partial class ThemNhom : Form
    {
        private NhómDanhBa nhomdb;
        public ThemNhom()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {   if (textBox1.Text != null && textBox1.Text !="") 
             {
                var nhomdb = new NhómDanhBa
                {
                    TenNhom = textBox1.Text,
                };
                NhómDanhBa.Add(nhomdb);
                MessageBox.Show("Đã thêm nhóm danh bạ có tên là: " + nhomdb.TenNhom, "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
             
        }
    }
}
