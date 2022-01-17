using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.tblUrunKabul
                           select new
                           {
                               x.IslemId,
                               Cari = x.tblCari.Ad + " "+ x.tblCari.Soyad,
                               Personel = x.tblPersonel.Ad +" "+ x.tblPersonel.Soyad,
                               x.GelisTarihi,
                               x.CikisTarihi,
                               x.ÜrünSeriNo,
                               x.ÜrünDurumDetay
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl1.Text = db.tblUrunKabul.Count(x => x.ÜrünDurum == true).ToString();
            labelControl9.Text = db.tblUrunKabul.Count(x => x.ÜrünDurum == false).ToString();
            labelControl13.Text = db.tblUrun.Count().ToString();
            labelControl7.Text = db.tblUrunKabul.Count(x => x.ÜrünDurumDetay == "Parça Bekliyor").ToString();
            labelControl11.Text = db.tblUrunKabul.Count(x => x.ÜrünDurumDetay == "Mesaj Bekliyor").ToString();
            labelControl16.Text = db.tblUrunKabul.Count(x => x.ÜrünDurumDetay == "İptal Bekliyor").ToString();

            SqlConnection baglanti = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=DbTeknikServis;integrated security=True;");
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select ÜrünDurumDetay,count(*) from tblUrunKabul group by ÜrünDurumDetay", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }

            baglanti.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("İslemId").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("ÜrünSeriNo").ToString();
            fr.Show();
        }
    }
}
