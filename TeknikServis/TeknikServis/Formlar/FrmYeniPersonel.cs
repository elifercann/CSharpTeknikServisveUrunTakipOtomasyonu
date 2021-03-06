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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.tblDepartman
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.Ad
                                                 }).ToList();
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

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
