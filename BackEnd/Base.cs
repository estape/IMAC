using System;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;

namespace IMAC.BackEnd
{
    class Base
    {
        public static string BuildUrl(string lati, string longi)
        {
            string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IMAC/config.cfg");
            string baseUrl = "http://worldsatdobrasil.ddns.net:8081/cobertura_gsm/claro.php";
            string operadora = "169094";
            string ParamChar = "&";

            string url = $"{baseUrl}?operadora={operadora}{ParamChar}latitude={lati}{ParamChar}longitude={longi}";

            return url;
        }
    }
}
