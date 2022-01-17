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
    public partial class FrmDepartmanEkle : Form
    {
        public FrmDepartmanEkle()
        {
            InitializeComponent();
        }


        DbTeknikServisEntities db = new DbTeknikServisEntities();
     
        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            tblDepartman t = new tblDepartman();
            t.Ad = txtAd.Text;
            db.tblDepartman.Add(t);
            db.SaveChanges();
            MessageBox.Show("Departman Eklendi");
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
