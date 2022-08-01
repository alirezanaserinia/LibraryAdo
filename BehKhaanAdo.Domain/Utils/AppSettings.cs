using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Domain.Utils
{
    public static class AppSettings
    {
        private const string APP_SETTINGS_PATH = @"C:\Users\Alireza\Desktop\ASA\BehKhaanAdo\BehKhaanAdo.Domain\Utils\appsettings.json";
        public static string GetDefaultConnectionString()
        {
            JObject json = JObject.Parse(File.ReadAllText(APP_SETTINGS_PATH));
            var defaultConnectionString = json["ConnectionStrings"]["DefaultConnectionString"];
            return defaultConnectionString.ToString();
        }
        public static string GetServerConnectionString()
        {
            JObject json = JObject.Parse(File.ReadAllText(APP_SETTINGS_PATH));
            var serverConnectionString = json["ConnectionStrings"]["ServerConnectionString"];
            return serverConnectionString.ToString();
        }
    }
}
