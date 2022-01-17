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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void metot1()
        {
            var degerler = from u in db.tblUrun
                           select new
                           {
                               u.Id,
                               u.Ad,
                               u.Marka,
                               Kategori = u.tblKategori.Ad,
                               u.AlışFiyatı,
                               u.SatışFiyatı,
                               u.Stok
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //var degerler = db.tblUrun.ToList();
            metot1();
            lookUpEdit1.Properties.DataSource = (from x in db.tblKategori
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.Ad
                                                 }).ToList();
        }

     
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblUrun t = new tblUrun();
            t.Ad = txtUrunAdi.Text;
            t.Marka = txtMarka.Text;
            t.AlışFiyatı = decimal.Parse(txtAlis.Text);
            t.SatışFiyatı = decimal.Parse(txtSatis.Text);
            t.Durum = false;
            t.Stok = short.Parse(txtStokk.Text);
            t.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.tblUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            metot1();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtUrunId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtUrunAdi.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
                txtMarka.Text = gridView1.GetFocusedRowCellValue("Marka").ToString();
                txtAlis.Text = gridView1.GetFocusedRowCellValue("AlışFiyatı").ToString();
                txtSatis.Text = gridView1.GetFocusedRowCellValue("SatışFiyatı").ToString();
                txtStokk.Text = gridView1.GetFocusedRowCellValue("Stok").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUrunId.Text);
            var deger = db.tblUrun.Find(id);
            db.tblUrun.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncellee_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUrunId.Text);
            var deger = db.tblUrun.Find(id);
            deger.Ad = txtUrunAdi.Text;
            deger.Marka = txtMarka.Text;
            deger.AlışFiyatı = decimal.Parse(txtAlis.Text);
            deger.SatışFiyatı = decimal.Parse(txtSatis.Text);
            deger.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            deger.Stok = short.Parse(txtStokk.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUrunId.Text = "";
            txtUrunAdi.Text = "";
            txtMarka.Text = "";
            txtAlis.Text = "";
            txtSatis.Text = "";
            txtStokk.Text = "";
            lookUpEdit1.Text = "";
        }
    }
}
