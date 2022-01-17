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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" && txtAd.Text.Length <= 30)
            {
                tblKategori t = new tblKategori();
                t.Ad = txtAd.Text;
                db.tblKategori.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Lütfen karakter sayısını 0 ile 30 arasında giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
