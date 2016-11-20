using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZapCharts.Views.ViewModel.Listagem{
    public class DetalhesResultadoZapViewModel{
        public DetalhesResultadoZapViewModel(){
            AlertasViewModel = new List<AlertaViewModel>();
        }

        public string NomeFerramenta{
            get { return "ZAP 2.5.0"; }
        }

        public string NomeSite { get; set; }
        public int portaSite { get; set; }
        public List<AlertaViewModel> AlertasViewModel { get; set; }
        public Highcharts GraficoPizza { get; set; }

        public class AlertaViewModel{
            public AlertaViewModel(){
                Uris = new List<string>();
            }
            public string NomeAlerta { get; set; }
            public int codigoRisco { get; set; }
            public string DescricaoRisco { get; set; }
            public string Descricao { get; set; }
            public List<string> Uris { get; set; }
            public int QtdOcorrencias { get; set; }
            public string Solucao { get; set; }
            public string OutraInformacao { get; set; }
            public string Referencia { get; set; }
            public string Gravidade { get; internal set; }
        }
    }
}