using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZapCharts.Model.Transiente.Zap2._5._0;

namespace ZapCharts.Util
{
    public class ConversorXmlObjectoComplexo
    {
        public static ZapReportXml Converter(string CaminhoXml)
        {
            var zapReportXml = new ZapReportXml();
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(CaminhoXml, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);

            xmlnode = xmldoc.GetElementsByTagName("site");
            zapReportXml.NomeSite = xmlnode[0].Attributes["host"].Value;

            xmlnode = xmldoc.GetElementsByTagName("alertitem");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                var descricaoAlerta = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                var qtdeOcorrencias = xmlnode[i].ChildNodes.Item(8).InnerText.Trim();
                var solucao= xmlnode[i].ChildNodes.Item(9).InnerText.Trim();

                var codRisco = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());
                var outrasInfo = xmlnode[i].ChildNodes.Item(10).InnerText.Trim();
                var referencias = xmlnode[i].ChildNodes.Item(11).InnerText.Trim();
                var descRisco = xmlnode[i].ChildNodes.Item(5).InnerText.Trim();

                zapReportXml.Alertas.Add(new Alerta()
                {
                    NomeAlerta = descricaoAlerta,
                    QtdOcorrencias = Convert.ToInt32(qtdeOcorrencias),
                    Solucao = solucao,
                    codioRisco = codRisco,
                    Descricao = descricaoAlerta,
                    OutraInformacao= outrasInfo,
                    Referencia = referencias,
                    DescricaoRisco = descRisco
                    //tem q ver uris
                });
            }
            fs.Close();
            return zapReportXml;
        }
    }
}
