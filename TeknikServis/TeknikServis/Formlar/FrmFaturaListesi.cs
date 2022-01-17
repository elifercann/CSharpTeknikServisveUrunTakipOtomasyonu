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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.tblFaturaBilgi
                           select new
                           {
                               u.Id,
                               u.Seri,
                               u.Tarih,
                               u.Saat,
                              Cari= u.tblCari.Ad  +" "+ u.tblCari.Soyad,
                              Personel=u.tblPersonel.Ad+ " " + u.tblPersonel.Soyad

                           };
            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.tblCari
                                                 select new
                                                 {
                                                     x.Id,
                                                    Ad= x.Ad + " " +x.Soyad
                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in db.tblPersonel
                                                 select new
                                                 {
                                                     x.Id,
                                                     Ad = x.Ad + " " + x.Soyad
                                                 }).ToList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.tblFaturaBilgi
                           select new
                           {
                               u.Id,
                               u.Seri,
                               u.Tarih,
                               u.Saat,
                               Cari = u.tblCari.Ad + " " + u.tblCari.Soyad,
                               Personel = u.tblPersonel.Ad + " " + u.tblPersonel.Soyad

                           };
            gridControl1.DataSource = degerler.ToList();
        }

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

       
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());   
            fr.Show();
        }
    }
}
