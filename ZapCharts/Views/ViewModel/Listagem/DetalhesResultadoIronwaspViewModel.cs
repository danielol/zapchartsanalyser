using DotNet.Highcharts;
using System.Collections.Generic;

namespace ZapCharts.Views.ViewModel.Listagem {
    public class DetalhesResultadoIronwaspViewModel {
        public DetalhesResultadoIronwaspViewModel() {
            AlertasViewModel = new List<AlertaViewModel>();
        }
        public string NomeFerramenta { get { return "Ironwasp"; } }
        public string NomeSite { get; set; }
        public List<AlertaViewModel> AlertasViewModel { get; set; }
        public Highcharts GraficoPizza { get; set; }
        public class AlertaViewModel {
            public AlertaViewModel() {
                Uris = new List<string>();
            }
            public string NomeAlerta { get; set; }
            public string DescricaoRisco { get; set; }
            public List<string> Uris { get; set; }
            public int QtdOcorrencias { get; set; }
            public string Solucao { get; set; }
            public string Gravidade { get; set; }
        }
    }
}