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
    public partial class FrmArizaUrunDetayListesi : Form
    {
        public FrmArizaUrunDetayListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaUrunDetayListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.tblUrunTakip
                                      select new
                                      {
                                          x.TakipId,
                                          x.SeriNo,
                                          x.Tarih,
                                          x.Açıklama
                                      }).ToList();
        }
    }
}
