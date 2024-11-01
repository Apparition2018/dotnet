using System.Text;
using ThoughtWorks.QRCode.Codec;
using WinForms_Demo.Properties;

namespace WinForms_Demo.Exercise.QRCodeAndVCard;
public class QRCodeCreator
{
    /// <summary>
    /// 根据名片数据生成 vCard 字符串
    /// </summary>
    private string GetCodeInfo(Card card)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("BEGIN:VCARD");
        sb.Append("\r\nFN:" + card.Name);
        sb.Append("\r\nTITLE:" + card.Post);
        sb.Append("\r\nORG:" + card.Company + ";" + card.Department);
        sb.Append("\r\nTEL;CELL:" + card.MobilePhone);
        sb.Append("\r\nTEL;WORK:" + card.Telephone);
        sb.Append("\r\nADR;WORK:" + card.Address);
        sb.Append("\r\nURL:" + card.Url);
        sb.Append("\r\nEMAIL:" + card.Email);
        sb.Append("\r\nPHOTO;ENCODING=b;TYPE=JPEG:");
        sb.Append("\r\nEND:VCARD\r\n");
        return card.ToString() ?? string.Empty  ;
    }

    /// <summary>
    /// 根据名片信息和指定图片大小生成二维码图片
    /// </summary>
    public Bitmap CreateQRCodeImage(Card card, int imageWith, int imageHeight)
    {
        string cardString = GetCodeInfo(card);

        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder
        {
            QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
            QRCodeScale = 9,
            QRCodeVersion = 0,
            QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M
        };
        Image image = qrCodeEncoder.Encode(cardString, Encoding.GetEncoding("UTF-8"));

        Image logo = Resources.Icon_Image;

        Bitmap bmp = new Bitmap(imageWith, imageHeight);
        Graphics g = Graphics.FromImage(bmp);
        g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
        g.DrawImage(image, new Point((imageWith - image.Width) / 2, (imageHeight - image.Height) / 2));
        g.DrawImage(logo, new Point((imageWith - logo.Width) / 2, (imageHeight - logo.Height) / 2));

        return bmp;
    }
}
