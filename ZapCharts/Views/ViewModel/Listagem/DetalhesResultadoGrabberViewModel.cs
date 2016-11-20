using System.Collections.Generic;
using DotNet.Highcharts;

namespace ZapCharts.Views.ViewModel.Listagem
{
    public class DetalhesResultadoGrabberViewModel
    {
        public DetalhesResultadoGrabberViewModel(){
            AlertasViewModel= new List<AlertaViewModel>();
        }
        public string NomeFerramenta { get { return "Grabber"; } }
        public Highcharts GraficoPizza { get; set; }

        public string NomeSite { get; set; }
        public List<AlertaViewModel> AlertasViewModel { get; set; }
        public class AlertaViewModel {
            public AlertaViewModel() {
                Uris = new List<string>();
            }
            public string NomeAlerta { get; set; }
            public List<string> Uris { get; set; }
            public int QtdOcorrencias { get; set; }
        }

    }
}