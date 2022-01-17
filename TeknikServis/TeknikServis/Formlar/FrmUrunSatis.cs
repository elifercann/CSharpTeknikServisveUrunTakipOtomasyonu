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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnSatinAl_Click(object sender, EventArgs e)
        {
            tblUrunHareket t = new tblUrunHareket();
            t.Urun = int.Parse(lookUpEdit3.EditValue.ToString());
            t.Musteri = int.Parse(lookUpEdit4.EditValue.ToString());
            t.Personel = short.Parse(lookUpEdit5.EditValue.ToString());
            t.Tarih = DateTime.Parse(txtTarih.Text);
            t.Adet = short.Parse(txtAdet.Text);
            t.Fiyat = decimal.Parse(txtSatis.Text);
            t.ÜrünSeriNo = txtSeriNo.Text;
            db.tblUrunHareket.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Yapıldı");

        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpEdit3.Properties.DataSource = (from x in db.tblUrun
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.Ad,
                                                 }).ToList();

            lookUpEdit4.Properties.DataSource = (from x in db.tblCari
                                                 select new
                                                 {
                                                     x.Id,
                                                   AD=  x.Ad +" "+x.Soyad
                                                 }).ToList();

            lookUpEdit5.Properties.DataSource = (from x in db.tblPersonel
                                                 select new
                                                 {
                                                     x.Id,
                                                     AD = x.Ad + " " + x.Soyad
                                                 }).ToList();


        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = "";
        }

        private void txtAdet_Click(object sender, EventArgs e)
        {
            txtAdet.Text = "";
        }

        private void txtSatis_Click(object sender, EventArgs e)
        {
            txtSatis.Text = "";
        }

        private void txtSeriNo_Click(object sender, EventArgs e)
        {
            txtSeriNo.Text = "";
        }
    }
}
