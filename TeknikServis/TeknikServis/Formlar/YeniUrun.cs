using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class YeniUrun : Form
    {
        public YeniUrun()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
            tblUrun t = new tblUrun();
            t.Ad = txtUrunAd.Text;
            t.Marka = txtMarka.Text;
            t.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.AlışFiyatı = decimal.Parse(txtAlış.Text);
            t.SatışFiyatı = decimal.Parse(txtSatış.Text);
            t.Stok = short.Parse(txtStok.Text);
            db.tblUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi");
        }

        private void txtUrunAd_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = "";
            txtUrunAd.Focus();
        }

        private void txtMarka_Click(object sender, EventArgs e)
        {
            txtMarka.Text = "";
            txtMarka.Focus();
        }

        private void txtAlış_Click(object sender, EventArgs e)
        {
            txtAlış.Text = "";
            txtAlış.Focus();
        }

        private void txtSatış_Click(object sender, EventArgs e)
        {
            txtSatış.Text = "";
            txtSatış.Focus();
        }

        private void txtStok_Click(object sender, EventArgs e)
        {
            txtStok.Text = "";
            txtStok.Focus();
        }

        private void YeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.tblKategori
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.Ad
                                                 }).ToList();
        }
    }
}
