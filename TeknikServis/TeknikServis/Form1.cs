using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Formlar.FrmUrunListesi fr3;
        private void btnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmUrunListesi();
                fr3.MdiParent = this;
                fr3.Show();

            };
        }

        private void btnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.YeniUrun fr = new Formlar.YeniUrun();
            fr.Show();
        }

        Formlar.FrmKategori fr2;
        private void btnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (fr2 == null || fr2.IsDisposed)
            { 
                fr2 = new Formlar.FrmKategori();
                fr2.MdiParent = this;
                fr2.Show();

            }

        }

        private void btnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            fr.Show();
        }

        Formlar.Frmİstatistik fr4;
        private void btnİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(fr4==null || fr4.IsDisposed)
            {
                fr4 = new Formlar.Frmİstatistik();
                fr4.MdiParent = this;
                fr4.Show();
            }
            
        }

        Formlar.FrmMarkalar fr5;
        private void btnMarkaİst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmMarkalar();
                fr5.MdiParent = this;
                fr5.Show();
            }

        }

        Formlar.FrmCariListesi fr7;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmCariListesi();
                fr7.MdiParent = this;
                fr7.Show();

            }
        }

        Formlar.FrmCariIl fr8;
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmCariIl();
                fr8.MdiParent = this;
                fr8.Show();

            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariEkle fr = new Formlar.FrmCariEkle();
            fr.Show();
        }

        Formlar.FrmDepartman fr9;
        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmDepartman();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }


        Formlar.FrmPersonel fr11;
        private void btnPersonelListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmPersonel();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        private void btnHesapMak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        Formlar.FrmKurlar fr13;
        private void btnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Formlar.FrmKurlar();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }
        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        Formlar.FrmYoutube fr14;
        private void btnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmYoutube();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        Formlar.FrmNotlar fr12;
        private void btnAjanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmNotlar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        Formlar.FrmArizaListesi fr6;
        private void btnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmArizaListesi();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        private void btnUrunSatisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatis fr = new Formlar.FrmUrunSatis();
            fr.Show();
        }

        Formlar.FrmSatisListesi fr15;
        private void btnSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmSatisListesi();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
        private void btnArizaKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunKaydi fr = new Formlar.FrmArizaliUrunKaydi();
            fr.Show();
        }

        private void btnArizaAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaDetaylar fr = new Formlar.FrmArizaDetaylar();
            fr.Show();
        }
       
        private void btnArizaUrunDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaUrunDetayListesi fr = new Formlar.FrmArizaUrunDetayListesi();
           
                fr.MdiParent = this;
                fr.Show();
            
        }

        private void btnQr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRCode fr = new Formlar.FrmQRCode();
            //fr.MdiParent = this;
            fr.Show();

        }

        Formlar.FrmFaturaListesi fr17;
        private void btnFaturalistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmFaturaListesi();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }
        private void btnFaturaKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalem fr = new Formlar.FrmFaturaKalem();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnFaturaDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalemDetay fr = new Formlar.FrmFaturaKalemDetay();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGauge fr = new Formlar.FrmGauge();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.FrmHaritalar fr = new Formlar.FrmHaritalar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRapor fr = new Formlar.FrmRapor();
            fr.Show();
        }

        Formlar.FrmAnasayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();

                fr.MdiParent = this;
                fr.Show();
            }
        }


        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();

                fr.MdiParent = this;
                fr.Show();
            }
        }

        İletişim.FrmRehber fr18;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new İletişim.FrmRehber();
                
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        İletişim.FrmGelenMesajlar fr19;
        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new İletişim.FrmGelenMesajlar();

                fr19.MdiParent = this;
                fr19.Show();
            }
        }

        private void btnMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            İletişim.FrmMail fr = new İletişim.FrmMail();
            fr.Show();
        }
        Formlar.FrmUrunAra fr20;
        private void btnUrunAra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr20.IsDisposed)
            {
                fr20 = new Formlar.FrmUrunAra();
                fr20.MdiParent = this;
                fr20.Show();
            }
        }

        
        private void btnBarkod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmBarkod fr = new Formlar.FrmBarkod();
            fr.Show();
        }

        Formlar.FrmCariHareketleri fr21;
        private void btnCariHareketleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr21==null|| fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmCariHareketleri();
                fr21.MdiParent = this;
                fr21.Show();
            }
        }

        private void btnYeniFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniFatura fr = new Formlar.FrmYeniFatura();
            fr.Show();
        }

        private void btnYeniPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniPersonel fr = new Formlar.FrmYeniPersonel();
            fr.Show();
        }

        private void btnYeniNot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.FrmYeniNot fr = new Formlar.FrmYeniNot();
            fr.Show();
        }

        private void btnDepartmanEkle_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.FrmDepartmanEkle fr = new Formlar.FrmDepartmanEkle();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}

