using MinutoSeguros.Oportunidade.Domain;
using MinutoSeguros.Oportunidade.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace MinutoSeguros.Oportunidade.Application
{
    public class XmlApplications
    {
        private XmlDAL xmlDal = new XmlDAL();

        public XDocument GetXml() => xmlDal.GetXml();

        public List<FeedNews> GetListFeedNews(XDocument xDocument)
        {
            return xDocument.Descendants("item").Select(x => new FeedNews
            {
                Description = x.Element("description").Value.ToString().TrimStart().Substring(3, x.Element("description").Value.IndexOf("&#8230;") - 3),
                Title = x.Element("title").Value

            }).ToList();
        }



    }
}
