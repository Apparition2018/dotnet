using ThoughtWorks.QRCode.Codec;

namespace WinForms_Demo.Exercise.Lottery.Models;

public class QRCodeCreator
{
    #region 根据链接生成二维码

    /// <summary>
    /// 根据链接获取二维码
    /// </summary>
    /// <param name="url">链接</param>
    /// <returns>返回二维码图片</returns>
    public static Image GetQRCodeBmp(string url)
    {
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder
        {
            QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
            QRCodeScale = 4,
            QRCodeVersion = 0,
            QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M
        };
        return qrCodeEncoder.Encode(url);
    }

    #endregion
}
