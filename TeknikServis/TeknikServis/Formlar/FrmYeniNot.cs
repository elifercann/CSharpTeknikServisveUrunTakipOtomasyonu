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
    public partial class FrmYeniNot : Form
    {
        public FrmYeniNot()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tblNotlar t = new tblNotlar();
            t.Baslik = txtBaslik.Text;
            t.İcerik = txtİcerik.Text;
            t.Durum = false;
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblNotlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
