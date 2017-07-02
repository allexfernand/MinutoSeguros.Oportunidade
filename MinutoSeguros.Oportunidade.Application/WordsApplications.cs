using MinutoSeguros.Oportunidade.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MinutoSeguros.Oportunidade.Application
{
    public class WordsApplications
    {
        
        private char[] splites = new char[] { '.', '?', '!', ' ', ';', ':', ',' };
        private XmlApplications xmlApp = new XmlApplications();

        #region Public Methods
        public List<WordCount> GetListWord(XDocument document)
        {
          //  XDocument document = GetXmlApplication();

            var listFeedNews = new List<FeedNews>(xmlApp.GetListFeedNews(document));

            var preposition = new string[]
            {
             "a", "as", "ao", "aos", "à", "às",
             "e", "é", "em", "o", "os", "ou",
             "um", "uns", "uma", "umas",
             "da", "das", "de", "do", "dos",
             "dum", "duns", "duma", "dumas",
             "na", "nas", "no", "num", "numa",
             "numas", "por", "pelo", "pela",
             "pelas", "que", "com"
            };

            return new List<WordCount>(AddListWord(preposition, splites, listFeedNews));
        }

        public Dictionary<string, int> GetTopics(XDocument document)
        {
           // XDocument document = GetXml();

            var listFeedNews = new List<FeedNews>(xmlApp.GetListFeedNews(document));
            var listTopics = new Dictionary<string, int>(AddListTopics(splites, listFeedNews));

            return listTopics;
        }
        #endregion

        #region Private Methods
       
     
        private List<WordCount> AddListWord(string[] preposition, char[] splites, List<FeedNews> listFeedNews)
        {
            string[] words = { };

            foreach (FeedNews item in listFeedNews)
            {
                words = words.Concat(item.Description.ToLower().Split(splites, StringSplitOptions.RemoveEmptyEntries)).ToArray();
                words = words.Concat(item.Title.ToLower().Split(splites, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            }

            return words.Where(w => !preposition.Contains(w)).GroupBy(x => x).Select(s => new WordCount { word = s.Key, count = s.Count() }).OrderByDescending(o => o.count).ToList();
        }

        private Dictionary<string, int> AddListTopics(char[] splites, List<FeedNews> listFeedNews)
        {
            Dictionary<string, int> topics = new Dictionary<string, int>();
            int i = 1;

            foreach (FeedNews item in listFeedNews)
            {
                topics.Add("Tópico " + i, item.Description.ToLower().Split(splites, StringSplitOptions.RemoveEmptyEntries).Count() + item.Title.ToLower().Split(splites, StringSplitOptions.RemoveEmptyEntries).Count());
                i++;
            }
            return topics;
        }

        #endregion
    }

}
