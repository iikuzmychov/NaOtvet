using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NaOtvet
{
    public static class HelpClass
    {
        public static bool IsUserAdministrator()
        {
            try
            {
                var user = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        public static IPAddress GetMyIp()
        {
            string[] services = new string[]
            {
                "https://ipv4.icanhazip.com",
                "https://api.ipify.org",
                "https://ipinfo.io/ip",
                "https://checkip.amazonaws.com",
                "https://wtfismyip.com/text",
                "http://icanhazip.com"
            };

            using (var webclient = new WebClient())
            {
                foreach (var service in services)
                {
                    try
                    {
                        return IPAddress.Parse(webclient.DownloadString(service));
                    }
                    catch { }
                }
            }

            return null;
        }

        public static bool IsInternetConnectionAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static Image DownloadImage(string url)
        {
            var stream = DownloadImageAsStream(url);

            using (stream)
            {
                return Image.FromStream(stream);
            }
        }
        public static Stream DownloadImageAsStream(string url)
        {
            byte[] data = new WebClient().DownloadData(url);
            var memoryStream = new MemoryStream(data);

            return memoryStream;
        }

        public static string HtmlToPlainText(string html)
        {
            if (html != null)
                return Regex.Replace(html, @"<[^>]*>", "");
            else
                return null;
        }

        public static string HtmlToSmartPlainText(string html)
        {
            string preparedHtml = html
                .Replace("</p>", "</p>" + Environment.NewLine);

            if (preparedHtml.EndsWith(Environment.NewLine))
                preparedHtml = preparedHtml.Remove(preparedHtml.Length - Environment.NewLine.Length);

            return HtmlToPlainText(preparedHtml);
        }

        public static decimal PointsToSystem(decimal points, decimal oldSystem, int newSystem)
        {
            return points * newSystem / oldSystem;
        }

        public static TextFormatFlags TextAlignToFormatFlags(ContentAlignment align)
        {
            switch (align)
            {
                case ContentAlignment.MiddleCenter:
                    return TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                case ContentAlignment.BottomCenter:
                    return TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom;
                case ContentAlignment.BottomLeft:
                    return TextFormatFlags.Left | TextFormatFlags.Bottom;
                case ContentAlignment.BottomRight:
                    return TextFormatFlags.Right | TextFormatFlags.Bottom;
                case ContentAlignment.MiddleLeft:
                    return TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                case ContentAlignment.MiddleRight:
                    return TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                case ContentAlignment.TopCenter:
                    return TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.TopLeft:
                    return TextFormatFlags.Top | TextFormatFlags.Left;
                case ContentAlignment.TopRight:
                    return TextFormatFlags.Top | TextFormatFlags.Right;
            }

            return TextFormatFlags.HorizontalCenter | TextFormatFlags.Top;
        }

        public static TextFormatFlags HorizontalAlignToFormatFlags(HorizontalAlignment align)
        {
            switch (align)
            {
                case HorizontalAlignment.Center:
                    return TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                case HorizontalAlignment.Left:
                    return TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                case HorizontalAlignment.Right:
                    return TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
            }

            return TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
        }

        public static Color GetRandomColor()
        {
            var random = new Random();
            var red     = random.Next(256);
            var green   = random.Next(256);
            var blue    = random.Next(256);

            return Color.FromArgb(red, green, blue);
        }

        public static Color GetRandomLightColor()
        {
            var random = new Random();

            var red     = random.Next(150, 256);
            var green   = random.Next(150, 256);
            var blue    = random.Next(150, 256);

            return Color.FromArgb(red, green, blue);
        }
    }
}
