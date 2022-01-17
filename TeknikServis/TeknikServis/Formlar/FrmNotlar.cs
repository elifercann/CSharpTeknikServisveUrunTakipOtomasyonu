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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.tblNotlar.Where(x => x.Durum == false).ToList();
            gridControl2.DataSource = db.tblNotlar.Where(y => y.Durum == true).ToList();
        }
        tblNotlar t = new tblNotlar();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
           
            t.Baslik = txtBaslik.Text;
            t.İcerik = txtİcerik.Text;
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            t.Durum = false;
            db.tblNotlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.tblNotlar.Where(x => x.Durum == false).ToList();
            gridControl2.DataSource = db.tblNotlar.Where(y => y.Durum == true).ToList();
        }

        private void btnGuncellee_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtId.Text);
            var deger = db.tblNotlar.Find(id);
            deger.Durum = true;
            db.SaveChanges();
            MessageBox.Show("Not durumu değiştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtBaslik.Text = "";
            txtİcerik.Text = "";
            txttarih.Text = "";
            t.Durum = false;

        }
    }
}
