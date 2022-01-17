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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            tblUrunKabul t = new tblUrunKabul();
            t.Cari = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Personel = short.Parse(lookUpEdit2.EditValue.ToString());
            t.GelisTarihi = DateTime.Parse(txtTarih.Text);
            t.ÜrünSeriNo = txtSeriNo.Text;
            t.ÜrünDurumDetay = "Ürün kaydoldu";
            db.tblUrunKabul.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Kaydı Oluşturuldu");
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.tblCari
                                                 select new
                                                 {
                                                     x.Id,
                                                     AD=x.Ad+" "+x.Soyad
                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in db.tblPersonel
                                                 select new
                                                 {
                                                     x.Id,
                                                     AD=x.Ad + " "+ x.Soyad
                                                 }).ToList();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
