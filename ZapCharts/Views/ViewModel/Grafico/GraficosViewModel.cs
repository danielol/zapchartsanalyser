using DotNet.Highcharts;
using System.Collections.Generic;

namespace ZapCharts.Views.ViewModel.Grafico
{
    public class GraficosViewModel
    {
        public GraficosViewModel()
        {
            //   Graficos = new List<Dictionary<string, Highcharts>>();
            Graficos = new List<Highcharts>();
        }
      //  public List<Dictionary<string, Highcharts>> Graficos {get; set; }
      public List<Highcharts> Graficos { get; set; }
    }
}
