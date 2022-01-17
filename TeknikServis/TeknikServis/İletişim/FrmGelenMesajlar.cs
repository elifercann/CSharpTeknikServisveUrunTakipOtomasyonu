using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.İletişim
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl12.Text = db.tblIletisim.Count().ToString();
            labelControl14.Text = db.tblIletisim.Where(x => x.Konu == "Teşekkür").Count().ToString();
            labelControl16.Text = db.tblIletisim.Where(x => x.Konu == "Rica").Count().ToString();
            labelControl18.Text = db.tblIletisim.Where(x => x.Konu == "Şikayet").Count().ToString();

            gridControl1.DataSource = (from x in db.tblIletisim
                                    select new
                                    {
                                        x.Id,
                                        x.Mail,
                                        x.Konu,
                                        x.Mesaj

                                    }).ToList();
        }
    }
}
