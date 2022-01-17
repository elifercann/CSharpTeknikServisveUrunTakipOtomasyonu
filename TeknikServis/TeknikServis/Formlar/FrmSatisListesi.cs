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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmSatisLisetsi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.tblUrunHareket
                           select new
                           {
                               x.HareketId,
                               x.tblUrun.Ad,
                               Musteri = x.tblCari.Ad+" "+ x.tblCari.Soyad,
                               Personel = x.tblPersonel.Ad + " "+ x.tblPersonel.Soyad,
                               x.Tarih,
                               x.Adet,
                               x.Fiyat,
                               x.ÜrünSeriNo
                           };
            gridControl1.DataSource = degerler.ToList();

        }
    }
}
