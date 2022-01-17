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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.tblDepartman
                           select new
                           {
                               u.Id,
                               u.Ad,


                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text = db.tblDepartman.Count().ToString();
            labelControl14.Text = db.tblPersonel.Count().ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblDepartman t = new tblDepartman();
            if (txtAd.Text.Length <= 50 && txtAd.Text != "")
            {
                t.Ad = txtAd.Text;
                t.Aciklama = richTextBox1.Text;
                db.tblDepartman.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUrunId.Text);
            var deger = db.tblDepartman.Find(id);
            db.tblDepartman.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncellee_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUrunId.Text);
            var deger = db.tblDepartman.Find(id);
            deger.Ad = txtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.tblDepartman
                           select new
                           {
                               u.Id,
                               u.Ad,


                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtUrunId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();

        }
    }
}
