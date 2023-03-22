namespace KinoPlus.WinUI.Utils
{
    public static class ImageUtility
    {
        public static Image? Base64ToImage(string base64String, int width, int height)
        {
            if (string.IsNullOrEmpty(base64String)) return null;

            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            return resizeImage(image, new Size(width, height));
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
