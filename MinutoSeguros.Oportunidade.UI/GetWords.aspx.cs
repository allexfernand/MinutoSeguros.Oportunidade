using MinutoSeguros.Oportunidade.Application;
using System;
using System.Linq;
using System.Data;

namespace MinutoSeguros.Oportunidade.UI
{
    public partial class GetWords : System.Web.UI.Page
    {
        private WordsApplications wordApp = new WordsApplications();
        private XmlApplications xmlApp = new XmlApplications();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGetWords_Click(object sender, EventArgs e)
        {
            var document = xmlApp.GetXml();

            GViewResult.DataSource = wordApp.GetListWord(document).Select(s => new { Palavra = s.word, Contador = s.count }).Take(10);
            GViewTopics.DataSource = wordApp.GetTopics(document).Select(s => new { Tópico = s.Key, Quantidade = s.Value }).Take(10);

            GViewResult.DataBind();
            GViewTopics.DataBind();
        }
    }


}