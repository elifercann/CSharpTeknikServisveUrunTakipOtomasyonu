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
    public partial class FrmUrunAra : Form
    {
        public FrmUrunAra()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        
        private void btnAra_Click(object sender, EventArgs e)
        {
            //tblUrun t = new tblUrun();
            string marka = Convert.ToString(txtMarka.Text);
           
            //t.Kategori = byte.Parse(lookUpEdit1.Text);

            var degerler = (from u in db.tblUrun
                            select new
                            {
                                u.Id,
                                u.Ad,
                                u.Marka,
                                u.Kategori,
                                u.Stok
                            }).Where( x=>x.Marka==marka);

            gridControl1.DataSource = degerler.ToList();
        }
    }
}
