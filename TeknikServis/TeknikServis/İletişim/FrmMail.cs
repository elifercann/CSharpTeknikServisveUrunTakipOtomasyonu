using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace TeknikServis.İletişim
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            string frommail = "gonderici";
            string password = "sifre";
            string alici = txtalici.Text;
            string konu = txtkonu.Text;
            string icerik = txticerik.Text;
            mail.From = new MailAddress(frommail);
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(frommail, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            MessageBox.Show("Mail gönderildi");
        }

        private void txtalici_Click(object sender, EventArgs e)
        {
            txtalici.Text = "";
        }

        private void txtkonu_Click(object sender, EventArgs e)
        {
            txtkonu.Text = "";
        }

        private void txticerik_Click(object sender, EventArgs e)
        {
            txticerik.Text = "";
        }
    }
}
