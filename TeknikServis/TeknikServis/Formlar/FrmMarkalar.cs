using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.tblUrun.OrderBy(x => x.Marka).GroupBy(y => y.Marka).Select(z => new
            {

                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl3.Text = db.tblUrun.Count().ToString();
            labelControl1.Text = (from x in db.tblUrun
                                  select x.Marka).Distinct().Count().ToString();
            labelControl7.Text = (from x in db.tblUrun
                                  orderby x.SatışFiyatı descending
                                  select x.Marka).FirstOrDefault();
            labelControl9.Text = db.maksurunmarka().FirstOrDefault();
            //chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 5);
            //chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bosch", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Vestel", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("LG",5);
            //chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 5);

            SqlConnection baglanti = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=DbTeknikServis;integrated security=True;");
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Marka,count(*) from tblUrun group by Marka", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }

            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select tblKategori.Ad,COUNT(*) from tblUrun inner join tblKategori on tblKategori.Id = tblUrun.Kategori group by tblKategori.Ad ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));

            }

            baglanti.Close();



        }
    }
}
