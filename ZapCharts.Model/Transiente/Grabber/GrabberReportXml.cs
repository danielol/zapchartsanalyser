using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapCharts.Model.Transiente.Grabber
{
    public class GrabberReportXml
    {
      
        public GrabberReportXml()
        {
            Alertas = new List<Alerta>();
        }
        public string NomeSite { get; set; }
        public int PortaSite { get; set; }
        public List<Alerta> Alertas { get; set; }

        public class Alerta
        {
            public Alerta()
            {
                Uris = new List<string>();
            }
            public string NomeAlerta { get; set; }
            public string Descricao { get; set; }
            public List<string> Uris { get; set; }
            public int QtdOcorrencias { get; set; }
            public string Solucao { get; set; }
            public string OutraInformacao { get; set; }
            public string Referencia { get; set; }
        }
    }
}
