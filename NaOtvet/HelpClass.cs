using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text.RegularExpressions;

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
            byte[] data = new WebClient().DownloadData(url);

            using (var memoryStream = new MemoryStream(data))
            {
                return Image.FromStream(memoryStream);
            }
        }

        public static string HtmlToPlainText(string html)
        {
            if (html != null)
                return Regex.Replace(html, @"<[^>]*>", "");
            else
                return null;
        }

        public static decimal PointsToSystem(decimal points, decimal oldSystem, int newSystem)
        {
            return points * newSystem / oldSystem;
        }
    }
}
