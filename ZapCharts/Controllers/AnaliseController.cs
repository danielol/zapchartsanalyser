using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using System;
using System.Web;
using System.Web.Mvc;
using ZapCharts.Model.Transiente.Zap2._5._0;
using ZapCharts.Model.Transiente.IronWasp;
using ZapCharts.Util;
using ZapCharts.Views.ViewModel.Formulario;
using ZapCharts.Views.ViewModel.Listagem;
using System.IO;
using HtmlAgilityPack;
using ZapCharts.Model.Transiente.Grabber;

namespace ZapCharts.Controllers {
    public class AnaliseController : Controller {
        [HttpGet]
        public ActionResult Index() {
            return View("Index",new FormularioCadastroAnaliseViewModel());
        }
        [HttpGet]
        public ActionResult Analise() {
            return View();
        }
        [HttpPost]
        public ActionResult Analise(FormularioCadastroAnaliseViewModel viewModel) {
            return View(viewModel);
        }

        public ActionResult ResultadoAnalise(FormularioCadastroAnaliseViewModel formularioCadastroAnaliseViewModel) {
            var resultadoViewModel = new DetalhesResultadoViewModel();
            var pathRepositorio = CriaPathRepositorioSeNaoExiste();
            if(formularioCadastroAnaliseViewModel.ValidarZap) {
                SalvaArquivosParaAnalise(formularioCadastroAnaliseViewModel.ArquivoFerramentaZap,pathRepositorio);
                var dadosXml = ConversorXmlObjectoComplexo.Converter(pathRepositorio + formularioCadastroAnaliseViewModel.ArquivoFerramentaZap.FileName);
                resultadoViewModel.DetalhesResultadoZapViewModel = new DetalhesResultadoZapViewModel();
                if(!formularioCadastroAnaliseViewModel.ArquivoFerramentaZap.FileName.EndsWith(".xml")) {
                    ViewData["Mensagem"] = "O Arquivo da ZAP deve ser no famato XML.";
                    return View(resultadoViewModel);
                }
                #region geraDadoSGraficoPizza
                object[] dadosGraficoPizza = new object[dadosXml.Alertas.Count];
                for(int i = 0;i < dadosGraficoPizza.Length - 1;i++) {
                    dadosGraficoPizza[i] = new object[] { dadosXml.Alertas[i].NomeAlerta,dadosXml.Alertas[i].QtdOcorrencias };
                }
                #endregion
                resultadoViewModel.DetalhesResultadoZapViewModel.GraficoPizza = GeraGraficoDePizza(dadosGraficoPizza,pathRepositorio);
                MapeaResultadoZapParaViewModel(dadosXml,resultadoViewModel.DetalhesResultadoZapViewModel);
            }

            if(formularioCadastroAnaliseViewModel.ValidarIronwasp) {
                SalvaArquivosParaAnalise(formularioCadastroAnaliseViewModel.ArquivoFerramentaIronwasp,pathRepositorio);
                var dadosHtml = ConversorHtmlObjectoComplexo.Converter(pathRepositorio + formularioCadastroAnaliseViewModel.ArquivoFerramentaIronwasp.FileName);
                resultadoViewModel.DetalhesResultadoIronwaspViewModel = new DetalhesResultadoIronwaspViewModel();
                if(!formularioCadastroAnaliseViewModel.ArquivoFerramentaIronwasp.FileName.EndsWith(".html")) {
                    ViewData["Mensagem"] = "O Arquivo da IronWasp deve ser no famato HTML.";
                    return View(resultadoViewModel);
                }
                #region geraDadoSGraficoPizza


                object[] dadosGraficoPizzaIron = new object[dadosHtml.Alertas.Count];
                for(int i = 0;i < dadosGraficoPizzaIron.Length;i++) {
                    dadosGraficoPizzaIron[i] = new object[] { dadosHtml.Alertas[i].NomeAlerta,dadosHtml.Alertas[i].QtdOcorrencias };
                }


                #endregion
                resultadoViewModel.DetalhesResultadoIronwaspViewModel.GraficoPizza = GeraGraficoDePizza(dadosGraficoPizzaIron,pathRepositorio);
                MapeaResultadoIronWaspParaViewModel(dadosHtml,resultadoViewModel.DetalhesResultadoIronwaspViewModel);
            }
            if(formularioCadastroAnaliseViewModel.ValidarGrabber) {
                var dadosXml = ConversorGrabberXmlObjectoComplexo.Converter(pathRepositorio + formularioCadastroAnaliseViewModel.ArquivoFerramentaGrabber.FileName);
                resultadoViewModel.DetalhesResultadoGrabberViewModel = new DetalhesResultadoGrabberViewModel();
                if(!formularioCadastroAnaliseViewModel.ArquivoFerramentaGrabber.FileName.EndsWith(".xml")) {
                    ViewData["Mensagem"] = "O Arquivo da Grabber deve ser no famato XML.";
                    return View(resultadoViewModel);
                }
                #region geraDadoSGraficoPizza
                object[] dadosGraficoPizza = new object[dadosXml.Alertas.Count];
                for(int i = 0;i < dadosGraficoPizza.Length;i++) {
                    dadosGraficoPizza[i] = new object[] { dadosXml.Alertas[i].NomeAlerta,dadosXml.Alertas[i].QtdOcorrencias };
                }
                #endregion
                resultadoViewModel.DetalhesResultadoGrabberViewModel.GraficoPizza = GeraGraficoDePizza(dadosGraficoPizza,pathRepositorio);
                MapeaResultadoGrabberParaViewModel(dadosXml,resultadoViewModel.DetalhesResultadoGrabberViewModel);
            }
            return View(resultadoViewModel);
        }

        private void SalvaArquivosParaAnalise(HttpPostedFileBase arquivo,string pathRepositorio) {
            if(arquivo == null)
                throw new Exception("Arquivo não especificado.");
            arquivo.SaveAs(pathRepositorio + arquivo.FileName);
        }
        private Highcharts GeraGraficoDePizza(object[] dadosGrafico,string pathRepositorio) {

            var grafico = new DotNet.Highcharts.Highcharts("grafico_pizza_" + DateTime.Now.Millisecond)
                        .InitChart(new Chart { PlotShadow = false })
                        .SetTitle(new Title { Text = string.Empty })
                        .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })

                        .SetPlotOptions(new PlotOptions {
                            Pie = new PlotOptionsPie {
                                AllowPointSelect = true,
                                Cursor = DotNet.Highcharts.Enums.Cursors.Pointer,
                                DataLabels = new PlotOptionsPieDataLabels {
                                    Enabled = false
                                },
                                ShowInLegend = true
                            }
                        })
                        .SetSeries(new Series {
                            Type = DotNet.Highcharts.Enums.ChartTypes.Pie,
                            Name = "Browser share",
                            Data = new DotNet.Highcharts.Helpers.Data(dadosGrafico)
                        });
            return grafico;
        }

        private void MapeaResultadoZapParaViewModel(ZapReportXml resultadoXml,DetalhesResultadoZapViewModel viewModel) {
            viewModel.NomeSite = resultadoXml.NomeSite;
            viewModel.portaSite = resultadoXml.PortaSite;
            foreach(var alerta in resultadoXml.Alertas) {
                viewModel.AlertasViewModel.Add(new DetalhesResultadoZapViewModel.AlertaViewModel() {
                    codigoRisco = alerta.codioRisco,
                    Descricao = alerta.Descricao,
                    DescricaoRisco = alerta.DescricaoRisco,
                    NomeAlerta = alerta.NomeAlerta,
                    OutraInformacao = alerta.OutraInformacao,
                    QtdOcorrencias = alerta.QtdOcorrencias,
                    Referencia = alerta.Referencia,
                    Solucao = alerta.Solucao,
                    Uris = alerta.Uris
                });
            }
        }

        private void MapeaResultadoIronWaspParaViewModel(IronWaspReportHtml resultadoHtml,DetalhesResultadoIronwaspViewModel viewModel) {
            viewModel.NomeSite = resultadoHtml.NomeSite;
            foreach(var alerta in resultadoHtml.Alertas) {
                viewModel.AlertasViewModel.Add(new DetalhesResultadoIronwaspViewModel.AlertaViewModel() {
                    DescricaoRisco = alerta.DescricaoRisco,
                    NomeAlerta = alerta.NomeAlerta,
                    Gravidade = alerta.Gravidade,
                    QtdOcorrencias = alerta.QtdOcorrencias,
                    Solucao = alerta.Solucao,
                    Uris = alerta.Uris
                });
            }
        }
        private void MapeaResultadoGrabberParaViewModel(GrabberReportXml resultadoXml,DetalhesResultadoGrabberViewModel viewModel) {
            viewModel.NomeSite = resultadoXml.NomeSite;
            foreach(var alerta in resultadoXml.Alertas) {
                viewModel.AlertasViewModel.Add(new DetalhesResultadoGrabberViewModel.AlertaViewModel(){
                    NomeAlerta = alerta.NomeAlerta,
                    QtdOcorrencias = alerta.QtdOcorrencias,
                    Uris = alerta.Uris
                });
            }
        }
        
        private string CriaPathRepositorioSeNaoExiste() {
            var path = Request.PhysicalApplicationPath + "\\_repositorio\\";
            if(!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path.ToString();
        }
    }
}