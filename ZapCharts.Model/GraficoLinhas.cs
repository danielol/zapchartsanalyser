namespace ZapCharts.Data.Model.Entities
{
    public class GraficoLinhas
    {
        public GraficoLinhas(string titulo)
        {
            Titulo = titulo;
            Categorias = new[] { "X-Content-Type-Options Header Missing", "SQL Injection", "Web Browser XSS Protection Not Enabled", "X-Frame-Options Header Not Set" };
            Dados = new object[] { 3.0, 1.0, 4.0, 2.0 };
            Titulo = "Gráfico de Linhas";
        }

        public string Titulo { get; set; }
        public string[] Categorias { get; set; }
        public object[] Dados { get; set; }

    }
}

