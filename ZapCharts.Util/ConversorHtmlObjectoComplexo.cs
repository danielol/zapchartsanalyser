using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapCharts.Model.Transiente.IronWasp;

namespace ZapCharts.Util
{
    public class ConversorHtmlObjectoComplexo
    {
        public static IronWaspReportHtml Converter(string CaminhoHtml)
        {
            var DescricaoVuln = "";
            var gravidadeVuln = "";
            var IronWaspReportHtml = new IronWaspReportHtml();
            int count = 0;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;

            FileStream fs = new FileStream(CaminhoHtml, FileMode.Open, FileAccess.Read);
            htmlDoc.Load(fs);


            var Node = htmlDoc.DocumentNode.SelectNodes("//ul");
            var Node2 = htmlDoc.DocumentNode.SelectNodes("//div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("low_finding_title")
                | d.Attributes["class"].Value.Contains("medium_finding_title") | d.Attributes["class"].Value.Contains("high_finding_title") | d.Attributes["class"].Value.Contains("desc")
                | d.Attributes["class"].Value.Contains("severity"));                     //[contains(@class,'listevent')");
            //var Node2 = htmlDoc.DocumentNode.SelectNodes("//*[@class= desc]");
            for (int i = 0; i <= Node.Count - 1; i++)
            {
                for (int j = 0; j <= Node[i].ChildNodes.Count - 1; j++)
                {
                    if (Node[i].ChildNodes[j].Name.Equals("li"))
                    {
                        if (Node[i].ChildNodes[j].InnerHtml.Substring(33, 3).Equals("icr") | Node[i].ChildNodes[j].InnerHtml.Substring(34, 3).Equals("icr")
                          | Node[i].ChildNodes[j].InnerHtml.Substring(35, 3).Equals("icr") | Node[i].ChildNodes[j].InnerHtml.Substring(36, 3).Equals("icr")
                          | Node[i].ChildNodes[j].InnerHtml.Substring(33, 3).Equals("ico") | Node[i].ChildNodes[j].InnerHtml.Substring(34, 3).Equals("ico")
                          | Node[i].ChildNodes[j].InnerHtml.Substring(35, 3).Equals("ico") | Node[i].ChildNodes[j].InnerHtml.Substring(36, 3).Equals("ico")
                          | Node[i].ChildNodes[j].InnerHtml.Substring(33, 3).Equals("icy") | Node[i].ChildNodes[j].InnerHtml.Substring(34, 3).Equals("icy")
                          | Node[i].ChildNodes[j].InnerHtml.Substring(35, 3).Equals("icy") | Node[i].ChildNodes[j].InnerHtml.Substring(36, 3).Equals("icy"))
                        {
                            count++;
                        }
                    }
                }
            }
            object[] dadosGraficoPizzaIron = new object[count];

            if (htmlDoc.DocumentNode != null)
            {

                if (Node != null)
                {
                    int ret = 0;
                    int h = 0;
                    for (int i = 0; i <= Node.Count - 1; i++)
                    {

                        for (int j = 0; j <= Node[i].ChildNodes.Count - 1; j++)
                        {



                            if (Node[i].ChildNodes[j].Name.Equals("ol"))
                            {
                                if (Node[i].ChildNodes[j - 2].InnerHtml.Substring(33, 3).Equals("icr") | Node[i].ChildNodes[j - 2].InnerHtml.Substring(34, 3).Equals("icr")
                                    | Node[i].ChildNodes[j - 2].InnerHtml.Substring(35, 3).Equals("icr") | Node[i].ChildNodes[j - 2].InnerHtml.Substring(36, 3).Equals("icr")
                                    | Node[i].ChildNodes[j - 2].InnerHtml.Substring(33, 3).Equals("ico") | Node[i].ChildNodes[j - 2].InnerHtml.Substring(34, 3).Equals("ico")
                                    | Node[i].ChildNodes[j - 2].InnerHtml.Substring(35, 3).Equals("ico") | Node[i].ChildNodes[j - 2].InnerHtml.Substring(36, 3).Equals("ico")
                                    | Node[i].ChildNodes[j - 2].InnerHtml.Substring(33, 3).Equals("icy") | Node[i].ChildNodes[j - 2].InnerHtml.Substring(34, 3).Equals("icy")
                                    | Node[i].ChildNodes[j - 2].InnerHtml.Substring(35, 3).Equals("icy") | Node[i].ChildNodes[j - 2].InnerHtml.Substring(36, 3).Equals("icy"))
                                {

                                    if (Node[i].ChildNodes[j - 2].Name.Equals("li"))
                                    {

                                        var descricaoAlerta = Node[i].ChildNodes[j - 2].InnerText;

                                        var qtdeOcorrencias = Node[i].ChildNodes[j].LastChild.Line - Node[i].ChildNodes[j].Line;


                                        dadosGraficoPizzaIron[ret] = new object[] { descricaoAlerta, qtdeOcorrencias };
                                        ret++;
                                        
                                        foreach(HtmlNode value in Node2)
                                        {
                                            var Vulnerabilidade = Node2.Skip(h).First().InnerText;
                                            if (descricaoAlerta.Equals(Vulnerabilidade)) {
                                                gravidadeVuln = Node2.Skip(h + 1).First().InnerText;
                                                DescricaoVuln = Node2.Skip(h + 2).First().InnerText;
                                                break;
                                            }
                                            h++;
                                        }

                                            IronWaspReportHtml.Alertas.Add(new Alerta()
                                        {

                                            NomeAlerta = descricaoAlerta,
                                            QtdOcorrencias = Convert.ToInt32(qtdeOcorrencias),
                                            DescricaoRisco = DescricaoVuln,
                                            Gravidade = gravidadeVuln

                                            });


                                    }
                                }
                            }
                        }
                    }
                }
            }
            fs.Close();
            return IronWaspReportHtml;
        }
    }
}
