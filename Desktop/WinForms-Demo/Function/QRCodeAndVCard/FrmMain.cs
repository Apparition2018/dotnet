using WinForms_Demo.Function.QRCodeAndVCard.Model;
using WinForms_Demo.Function.QRCodeAndVCard.Util;

namespace WinForms_Demo.Function.QRCodeAndVCard
{
    public partial class FrmMain : Form
    {
        private readonly QRCodeCreator _qrCodeCreator = new();
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
            pbQRCode.Image = _qrCodeCreator.CreateQRCodeImage(card, pbQRCode.Width, pbQRCode.Height);
        }
    }
}
