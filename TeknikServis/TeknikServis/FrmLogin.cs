using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.tblAdmin where x.KullanıcıId == txtkullanıcı.Text & x.Sifre == txtsifre.Text select x;
            if (sorgu.Any())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtkullanıcı_Click(object sender, EventArgs e)
        {
            txtkullanıcı.Text = "";
        }

        private void txtsifre_Click(object sender, EventArgs e)
        {
            txtsifre.Text = "";
        }
    }
}
