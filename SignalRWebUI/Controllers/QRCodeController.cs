using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using ZXing.Windows.Compatibility;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.H);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }

            }
            return View();
        }

        public JsonResult IndexJson(string image)
        {
            var barcodeReader = new BarcodeReader();
            var BarcodeBitmap = (Bitmap)Bitmap.FromFile(image);
            var Result = barcodeReader.Decode(BarcodeBitmap);
            ViewBag.Barcode = Result.Text.ToString();
            ViewBag.BarcodeUrl = image;

            return Json("");
        }

    }
}
