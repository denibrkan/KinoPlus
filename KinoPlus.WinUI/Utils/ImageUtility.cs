using eProdaja.WinUI;
using System.Net;

namespace KinoPlus.WinUI.Utils
{
    public static class ImageUtility
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }

        public static Image GetImageFromUrl(string url)
        {
            HttpWebRequest? httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + APIService.Token);

            using var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using Stream stream = httpWebReponse.GetResponseStream();

            return Image.FromStream(stream);
        }
    }
}
