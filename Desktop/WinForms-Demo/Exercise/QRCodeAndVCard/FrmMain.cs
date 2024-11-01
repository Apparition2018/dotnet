using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Demo.Exercise.QRCodeAndVCard
{
    public partial class FrmMain : Form
    {
        private QRCodeCreator qrCodeCreator = new QRCodeCreator();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Card card = new Card
            {
                Name = tbName.Text.Trim(),
                Post = tbPost.Text.Trim(),
                Department = tbDepartment.Text.Trim(),
                Company = tbCompany.Text.Trim(),
                Address = tbAddress.Text.Trim(),
                MobilePhone = tbMobilePhone.Text.Trim(),
                Telephone = tbTelephone.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                Url = tbUrl.Text.Trim(),
            };
            pbQRCode.Image = qrCodeCreator.CreateQRCodeImage(card, pbQRCode.Width, pbQRCode.Height);
        }
    }
}
