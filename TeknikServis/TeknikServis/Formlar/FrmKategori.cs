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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void metot2()
        {
            var degerler = from k in db.tblKategori
                           select new
                           {
                               k.Id,
                               k.Ad
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            metot2();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text != " " && txtAdi.Text.Length <= 30)
            {
                tblKategori t = new tblKategori();
                t.Ad = txtAdi.Text;
                db.tblKategori.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Kategori adı boş geçilemez ve kategori adı 30 karakterden uzun olamaz ");
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            metot2();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAdi.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deger = db.tblKategori.Find(id);
            db.tblKategori.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncellee_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deger = db.tblKategori.Find(id);
            deger.Ad = txtAdi.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAdi.Text = "";
            txtId.Text = "";
        }
    }
}
