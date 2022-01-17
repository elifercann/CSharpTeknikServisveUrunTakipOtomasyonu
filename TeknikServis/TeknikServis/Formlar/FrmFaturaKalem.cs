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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.tblFaturaDetay
                           select new
                           {
                               u.FaturaDetayId,
                               u.Urun,
                               u.Adet,
                               u.Fiyat,
                               u.Tutar,
                               u.FaturaId,
                             

                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblFaturaDetay t = new tblFaturaDetay();
            t.Urun = txtUrun.Text;
            t.Adet = short.Parse(txtAdet.Text);
            t.Fiyat = decimal.Parse(txtFiyat.Text);
            t.Tutar = decimal.Parse(txtTutar.Text);
            t.FaturaId = int.Parse(txtFaturaId.Text);
            db.tblFaturaDetay.Add(t);
            db.SaveChanges();
            MessageBox.Show("Faturaya ait kalem girişi başarıyla gerçekleştirildi");
           
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.tblFaturaDetay
                           select new
                           {
                               u.FaturaDetayId,
                               u.Urun,
                               u.Adet,
                               u.Fiyat,
                               u.Tutar,
                               u.FaturaId,


                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
