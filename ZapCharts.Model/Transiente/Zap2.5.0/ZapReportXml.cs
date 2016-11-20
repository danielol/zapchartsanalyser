using System.Collections.Generic;

namespace ZapCharts.Model.Transiente.Zap2._5._0
{
    public class ZapReportXml
    {
        public ZapReportXml()
        {
            Alertas = new List<Alerta>();
        }
        public string NomeSite { get; set; }
        public int PortaSite { get; set; }
        public List<Alerta> Alertas { get; set; }
    }
    public class Alerta
    {
        public Alerta()
        {
            Uris = new List<string>();
        }
        public string NomeAlerta { get; set; }
        public int codioRisco { get; set; }
        public string DescricaoRisco{ get; set; }
        public string Descricao { get; set; }
        public List<string> Uris { get; set; }
        public int QtdOcorrencias { get; set; }
        public string Solucao{ get; set; }
        public string OutraInformacao { get; set; }
        public string Referencia{ get; set; }
    }
}

