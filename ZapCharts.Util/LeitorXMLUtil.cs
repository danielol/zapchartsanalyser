using System.IO;
using System.Xml;


namespace ZapCharts.Util
{
    public static class LeitorXMLUtil
    {
        public static object[] LerXmlVulnerabilidade(string path)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("alertitem");
            object[] dados = new object[xmlnode.Count];
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                var descricaoAlerta = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                var qtdeOcorrencias = xmlnode[i].ChildNodes.Item(8).InnerText.Trim();
                dados[i] = new object[] { descricaoAlerta, qtdeOcorrencias };
            }
            fs.Close();
            return dados;
        }
    }
}
