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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.tblUrun.Count().ToString();
            labelControl3.Text = db.tblKategori.Count().ToString();
            labelControl5.Text = db.tblUrun.Sum(x => x.Stok).ToString();
            labelControl7.Text = "10";
            labelControl17.Text = (from x in db.tblUrun
                                   orderby x.Stok descending
                                   select x.Ad).FirstOrDefault();
            labelControl15.Text = (from x in db.tblUrun
                                   orderby x.Stok ascending
                                   select x.Ad).FirstOrDefault();
            labelControl11.Text = (from x in db.tblUrun
                                   orderby x.SatışFiyatı descending
                                   select x.Ad).FirstOrDefault();
            labelControl19.Text = (from x in db.tblUrun
                                   orderby x.SatışFiyatı ascending
                                   select x.Ad).FirstOrDefault();
            labelControl27.Text = db.tblUrun.Count(x => x.Kategori == 4).ToString();
            labelControl23.Text = db.tblUrun.Count(x => x.Kategori == 1).ToString();
            labelControl21.Text = db.tblUrun.Count(x => x.Kategori == 3).ToString();
            labelControl39.Text = (from x in db.tblUrun
                                   select x.Marka).Distinct().Count().ToString();

            labelControl33.Text = db.tblUrunKabul.Count().ToString();
            labelControl13.Text = db.makskategoriurun().FirstOrDefault();

            var urunufazlaolanmarka = from x in db.tblUrun

                                      group x by x.Marka into y

                                      select new

                                      {

                                          name = y.Key,

                                          count = y.Count()

                                      };
            labelControl37.Text = (from x in db.tblUrun

                                   group x by x.Marka into y
                                   select new
                                   {
                                       name = y.Key,
                                       count = y.Count()

                                   }).OrderByDescending(x => x.count).Select(x => x.name).FirstOrDefault().ToString();
        }
    }
}
