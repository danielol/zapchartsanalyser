using System;
using System.Collections.Generic;

namespace ZapCharts.Data.Model.Entities
{
    public class GraficoPizza
    {
        public GraficoPizza(string titulo, object[] dados)
        {
            Titulo = titulo;
            Dados = dados;
            // new object[]
            //    {
            //        new object[] { "Firefox", 45.0 }, new object[] { "IE", 26.8 },new object[] { "Safari", 8.5 },new object[] { "Opera", 6.2 },new object[] { "Others", 0.7 }
            //    };
        }
        public GraficoPizza(){}
        public string Titulo { get; set; }
        public int Id { get; set; }
        public string[] Categorias { get; set; }
        public object[] Dados { get; set; }
        
    }
}
