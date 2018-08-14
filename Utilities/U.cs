using IronOcr;
using System;
using System.Drawing;

namespace Utilities
{
    public static class U
    {
        private static readonly AutoOcr _ocr = new AutoOcr();

        public static string Recognize(string imagePath)
        {
            var result = _ocr.Read(imagePath);
            return result.Text;
        }

        public static string Recognize(Image image)
        {
            var result = _ocr.Read(image);
            return result.Text;
        }

        public static TimeSpan Profile(Action action)
        {
            var start = DateTime.Now;
            action();
            var end = DateTime.Now;
            
            return end - start;
        }
    }
}
