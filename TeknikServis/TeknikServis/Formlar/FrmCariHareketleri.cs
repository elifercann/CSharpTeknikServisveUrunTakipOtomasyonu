using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TeknikServis.Formlar
{
    public partial class FrmCariHareketleri : Form
    {
        public FrmCariHareketleri()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbTeknikServis;Integrated Security=True");

        private void FrmCariHareketleri_Load(object sender, EventArgs e)
        {


            var degerler = from x in db.tblCari
                           select new
                           {
                               x.Id,
                               x.Ad,
                               x.Soyad,
                               x.İl,
                               x.İlçe
                           };

            gridControl1.DataSource = degerler.ToList();


            gridControl2.DataSource = db.tblCari.OrderBy(x => x.İl).GroupBy(y => y.İl).Select(z => new
            {
                İl = z.Key,
                Toplam = z.Count()
            }).ToList();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select İl,Count(*) FROM tblCari group by İl", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

    }
}
