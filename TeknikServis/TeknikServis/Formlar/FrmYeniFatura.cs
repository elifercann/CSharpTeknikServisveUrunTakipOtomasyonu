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
    public partial class FrmYeniFatura : Form
    {
        public FrmYeniFatura()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblFaturaBilgi t = new tblFaturaBilgi();
            t.Seri = txtSeri.Text;
            t.SiraNo = txtSira.Text;
            t.Tarih = Convert.ToDateTime(txtTarih.Text);
            t.Saat = txtSaat.Text;
            t.VergiDaire = txtVergi.Text;
            t.Cari = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Personel = short.Parse(lookUpEdit2.EditValue.ToString());
            db.tblFaturaBilgi.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura sisteme kaydedilmiştir,kalem girişi yapabilirsiniz");
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYeniFatura_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.tblCari
                                                 select new
                                                 {
                                                     x.Id,
                                                     Ad = x.Ad + " " + x.Soyad
                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in db.tblPersonel
                                                 select new
                                                 {
                                                     x.Id,
                                                     Ad = x.Ad + " " + x.Soyad
                                                 }).ToList();
        }
    }
}
