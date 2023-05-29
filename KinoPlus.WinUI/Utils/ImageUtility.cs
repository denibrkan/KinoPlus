using eProdaja.WinUI;
using KinoPlus.WinUI.Properties;
using System.Net;

namespace KinoPlus.WinUI.Utils
{
    public static class ImageUtility
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }

        public static Image GetImageById(Guid id)
        {
            var url = Settings.Default.ApiUrl + "images/" + id;
            HttpWebRequest? httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + APIService.Token);

            using var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using Stream stream = httpWebReponse.GetResponseStream();

            return Image.FromStream(stream);
        }
    }
}
