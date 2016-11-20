using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ZapCharts.Model.Transiente.Grabber;
using static ZapCharts.Model.Transiente.Grabber.GrabberReportXml;
namespace ZapCharts.Util {
    public class ConversorGrabberXmlObjectoComplexo {
        public static GrabberReportXml Converter(string CaminhoXml) {
            List<string> url = new List<string>();
            var GrabberReportXml = new GrabberReportXml();
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xssnode, sqlnode;
            FileStream fs = new FileStream(CaminhoXml,FileMode.Open,FileAccess.Read);
            xmldoc.Load(fs);

            sqlnode = xmldoc.GetElementsByTagName("sql");
            xssnode = xmldoc.GetElementsByTagName("xss");

            if(xssnode.Count > 0) {
                var descricaoXSS = xssnode[0].Name;
                var quantidadeXSS = xssnode.Count;
                for(int i = 0;i <= xssnode.Count - 1;i++) {
                    for(int j = 0;j <= xssnode[i].ChildNodes.Count - 1;j++) {
                        if(xssnode[i].ChildNodes[j].Name.Trim() == "result") {
                            url.Add(xssnode[i].ChildNodes[j].InnerText);
                        }
                    }
                }
                GrabberReportXml.Alertas.Add(new Alerta() {
                    NomeAlerta = descricaoXSS,
                    QtdOcorrencias = Convert.ToInt32(quantidadeXSS),
                    Uris = url,
                });
            }
            if(sqlnode.Count > 0) {
                var descricaoSQL = sqlnode[0].Name;
                var quantidadeSQL = sqlnode.Count;
                for(int i = 0;i <= sqlnode.Count - 1;i++) {
                    for(int j = 0;j <= sqlnode[i].ChildNodes.Count - 1;j++) {
                        if(sqlnode[i].ChildNodes[j].Name.Trim() == "result") {
                            url.Add(sqlnode[i].ChildNodes[j].InnerText);
                        }
                    }
                }
                GrabberReportXml.Alertas.Add(new Alerta() {
                    NomeAlerta = descricaoSQL,
                    QtdOcorrencias = Convert.ToInt32(quantidadeSQL),
                    Uris = url,
                });
            }
            fs.Close();
            return GrabberReportXml;
        }
    }
}
