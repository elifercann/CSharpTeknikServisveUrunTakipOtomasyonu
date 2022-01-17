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
    public partial class FrmFaturaKalemDetay : Form
    {
        public FrmFaturaKalemDetay()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            
            var degerler = (from u in db.tblFaturaDetay
                           select new
                           {
                               u.FaturaDetayId,
                               u.Urun,
                               u.Adet,
                               u.Fiyat,
                               u.Tutar,
                               u.FaturaId,
                           }).Where(x=>x.FaturaId==id);
            
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
