using System.Configuration;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MinutoSeguros.Oportunidade.DAL
{
    public class XmlDAL
    {
        public XDocument GetXml()
        {
            var urlPath = string.Empty;
            var result = string.Empty;
            if (ConfigurationManager.AppSettings["UsingMock"] == "Y")
            {
                urlPath = ConfigurationManager.AppSettings["UrlMock"] ;
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(urlPath);
                result = xmlDoc.InnerXml;                  
            }
            else
            {
                urlPath = ConfigurationManager.AppSettings["UrlPath"];
                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                result = webClient.DownloadString(urlPath);
            }

            return XDocument.Parse(result);
        }
    }
}
