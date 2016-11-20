using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using System.Collections.Generic;
using System.Web.Mvc;
using ZapCharts.Service.Interfaces;
using ZapCharts.Service.Services;
using ZapCharts.Service.Services.LineChart;
using ZapCharts.Util;
using ZapCharts.Views.ViewModel.Formulario;
using ZapCharts.Views.ViewModel.Grafico;

namespace ZapCharts.Controllers
{
    public class HomeController : Controller
    {
        IGraficoLinhasService _graficoLinhasService = new GraficoLinhasService();
        IGraficoPizzaService _graficoPizzaService = new GraficoPizzaService();


        public ActionResult Index()
        {
            return View(new FormularioInsercaoArquivoViewModel());
        }

        [HttpPost]
        public ActionResult Index(FormularioInsercaoArquivoViewModel formularioViewModel)
        {
            if (!formularioViewModel.Arquivo.FileName.EndsWith(".xml"))
            {
                //test
                ViewData["Mensagem"] = "O Arquivo deve ser no famato XML.";
                return View(formularioViewModel);
            }
            var caminhoENomeRepositorioArquivoTestes = "C:\\Users\\Altamir\\Desktop\\temp_zap_analise\\" + formularioViewModel.Arquivo.FileName;
            formularioViewModel.Arquivo.SaveAs(caminhoENomeRepositorioArquivoTestes);
            var dadosXml = ConversorXmlObjectoComplexo.Converter(caminhoENomeRepositorioArquivoTestes);
            #region geraDadoSGraficoPizza
            object[] dadosGraficoPizza = new object[dadosXml.Alertas.Count];
            for (int i = 0; i < dadosGraficoPizza.Length - 1; i++)
            {
                dadosGraficoPizza[i] = new object[] { dadosXml.Alertas[i].NomeAlerta, dadosXml.Alertas[i].QtdOcorrencias };
            }
            #endregion
            #region graficoPizza
            var grafico = new DotNet.Highcharts.Highcharts("grafico_pizza")
            .InitChart(new Chart { PlotShadow = false })
            .SetTitle(new Title { Text = dadosXml.NomeSite })
            .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
            .SetPlotOptions(new PlotOptions
            {
                Pie = new PlotOptionsPie
                {
                    AllowPointSelect = true,
                    Cursor = DotNet.Highcharts.Enums.Cursors.Pointer,
                    DataLabels = new PlotOptionsPieDataLabels
                    {
                        Color = System.Drawing.ColorTranslator.FromHtml("#000000"),
                        ConnectorColor = System.Drawing.ColorTranslator.FromHtml("#000000"),
                        Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                    }
                }
            })
            .SetSeries(new Series
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Pie,
                Name = "Browser share",
                Data = new DotNet.Highcharts.Helpers.Data(dadosGraficoPizza)
            });
            #endregion
            formularioViewModel.GraficoPizza = grafico;
            formularioViewModel.ApresetarResultados = true;
            return View(formularioViewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}