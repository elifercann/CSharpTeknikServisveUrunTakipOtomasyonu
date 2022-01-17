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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        int secilen;
        void liste()
        {
            var degerler = from x in db.tblCari
                           select new
                           {
                               x.Id,
                               x.Ad,
                               x.Soyad,
                               x.İl,
                               x.İlçe
                           };

            gridControl1.DataSource = degerler.ToList();


        }
        private void FrmCariLstesi_Load(object sender, EventArgs e)
        {
            liste();

            labelControl12.Text = db.tblCari.Count().ToString();
            lookUpEdit1.Properties.DataSource = (from x in db.tbliller
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir,
                                                 }).ToList();

            labelControl16.Text = db.tblCari.Select(x => x.İl).Distinct().Count().ToString();
            labelControl18.Text = db.tblCari.Select(x => x.İlçe).Distinct().Count().ToString();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.tblilceler
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == secilen).ToList();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtAdi.Text!="" && txtSoyad.Text !="" && txtAdi.Text.Length <= 20)
            {
                tblCari t = new tblCari();
                t.Ad = txtAdi.Text;
                t.Soyad = txtSoyad.Text;
                t.İl = lookUpEdit1.Text;
                t.İlçe = lookUpEdit2.Text;
                db.tblCari.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari sisteme eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                liste();

            }
            else
            {
                MessageBox.Show("Hatalı giriş yeniden deneyin");
            }
        }

       
    }
}
