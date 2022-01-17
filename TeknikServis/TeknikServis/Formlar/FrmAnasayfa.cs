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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.tblUrun
                                       select new
                                       {
                                           x.Ad,
                                           x.Marka,
                                           x.Stok
                                       }).Where(x => x.Stok < 30).ToList();

            gridControl2.DataSource = (from y in db.tblCari
                                       select new
                                       {
                                           y.Ad,
                                           y.Soyad,
                                           y.İl
                                       }).ToList();

            gridControl3.DataSource = db.urunkategori().ToList();

            DateTime bugun = DateTime.Today;
            var deger = (from x in db.tblNotlar.OrderBy(y => y.Id)
                         where (x.Tarih == bugun)
                         select new
                         {
                             x.Baslik,
                             x.İcerik
                         });
            gridControl4.DataSource = deger.ToList();
        }

       
    }
}
