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
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            tblUrunTakip t = new tblUrunTakip();
            t.Açıklama = richTextBox1.Text;
            t.SeriNo = txtSeriNo.Text;
            t.Tarih = DateTime.Parse(txtTarih.Text);
            db.tblUrunTakip.Add(t);
            db.SaveChanges();

            tblUrunKabul tt= new tblUrunKabul();
            int urunid = int.Parse(id.ToString());
            var deger = db.tblUrunKabul.Find(urunid);
            deger.ÜrünDurumDetay = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayları Güncellendi");
        }
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            txtSeriNo.Text = "";
        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string id,serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
            txtSeriNo.Text = serino;
        }
    }
}
