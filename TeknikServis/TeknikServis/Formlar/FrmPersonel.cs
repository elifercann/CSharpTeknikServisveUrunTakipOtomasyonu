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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.tblPersonel
                           select new
                           {
                               u.Id,
                               u.Ad,
                               u.Soyad,
                               u.Mail,
                               u.Telefon

                           };
            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.tblDepartman
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.Ad
                                                 }).ToList();
            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;


            ad1 = db.tblPersonel.First(x => x.Id == 1).Ad;
            soyad1 = db.tblPersonel.First(x => x.Id == 1).Soyad;
            labelControl23.Text = ad1 + " " + soyad1;
            labelControl22.Text = db.tblPersonel.First(x => x.Id == 1).tblDepartman.Ad;
            labelControl21.Text= db.tblPersonel.First(x => x.Id == 1).Mail;


            ad2 = db.tblPersonel.First(x => x.Id == 2).Ad;
            soyad2 = db.tblPersonel.First(x => x.Id == 2).Soyad;
            labelControl26.Text = ad2 + " " + soyad2;
            labelControl25.Text = db.tblPersonel.First(x => x.Id == 2).tblDepartman.Ad;
            labelControl24.Text = db.tblPersonel.First(x => x.Id == 2).Mail;

            ad3 = db.tblPersonel.First(x => x.Id == 3).Ad;
            soyad3 = db.tblPersonel.First(x => x.Id == 3).Soyad;
            labelControl29.Text = ad3 + " " + soyad3;
            labelControl28.Text = db.tblPersonel.First(x => x.Id == 3).tblDepartman.Ad;
            labelControl27.Text = db.tblPersonel.First(x => x.Id == 3).Mail;

            ad4 = db.tblPersonel.First(x => x.Id == 4).Ad;
            soyad4 = db.tblPersonel.First(x => x.Id == 4).Soyad;
            labelControl32.Text = ad4 + " " + soyad4;
            labelControl31.Text = db.tblPersonel.First(x => x.Id == 4).tblDepartman.Ad;
            labelControl30.Text = db.tblPersonel.First(x => x.Id == 4).Mail;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblPersonel t = new tblPersonel();
            t.Ad = txtAd.Text;
            t.Soyad = txtSoyad.Text;
            t.Mail = txtMail.Text;
            t.Departman = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.tblPersonel.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel ekleme işlemi gerçekleştirildi.");

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.tblPersonel
                           select new
                           {
                               u.Id,
                               u.Ad,
                               u.Soyad,
                               u.Mail,
                               u.Telefon

                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
